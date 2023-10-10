using AutoMapper;
using FluentValidation;
using HK.VocationalSchoolAutomason.Bussiness.Extensions;
using HK.VocationalSchoolAutomason.Bussiness.Interfaces;
using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.DataAccess.UnitOfWork;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.DayDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.ScheduleInformationDtos;
using HK.VocationalSchoolAutomason.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Services
{
    public class ScheduleInformationService : IScheduleInformation
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<ScheduleInformationCreateDto> _createValidator;
        private readonly IValidator<ScheduleInformationUpdateDto> _updateValidator;

        public ScheduleInformationService(IUow uow, IMapper mapper, IValidator<ScheduleInformationCreateDto> createValidator, IValidator<ScheduleInformationUpdateDto> updateValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<ScheduleInformationCreateDto>> Create(ScheduleInformationCreateDto dto)
        {
            var ValidationResult = _createValidator.Validate(dto);
            if (ValidationResult.IsValid)
            {
                await _uow.GetRepository<ScheduleInformation>().Create(_mapper.Map<ScheduleInformation>(dto));
                await _uow.SaveChanges();

                return new Response<ScheduleInformationCreateDto>(ResponseType.Success, dto);
            }



            else
            {

                return new Response<ScheduleInformationCreateDto>(ResponseType.ValidationError, dto, ValidationResult.CovertToCustomValidationError());
            }
        }

        public async Task<IResponse<List<ScheduleInformationListDto>>> GetAllStudents()
        {
            var data = _mapper.Map<List<ScheduleInformationListDto>>(await _uow.GetRepository<Day>().GetAll());

            return new Response<List<ScheduleInformationListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<ScheduleInformation>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var deletedEntity = await _uow.GetRepository<ScheduleInformation>().GetByFilter(x => x.Id == id);
            if (deletedEntity != null)
            {
                _uow.GetRepository<ScheduleInformation>().Remove(deletedEntity);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            else
            {
                return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
        }

        public async Task<IResponse<ScheduleInformationUpdateDto>> Update(ScheduleInformationUpdateDto dto)
        {
            var result = _updateValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<ScheduleInformation>().Find(dto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<ScheduleInformation>().Update(_mapper.Map<ScheduleInformation>(dto), updatedEntity);
                    _uow.SaveChanges();

                    return new Response<ScheduleInformationUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<ScheduleInformationUpdateDto>(ResponseType.NotFound, $"{dto.Id} ait data bulunamadı");

            }
            else
            {
                return new Response<ScheduleInformationUpdateDto>(ResponseType.ValidationError, dto, result.CovertToCustomValidationError());
            }
        }
    }
}
