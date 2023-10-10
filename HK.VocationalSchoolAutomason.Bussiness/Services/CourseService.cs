using AutoMapper;
using FluentValidation;
using HK.VocationalSchoolAutomason.Bussiness.Extensions;
using HK.VocationalSchoolAutomason.Bussiness.Interfaces;
using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.DataAccess.UnitOfWork;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.CourseDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.DayDtos;
using HK.VocationalSchoolAutomason.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Services
{
    public class CourseService : ICourse
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<CourseCreateDto> _createValidator;
        private readonly IValidator<CourseUpdateDto> _updateValidator;

        public CourseService(IUow uow, IMapper mapper, IValidator<CourseCreateDto> createValidator, IValidator<CourseUpdateDto> updateValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<CourseCreateDto>> Create(CourseCreateDto dto)
        {
            var ValidationResult = _createValidator.Validate(dto);
            if (ValidationResult.IsValid)
            {
                await _uow.GetRepository<Course>().Create(_mapper.Map<Course>(dto));
                await _uow.SaveChanges();

                return new Response<CourseCreateDto>(ResponseType.Success, dto);
            }



            else
            {

                return new Response<CourseCreateDto>(ResponseType.ValidationError, dto, ValidationResult.CovertToCustomValidationError());
            }
        }

        public async Task<IResponse<List<CourseListDto>>> GetAllStudents()
        {
            var data = _mapper.Map<List<CourseListDto>>(await _uow.GetRepository<Course>().GetAll());

            return new Response<List<CourseListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<Course>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var deletedEntity = await _uow.GetRepository<Course>().GetByFilter(x => x.Id == id);
            if (deletedEntity != null)
            {
                _uow.GetRepository<Course>().Remove(deletedEntity);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            else
            {
                return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
        }

        public async Task<IResponse<CourseUpdateDto>> Update(CourseUpdateDto dto)
        {
            var result = _updateValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<Course>().Find(dto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<Course>().Update(_mapper.Map<Course>(dto), updatedEntity);
                    _uow.SaveChanges();

                    return new Response<CourseUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<CourseUpdateDto>(ResponseType.NotFound, $"{dto.Id} ait data bulunamadı");

            }
            else
            {
                return new Response<CourseUpdateDto>(ResponseType.ValidationError, dto, result.CovertToCustomValidationError());
            }
        }
    }
}
