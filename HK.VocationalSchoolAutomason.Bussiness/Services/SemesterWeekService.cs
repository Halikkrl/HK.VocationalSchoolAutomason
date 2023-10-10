using AutoMapper;
using FluentValidation;
using HK.VocationalSchoolAutomason.Bussiness.Extensions;
using HK.VocationalSchoolAutomason.Bussiness.Interfaces;
using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.DataAccess.UnitOfWork;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.DayDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.SemesterDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.SemesterWeekDtos;
using HK.VocationalSchoolAutomason.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Services
{
    public class SemesterWeekService : ISemesterWeek
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<SemesterWeekCreateDto> _createValidator;
        private readonly IValidator<SemesterWeekUpdateDto> _updateValidator;

        public SemesterWeekService(IUow uow, IMapper mapper, IValidator<SemesterWeekCreateDto> createValidator, IValidator<SemesterWeekUpdateDto> updateValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<SemesterWeekCreateDto>> Create(SemesterWeekCreateDto dto)
        {
            var ValidationResult = _createValidator.Validate(dto);
            if (ValidationResult.IsValid)
            {
                await _uow.GetRepository<SemesterWeek>().Create(_mapper.Map<SemesterWeek>(dto));
                await _uow.SaveChanges();

                return new Response<SemesterWeekCreateDto>(ResponseType.Success, dto);
            }



            else
            {

                return new Response<SemesterWeekCreateDto>(ResponseType.ValidationError, dto, ValidationResult.CovertToCustomValidationError());
            }
        }

        public async Task<IResponse<List<SemesterWeekListDto>>> GetAllStudents()
        {
            var data = _mapper.Map<List<SemesterWeekListDto>>(await _uow.GetRepository<SemesterWeek>().GetAll());

            return new Response<List<SemesterWeekListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<SemesterWeek>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var deletedEntity = await _uow.GetRepository<Semester>().GetByFilter(x => x.Id == id);
            if (deletedEntity != null)
            {
                _uow.GetRepository<Semester>().Remove(deletedEntity);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            else
            {
                return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
        }

        public async Task<IResponse<SemesterWeekUpdateDto>> Update(SemesterWeekUpdateDto dto)
        {
            var result = _updateValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<SemesterWeek>().Find(dto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<SemesterWeek>().Update(_mapper.Map<SemesterWeek>(dto), updatedEntity);
                    _uow.SaveChanges();

                    return new Response<SemesterWeekUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<SemesterWeekUpdateDto>(ResponseType.NotFound, $"{dto.Id} ait data bulunamadı");

            }
            else
            {
                return new Response<SemesterWeekUpdateDto>(ResponseType.ValidationError, dto, result.CovertToCustomValidationError());
            }
        }
    }
}
