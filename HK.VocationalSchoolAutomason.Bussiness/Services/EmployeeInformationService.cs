using AutoMapper;
using FluentValidation;
using HK.VocationalSchoolAutomason.Bussiness.Extensions;
using HK.VocationalSchoolAutomason.Bussiness.Interfaces;
using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.DataAccess.UnitOfWork;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeInformationDtos;
using HK.VocationalSchoolAutomason.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Services
{
    public class EmployeeInformationService : IEmployeeInformation
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<EmployeeInformationCreateDto> _createValidator;
        private readonly IValidator<EmployeeInformationUpdateDto> _updateValidator;

        public EmployeeInformationService(IUow uow, IMapper mapper, IValidator<EmployeeInformationCreateDto> createValidator, IValidator<EmployeeInformationUpdateDto> updateValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<EmployeeInformationCreateDto>> Create(EmployeeInformationCreateDto dto)
        {
            var ValidationResult = _createValidator.Validate(dto);
            if (ValidationResult.IsValid)
            {
                await _uow.GetRepository<EmployeeInformation>().Create(_mapper.Map<EmployeeInformation>(dto));
                await _uow.SaveChanges();

                return new Response<EmployeeInformationCreateDto>(ResponseType.Success, dto);
            }



            else
            {

                return new Response<EmployeeInformationCreateDto>(ResponseType.ValidationError, dto, ValidationResult.CovertToCustomValidationError());
            }
        }

        public async Task<IResponse<List<EmployeeInformationListDto>>> GetAllStudents()
        {
            var data = _mapper.Map<List<EmployeeInformationListDto>>(await _uow.GetRepository<EmployeeInformation>().GetAll());

            return new Response<List<EmployeeInformationListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<EmployeeInformation>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var deletedEntity = await _uow.GetRepository<EmployeeInformation>().GetByFilter(x => x.Id == id);
            if (deletedEntity != null)
            {
                _uow.GetRepository<EmployeeInformation>().Remove(deletedEntity);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            else
            {
                return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
        }

        public async Task<IResponse<EmployeeInformationUpdateDto>> Update(EmployeeInformationUpdateDto dto)
        {
            var result = _updateValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<EmployeeInformation>().Find(dto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<EmployeeInformation>().Update(_mapper.Map<EmployeeInformation>(dto), updatedEntity);
                    _uow.SaveChanges();

                    return new Response<EmployeeInformationUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<EmployeeInformationUpdateDto>(ResponseType.NotFound, $"{dto.Id} ait data bulunamadı");

            }
            else
            {
                return new Response<EmployeeInformationUpdateDto>(ResponseType.ValidationError, dto, result.CovertToCustomValidationError());
            }
        }
    }
}
