using AutoMapper;
using FluentValidation;
using HK.VocationalSchoolAutomason.Bussiness.Extensions;
using HK.VocationalSchoolAutomason.Bussiness.Interfaces;
using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.DataAccess.UnitOfWork;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.DayDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.LevelDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.WeeklyLessonHoursDtos;
using HK.VocationalSchoolAutomason.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Services
{
    public class DayService : IDay
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<DayCreateDto> _createValidator;
        private readonly IValidator<DayUpdateDto> _updateValidator;

        public DayService(IUow uow, IMapper mapper, IValidator<DayCreateDto> createValidator, IValidator<DayUpdateDto> updateValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<DayCreateDto>> Create(DayCreateDto dto)
        {
            var ValidationResult = _createValidator.Validate(dto);
            if (ValidationResult.IsValid)
            {
                await _uow.GetRepository<Day>().Create(_mapper.Map<Day>(dto));
                await _uow.SaveChanges();

                return new Response<DayCreateDto>(ResponseType.Success, dto);
            }



            else
            {

                return new Response<DayCreateDto>(ResponseType.ValidationError, dto, ValidationResult.CovertToCustomValidationError());
            }
        }

        public async Task<IResponse<List<DayListDto>>> GetAllStudents()
        {
            var data = _mapper.Map<List<DayListDto>>(await _uow.GetRepository<Day>().GetAll());

            return new Response<List<DayListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<Day>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var deletedEntity = await _uow.GetRepository<Day>().GetByFilter(x => x.Id == id);
            if (deletedEntity != null)
            {
                _uow.GetRepository<Day>().Remove(deletedEntity);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            else
            {
                return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
        }

        public async Task<IResponse<DayUpdateDto>> Update(DayUpdateDto dto)
        {
            var result = _updateValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<Day>().Find(dto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<Day>().Update(_mapper.Map<Day>(dto), updatedEntity);
                    _uow.SaveChanges();

                    return new Response<DayUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<DayUpdateDto>(ResponseType.NotFound, $"{dto.Id} ait data bulunamadı");

            }
            else
            {
                return new Response<DayUpdateDto>(ResponseType.ValidationError, dto, result.CovertToCustomValidationError());
            }
        }
    }
}
