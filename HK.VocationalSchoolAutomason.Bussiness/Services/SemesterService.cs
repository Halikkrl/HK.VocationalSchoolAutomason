using AutoMapper;
using FluentValidation;
using HK.VocationalSchoolAutomason.Bussiness.Extensions;
using HK.VocationalSchoolAutomason.Bussiness.Interfaces;
using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.DataAccess.UnitOfWork;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.DayDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.SemesterDtos;
using HK.VocationalSchoolAutomason.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Services
{
    public class SemesterService : ISemester
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<SemesterCreateDto> _createValidator;
        private readonly IValidator<SemesterUpdateDto> _updateValidator;

        public SemesterService(IUow uow, IMapper mapper, IValidator<SemesterCreateDto> createValidator, IValidator<SemesterUpdateDto> updateValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<SemesterCreateDto>> Create(SemesterCreateDto dto)
        {
            var ValidationResult = _createValidator.Validate(dto);
            if (ValidationResult.IsValid)
            {
                await _uow.GetRepository<Semester>().Create(_mapper.Map<Semester>(dto));
                await _uow.SaveChanges();

                return new Response<SemesterCreateDto>(ResponseType.Success, dto);
            }



            else
            {

                return new Response<SemesterCreateDto>(ResponseType.ValidationError, dto, ValidationResult.CovertToCustomValidationError());
            }
        }

        public async Task<IResponse<List<SemesterListDto>>> GetAllStudents()
        {
            var data = _mapper.Map<List<SemesterListDto>>(await _uow.GetRepository<Semester>().GetAll());

            return new Response<List<SemesterListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<Semester>().GetByFilter(x => x.Id == id));
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

        public async Task<IResponse<SemesterUpdateDto>> Update(SemesterUpdateDto dto)
        {
            var result = _updateValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<Semester>().Find(dto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<Semester>().Update(_mapper.Map<Semester>(dto), updatedEntity);
                    _uow.SaveChanges();

                    return new Response<SemesterUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<SemesterUpdateDto>(ResponseType.NotFound, $"{dto.Id} ait data bulunamadı");

            }
            else
            {
                return new Response<SemesterUpdateDto>(ResponseType.ValidationError, dto, result.CovertToCustomValidationError());
            }
        }
    }
}
