using AutoMapper;
using FluentValidation;
using HK.VocationalSchoolAutomason.Bussiness.Extensions;
using HK.VocationalSchoolAutomason.Bussiness.Interfaces;
using HK.VocationalSchoolAutomason.Bussiness.ValidationRules.StudentContactValidations;
using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.DataAccess.UnitOfWork;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.StudentContactDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.StudentDtos;
using HK.VocationalSchoolAutomason.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Services
{
    public class StudentContactService : IStudentContactService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<StudentContactCreateDto> _createValidator;
        private readonly IValidator<StudentContactUpdateDto> _updateValidator;

        public StudentContactService(IUow uow, IMapper mapper, IValidator<StudentContactCreateDto> createValidator, IValidator<StudentContactUpdateDto> updateValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<StudentContactCreateDto>> Create(StudentContactCreateDto dto)
        {

            var ValidationResult = _createValidator.Validate(dto);
            if (ValidationResult.IsValid)
            {
                await _uow.GetRepository<StudentContact>().Create(_mapper.Map<StudentContact>(dto));
                await _uow.SaveChanges();

                return new Response<StudentContactCreateDto>(ResponseType.Success, dto);
            }

            else
            {

                return new Response<StudentContactCreateDto>(ResponseType.ValidationError, dto, ValidationResult.CovertToCustomValidationError());
            }
        }

        public async Task<IResponse<List<StudentContactListDto>>> GetAllStudents()
        {
            var data = _mapper.Map<List<StudentContactListDto>>(await _uow.GetRepository<StudentContact>().GetAll());

            return new Response<List<StudentContactListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<StudentContact>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var deletedStudent = await _uow.GetRepository<StudentContact>().GetByFilter(x => x.Id == id);
            if (deletedStudent != null)
            {
                _uow.GetRepository<StudentContact>().Remove(deletedStudent);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            else
            {
                return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
        }

        public async Task<IResponse<StudentContactUpdateDto>> Update(StudentContactUpdateDto dto)
        {
            var result = _updateValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<StudentContact>().Find(dto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<StudentContact>().Update(_mapper.Map<StudentContact>(dto), updatedEntity);
                    _uow.SaveChanges();

                    return new Response<StudentContactUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<StudentContactUpdateDto>(ResponseType.NotFound, $"{dto.Id} ait data bulunamadı");

            }
            else
            {
                return new Response<StudentContactUpdateDto>(ResponseType.ValidationError, dto, result.CovertToCustomValidationError());
            }
        }
    }

}
