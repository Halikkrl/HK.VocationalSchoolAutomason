using AutoMapper;
using FluentValidation;
using HK.VocationalSchoolAutomason.Bussiness.Extensions;
using HK.VocationalSchoolAutomason.Bussiness.Interfaces;
using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.DataAccess.UnitOfWork;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.GroupDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.LessonDayandTimeInformationDtos;
using HK.VocationalSchoolAutomason.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Services
{
    public class LessonDayandTimeInformationService : ILessonDayandTimeInformation
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<LessonDayandTimeInformationCreateDto> _createValidator;
        private readonly IValidator<LessonDayandTimeInformationUpdateDto> _updateValidator;

        public LessonDayandTimeInformationService(IUow uow, IMapper mapper, IValidator<LessonDayandTimeInformationCreateDto> createValidator, IValidator<LessonDayandTimeInformationUpdateDto> updateValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<LessonDayandTimeInformationCreateDto>> Create(LessonDayandTimeInformationCreateDto dto)
        {
            var ValidationResult = _createValidator.Validate(dto);
            if (ValidationResult.IsValid)
            {
                await _uow.GetRepository<LessonDayandTimeInformation>().Create(_mapper.Map<LessonDayandTimeInformation>(dto));
                await _uow.SaveChanges();

                return new Response<LessonDayandTimeInformationCreateDto>(ResponseType.Success, dto);
            }



            else
            {

                return new Response<LessonDayandTimeInformationCreateDto>(ResponseType.ValidationError, dto, ValidationResult.CovertToCustomValidationError());
            }
        }

        public async Task<IResponse<List<LessonDayandTimeInformationListDto>>> GetAllStudents()
        {
            var data = _mapper.Map<List<LessonDayandTimeInformationListDto>>(await _uow.GetRepository<LessonDayandTimeInformation>().GetAll());

            return new Response<List<LessonDayandTimeInformationListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<LessonDayandTimeInformation>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var deletedEntity = await _uow.GetRepository<LessonDayandTimeInformation>().GetByFilter(x => x.Id == id);
            if (deletedEntity != null)
            {
                _uow.GetRepository<LessonDayandTimeInformation>().Remove(deletedEntity);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            else
            {
                return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
        }

        public async Task<IResponse<LessonDayandTimeInformationUpdateDto>> Update(LessonDayandTimeInformationUpdateDto dto)
        {
            var result = _updateValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<LessonDayandTimeInformation>().Find(dto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<LessonDayandTimeInformation>().Update(_mapper.Map<LessonDayandTimeInformation>(dto), updatedEntity);
                    _uow.SaveChanges();

                    return new Response<LessonDayandTimeInformationUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<LessonDayandTimeInformationUpdateDto>(ResponseType.NotFound, $"{dto.Id} ait data bulunamadı");

            }
            else
            {
                return new Response<LessonDayandTimeInformationUpdateDto>(ResponseType.ValidationError, dto, result.CovertToCustomValidationError());
            }
        }
    }
}
