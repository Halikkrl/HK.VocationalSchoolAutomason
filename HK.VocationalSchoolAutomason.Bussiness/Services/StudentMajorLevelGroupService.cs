using AutoMapper;
using FluentValidation;
using HK.VocationalSchoolAutomason.Bussiness.Extensions;
using HK.VocationalSchoolAutomason.Bussiness.Interfaces;
using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.DataAccess.UnitOfWork;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.DayDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.StudentMajorLevelGroupDtos;
using HK.VocationalSchoolAutomason.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Services
{
    public class StudentMajorLevelGroupService : IStudentMajorLevelGroup
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<StudentMajorLevelGroupCreateDto> _createValidator;
        private readonly IValidator<StudentMajorLevelGroupUpdateDto> _updateValidator;

        public StudentMajorLevelGroupService(IUow uow, IMapper mapper, IValidator<StudentMajorLevelGroupCreateDto> createValidator, IValidator<StudentMajorLevelGroupUpdateDto> updateValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<StudentMajorLevelGroupCreateDto>> Create(StudentMajorLevelGroupCreateDto dto)
        {
            var ValidationResult = _createValidator.Validate(dto);
            if (ValidationResult.IsValid)
            {
                await _uow.GetRepository<StudentMajorLevelGroup>().Create(_mapper.Map<StudentMajorLevelGroup>(dto));
                await _uow.SaveChanges();

                return new Response<StudentMajorLevelGroupCreateDto>(ResponseType.Success, dto);
            }



            else
            {

                return new Response<StudentMajorLevelGroupCreateDto>(ResponseType.ValidationError, dto, ValidationResult.CovertToCustomValidationError());
            }
        }

        public async Task<IResponse<List<StudentMajorLevelGroupListDto>>> GetAllStudents()
        {
            var data = _mapper.Map<List<StudentMajorLevelGroupListDto>>(await _uow.GetRepository<StudentMajorLevelGroup>().GetAll());

            return new Response<List<StudentMajorLevelGroupListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<StudentMajorLevelGroup>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var deletedEntity = await _uow.GetRepository<StudentMajorLevelGroup>().GetByFilter(x => x.Id == id);
            if (deletedEntity != null)
            {
                _uow.GetRepository<StudentMajorLevelGroup>().Remove(deletedEntity);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            else
            {
                return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
        }

        public async Task<IResponse<StudentMajorLevelGroupUpdateDto>> Update(StudentMajorLevelGroupUpdateDto dto)
        {
            var result = _updateValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<StudentMajorLevelGroup>().Find(dto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<StudentMajorLevelGroup>().Update(_mapper.Map<StudentMajorLevelGroup>(dto), updatedEntity);
                    _uow.SaveChanges();

                    return new Response<StudentMajorLevelGroupUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<StudentMajorLevelGroupUpdateDto>(ResponseType.NotFound, $"{dto.Id} ait data bulunamadı");

            }
            else
            {
                return new Response<StudentMajorLevelGroupUpdateDto>(ResponseType.ValidationError, dto, result.CovertToCustomValidationError());
            }
        }
    }
}
