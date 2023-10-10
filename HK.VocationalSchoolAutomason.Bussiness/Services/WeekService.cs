using AutoMapper;
using FluentValidation;
using HK.VocationalSchoolAutomason.Bussiness.Extensions;
using HK.VocationalSchoolAutomason.Bussiness.Interfaces;
using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.DataAccess.UnitOfWork;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.DayDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.WeeksDtos;
using HK.VocationalSchoolAutomason.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Services
{
    public class WeekService : IWeek
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<WeeKCreateDto> _createValidator;
        private readonly IValidator<WeekUpdateDto> _updateValidator;

        public WeekService(IUow uow, IMapper mapper, IValidator<WeeKCreateDto> createValidator, IValidator<WeekUpdateDto> updateValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<WeeKCreateDto>> Create(WeeKCreateDto dto)
        {
            var ValidationResult = _createValidator.Validate(dto);
            if (ValidationResult.IsValid)
            {
                await _uow.GetRepository<Weeks>().Create(_mapper.Map<Weeks>(dto));
                await _uow.SaveChanges();

                return new Response<WeeKCreateDto>(ResponseType.Success, dto);
            }



            else
            {

                return new Response<WeeKCreateDto>(ResponseType.ValidationError, dto, ValidationResult.CovertToCustomValidationError());
            }
        }

        public async Task<IResponse<List<WeekListDto>>> GetAllStudents()
        {
            var data = _mapper.Map<List<WeekListDto>>(await _uow.GetRepository<Weeks>().GetAll());

            return new Response<List<WeekListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<Weeks>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var deletedEntity = await _uow.GetRepository<Weeks>().GetByFilter(x => x.Id == id);
            if (deletedEntity != null)
            {
                _uow.GetRepository<Weeks>().Remove(deletedEntity);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            else
            {
                return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
        }

        public async Task<IResponse<WeekUpdateDto>> Update(WeekUpdateDto dto)
        {
            var result = _updateValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<Weeks>().Find(dto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<Weeks>().Update(_mapper.Map<Weeks>(dto), updatedEntity);
                    _uow.SaveChanges();

                    return new Response<WeekUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<WeekUpdateDto>(ResponseType.NotFound, $"{dto.Id} ait data bulunamadı");

            }
            else
            {
                return new Response<WeekUpdateDto>(ResponseType.ValidationError, dto, result.CovertToCustomValidationError());
            }
        }
    }
}
