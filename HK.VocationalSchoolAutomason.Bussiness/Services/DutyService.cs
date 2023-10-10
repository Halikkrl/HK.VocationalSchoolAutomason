using AutoMapper;
using FluentValidation;
using HK.VocationalSchoolAutomason.Bussiness.Extensions;
using HK.VocationalSchoolAutomason.Bussiness.Interfaces;
using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.DataAccess.UnitOfWork;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.DutiesDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeInformationDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.StudentDtos;
using HK.VocationalSchoolAutomason.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Services
{
    public class DutyService : InterfaceGenel<DutyListDto, DutyCreateDto, DutyUpdateDto>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<DutyCreateDto> _createValidator;
        private readonly IValidator<DutyUpdateDto> _updateValidator;


        public DutyService(IUow uow, IMapper mapper, IValidator<DutyCreateDto> createValidator, IValidator<DutyUpdateDto> updateValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<DutyCreateDto>> Create(DutyCreateDto dto)
        {
            var ValidationResult = _createValidator.Validate(dto);
            if (ValidationResult.IsValid)
            {
                await _uow.GetRepository<Duty>().Create(_mapper.Map<Duty>(dto));
                await _uow.SaveChanges();

                return new Response<DutyCreateDto>(ResponseType.Success, dto);
            }



            else
            {

                return new Response<DutyCreateDto>(ResponseType.ValidationError, dto, ValidationResult.CovertToCustomValidationError());
            }
        }

        public async Task<IResponse<List<DutyListDto>>> GetAllStudents()
        {
            var data = _mapper.Map<List<DutyListDto>>(await _uow.GetRepository<Duty>().GetAll());

            return new Response<List<DutyListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<Duty>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var deletedEntity = await _uow.GetRepository<Duty>().GetByFilter(x => x.Id == id);
            if (deletedEntity != null)
            {
                _uow.GetRepository<Duty>().Remove(deletedEntity);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            else
            {
                return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
        }

        public async Task<IResponse<DutyUpdateDto>> Update(DutyUpdateDto dto)
        {
            var result = _updateValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<Duty>().Find(dto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<Duty>().Update(_mapper.Map<Duty>(dto), updatedEntity);
                    _uow.SaveChanges();

                    return new Response<DutyUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<DutyUpdateDto>(ResponseType.NotFound, $"{dto.Id} ait data bulunamadı");

            }
            else
            {
                return new Response<DutyUpdateDto>(ResponseType.ValidationError, dto, result.CovertToCustomValidationError());
            }
        }
    }
}
