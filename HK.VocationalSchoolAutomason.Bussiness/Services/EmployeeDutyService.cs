using AutoMapper;
using FluentValidation;
using HK.VocationalSchoolAutomason.Bussiness.Extensions;
using HK.VocationalSchoolAutomason.Bussiness.Interfaces;
using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.DataAccess.UnitOfWork;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.DutiesDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeDutyDtos;
using HK.VocationalSchoolAutomason.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Services
{

    public class EmployeeDutyService : IEmployeeDuty
    {

        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<EmployeeDutyCreateDto> _createValidator;
        private readonly IValidator<EmployeeDutyUpdateDto> _updateValidator;

        public EmployeeDutyService(IUow uow, IMapper mapper, IValidator<EmployeeDutyCreateDto> createValidator, IValidator<EmployeeDutyUpdateDto> updateValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<EmployeeDutyCreateDto>> Create(EmployeeDutyCreateDto dto)
        {
            var ValidationResult = _createValidator.Validate(dto);
            if (ValidationResult.IsValid)
            {
                await _uow.GetRepository<EmployeeDuty>().Create(_mapper.Map<EmployeeDuty>(dto));
                await _uow.SaveChanges();

                return new Response<EmployeeDutyCreateDto>(ResponseType.Success, dto);
            }



            else
            {

                return new Response<EmployeeDutyCreateDto>(ResponseType.ValidationError, dto, ValidationResult.CovertToCustomValidationError());
            }
        }

        public async Task<IResponse<List<EmployeeDutyListDto>>> GetAllStudents()
        {
            var data = _mapper.Map<List<EmployeeDutyListDto>>(await _uow.GetRepository<EmployeeDuty>().GetAll());

            return new Response<List<EmployeeDutyListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<EmployeeDuty>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var deletedEntity = await _uow.GetRepository<EmployeeDuty>().GetByFilter(x => x.Id == id);
            if (deletedEntity != null)
            {
                _uow.GetRepository<EmployeeDuty>().Remove(deletedEntity);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            else
            {
                return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
        }

        public async Task<IResponse<EmployeeDutyUpdateDto>> Update(EmployeeDutyUpdateDto dto)
        {
            var result = _updateValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<EmployeeDuty>().Find(dto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<EmployeeDuty>().Update(_mapper.Map<EmployeeDuty>(dto), updatedEntity);
                    _uow.SaveChanges();

                    return new Response<EmployeeDutyUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<EmployeeDutyUpdateDto>(ResponseType.NotFound, $"{dto.Id} ait data bulunamadı");

            }
            else
            {
                return new Response<EmployeeDutyUpdateDto>(ResponseType.ValidationError, dto, result.CovertToCustomValidationError());
            }
        }
    }
}
