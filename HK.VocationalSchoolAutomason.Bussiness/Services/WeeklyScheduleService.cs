using AutoMapper;
using FluentValidation;
using HK.VocationalSchoolAutomason.Bussiness.Extensions;
using HK.VocationalSchoolAutomason.Bussiness.Interfaces;
using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.DataAccess.UnitOfWork;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.DayDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.WeeklyScheduleDtos;
using HK.VocationalSchoolAutomason.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Services
{
    public class WeeklyScheduleService : IWeeklySchedule
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<WeeklyScheduleCreateDto> _createValidator;
        private readonly IValidator<WeeklyScheduleUpdateDto> _updateValidator;

        public WeeklyScheduleService(IUow uow, IMapper mapper, IValidator<WeeklyScheduleCreateDto> createValidator, IValidator<WeeklyScheduleUpdateDto> updateValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<WeeklyScheduleCreateDto>> Create(WeeklyScheduleCreateDto dto)
        {
            var ValidationResult = _createValidator.Validate(dto);
            if (ValidationResult.IsValid)
            {
                await _uow.GetRepository<WeeklySchedule>().Create(_mapper.Map<WeeklySchedule>(dto));
                await _uow.SaveChanges();

                return new Response<WeeklyScheduleCreateDto>(ResponseType.Success, dto);
            }



            else
            {

                return new Response<WeeklyScheduleCreateDto>(ResponseType.ValidationError, dto, ValidationResult.CovertToCustomValidationError());
            }
        }

        public async Task<IResponse<List<WeeklyScheduleListDto>>> GetAllStudents()
        {
            var data = _mapper.Map<List<WeeklyScheduleListDto>>(await _uow.GetRepository<WeeklySchedule>().GetAll());

            return new Response<List<WeeklyScheduleListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<WeeklySchedule>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var deletedEntity = await _uow.GetRepository<WeeklySchedule>().GetByFilter(x => x.Id == id);
            if (deletedEntity != null)
            {
                _uow.GetRepository<WeeklySchedule>().Remove(deletedEntity);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            else
            {
                return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
        }

        public async Task<IResponse<WeeklyScheduleUpdateDto>> Update(WeeklyScheduleUpdateDto dto)
        {
            var result = _updateValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<WeeklySchedule>().Find(dto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<WeeklySchedule>().Update(_mapper.Map<WeeklySchedule>(dto), updatedEntity);
                    _uow.SaveChanges();

                    return new Response<WeeklyScheduleUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<WeeklyScheduleUpdateDto>(ResponseType.NotFound, $"{dto.Id} ait data bulunamadı");

            }
            else
            {
                return new Response<WeeklyScheduleUpdateDto>(ResponseType.ValidationError, dto, result.CovertToCustomValidationError());
            }
        }
    }
}
