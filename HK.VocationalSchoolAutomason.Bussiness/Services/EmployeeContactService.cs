using AutoMapper;
using FluentValidation;
using HK.VocationalSchoolAutomason.Bussiness.Extensions;
using HK.VocationalSchoolAutomason.Bussiness.Interfaces;
using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.DataAccess.UnitOfWork;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeContact;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.Parent_Information;
using HK.VocationalSchoolAutomason.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Services
{
    public class EmployeeContactService : IEmployeeContact
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<EmployeeContactCreateDto> _createValidator;
        private readonly IValidator<EmployeeContactUpdateDto> _updateValidator;

        public EmployeeContactService(IUow uow, IMapper mapper, IValidator<EmployeeContactCreateDto> createValidator, IValidator<EmployeeContactUpdateDto> updateValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<EmployeeContactCreateDto>> Create(EmployeeContactCreateDto dto)
        {
            var ValidationResult = _createValidator.Validate(dto);
            if (ValidationResult.IsValid)
            {
                await _uow.GetRepository<EmployeeContact>().Create(_mapper.Map<EmployeeContact>(dto));
                await _uow.SaveChanges();

                return new Response<EmployeeContactCreateDto>(ResponseType.Success, dto);
            }

            else
            {

                return new Response<EmployeeContactCreateDto>(ResponseType.ValidationError, dto, ValidationResult.CovertToCustomValidationError());
            }
        }

        public async Task<IResponse<List<EmployeeContactListDto>>> GetAllStudents()
        {
            var data = _mapper.Map<List<EmployeeContactListDto>>(await _uow.GetRepository<EmployeeContact>().GetAll());

            return new Response<List<EmployeeContactListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<EmployeeContact>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var deletedEntity = await _uow.GetRepository<EmployeeContact>().GetByFilter(x => x.Id == id);
            if (deletedEntity != null)
            {
                _uow.GetRepository<EmployeeContact>().Remove(deletedEntity);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            else
            {
                return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
        }

        public async Task<IResponse<EmployeeContactUpdateDto>> Update(EmployeeContactUpdateDto dto)
        {
            var result = _updateValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<EmployeeContact>().Find(dto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<EmployeeContact>().Update(_mapper.Map<EmployeeContact>(dto), updatedEntity);
                    _uow.SaveChanges();

                    return new Response<EmployeeContactUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<EmployeeContactUpdateDto>(ResponseType.NotFound, $"{dto.Id} ait data bulunamadı");

            }
            else
            {
                return new Response<EmployeeContactUpdateDto>(ResponseType.ValidationError, dto, result.CovertToCustomValidationError());
            }
        }
    }
}
