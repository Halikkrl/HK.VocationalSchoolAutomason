using AutoMapper;
using FluentValidation;
using HK.VocationalSchoolAutomason.Bussiness.Extensions;
using HK.VocationalSchoolAutomason.Bussiness.Interfaces;
using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.DataAccess.UnitOfWork;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.ClassLessonDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.CourseBranchDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.DayDtos;
using HK.VocationalSchoolAutomason.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Services
{
    public class ClassLessonService : IClassLesson
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<ClassLessonCreateDto> _createValidator;
        private readonly IValidator<ClassLessonUpdateDto> _updateValidator;

        public ClassLessonService(IUow uow, IMapper mapper, IValidator<ClassLessonCreateDto> createValidator, IValidator<ClassLessonUpdateDto> updateValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<ClassLessonCreateDto>> Create(ClassLessonCreateDto dto)
        {
            var ValidationResult = _createValidator.Validate(dto);
            if (ValidationResult.IsValid)
            {
                await _uow.GetRepository<ClassLessons>().Create(_mapper.Map<ClassLessons>(dto));
                await _uow.SaveChanges();

                return new Response<ClassLessonCreateDto>(ResponseType.Success, dto);
            }



            else
            {

                return new Response<ClassLessonCreateDto>(ResponseType.ValidationError, dto, ValidationResult.CovertToCustomValidationError());
            }
        }

        public async Task<IResponse<List<ClassLessonListDto>>> GetAllStudents()
        {
            var data = _mapper.Map<List<ClassLessonListDto>>(await _uow.GetRepository<ClassLessons>().GetAll());

            return new Response<List<ClassLessonListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<ClassLessons>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var deletedEntity = await _uow.GetRepository<ClassLessons>().GetByFilter(x => x.Id == id);
            if (deletedEntity != null)
            {
                _uow.GetRepository<ClassLessons>().Remove(deletedEntity);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            else
            {
                return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
        }

        public async Task<IResponse<ClassLessonUpdateDto>> Update(ClassLessonUpdateDto dto)
        {
            var result = _updateValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<ClassLessons>().Find(dto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<ClassLessons>().Update(_mapper.Map<ClassLessons>(dto), updatedEntity);
                    _uow.SaveChanges();

                    return new Response<ClassLessonUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<ClassLessonUpdateDto>(ResponseType.NotFound, $"{dto.Id} ait data bulunamadı");

            }
            else
            {
                return new Response<ClassLessonUpdateDto>(ResponseType.ValidationError, dto, result.CovertToCustomValidationError());
            }
        }
    }
}
