using AutoMapper;
using FluentValidation;
using HK.VocationalSchoolAutomason.Bussiness.Extensions;
using HK.VocationalSchoolAutomason.Bussiness.Interfaces;
using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.DataAccess.UnitOfWork;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.DayDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.GradeSystemDtos;
using HK.VocationalSchoolAutomason.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Services
{
    public class GradeSystemService : IGradeSystem
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<GradeSystemCreateDto> _createValidator;
        private readonly IValidator<GradeSystemUpdateDto> _updateValidator;

        public GradeSystemService(IUow uow, IMapper mapper, IValidator<GradeSystemCreateDto> createValidator, IValidator<GradeSystemUpdateDto> updateValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<GradeSystemCreateDto>> Create(GradeSystemCreateDto dto)
        {
            var ValidationResult = _createValidator.Validate(dto);
            if (ValidationResult.IsValid)
            {
                await _uow.GetRepository<GradeSystem>().Create(_mapper.Map<GradeSystem>(dto));
                await _uow.SaveChanges();

                return new Response<GradeSystemCreateDto>(ResponseType.Success, dto);
            }



            else
            {

                return new Response<GradeSystemCreateDto>(ResponseType.ValidationError, dto, ValidationResult.CovertToCustomValidationError());
            }
        }

        public async Task<IResponse<List<GradeSystemListDto>>> GetAllStudents()
        {
            var data = _mapper.Map<List<GradeSystemListDto>>(await _uow.GetRepository<GradeSystem>().GetAll());

            return new Response<List<GradeSystemListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<GradeSystem>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var deletedEntity = await _uow.GetRepository<GradeSystem>().GetByFilter(x => x.Id == id);
            if (deletedEntity != null)
            {
                _uow.GetRepository<GradeSystem>().Remove(deletedEntity);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            else
            {
                return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
        }

        public async Task<IResponse<GradeSystemUpdateDto>> Update(GradeSystemUpdateDto dto)
        {
            var result = _updateValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<GradeSystem>().Find(dto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<GradeSystem>().Update(_mapper.Map<GradeSystem>(dto), updatedEntity);
                    _uow.SaveChanges();

                    return new Response<GradeSystemUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<GradeSystemUpdateDto>(ResponseType.NotFound, $"{dto.Id} ait data bulunamadı");

            }
            else
            {
                return new Response<GradeSystemUpdateDto>(ResponseType.ValidationError, dto, result.CovertToCustomValidationError());
            }
        }
    }
}
