using AutoMapper;
using FluentValidation;
using HK.VocationalSchoolAutomason.Bussiness.Extensions;
using HK.VocationalSchoolAutomason.Bussiness.Interfaces;
using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.DataAccess.UnitOfWork;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.LevelDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.MajorDtos;
using HK.VocationalSchoolAutomason.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Services
{
    public class MajorService : IMajor
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<MajorCreateDto> _createValidator;
        private readonly IValidator<MajorUpdateDto> _updateValidator;

        public MajorService(IUow uow, IMapper mapper, IValidator<MajorCreateDto> createValidator, IValidator<MajorUpdateDto> updateValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<MajorCreateDto>> Create(MajorCreateDto dto)
        {
            var ValidationResult = _createValidator.Validate(dto);
            if (ValidationResult.IsValid)
            {
                await _uow.GetRepository<Majors>().Create(_mapper.Map<Majors>(dto));
                await _uow.SaveChanges();

                return new Response<MajorCreateDto>(ResponseType.Success, dto);
            }



            else
            {

                return new Response<MajorCreateDto>(ResponseType.ValidationError, dto, ValidationResult.CovertToCustomValidationError());
            }
        }

        public async Task<IResponse<List<MajorListDto>>> GetAllStudents()
        {
            var data = _mapper.Map<List<MajorListDto>>(await _uow.GetRepository<Majors>().GetAll());

            return new Response<List<MajorListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<Majors>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var deletedEntity = await _uow.GetRepository<Majors>().GetByFilter(x => x.Id == id);
            if (deletedEntity != null)
            {
                _uow.GetRepository<Majors>().Remove(deletedEntity);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            else
            {
                return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
        }

        public async Task<IResponse<MajorUpdateDto>> Update(MajorUpdateDto dto)
        {
            var result = _updateValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<Majors>().Find(dto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<Majors>().Update(_mapper.Map<Majors>(dto), updatedEntity);
                    _uow.SaveChanges();

                    return new Response<MajorUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<MajorUpdateDto>(ResponseType.NotFound, $"{dto.Id} ait data bulunamadı");

            }
            else
            {
                return new Response<MajorUpdateDto>(ResponseType.ValidationError, dto, result.CovertToCustomValidationError());
            }
        }
    }
}
