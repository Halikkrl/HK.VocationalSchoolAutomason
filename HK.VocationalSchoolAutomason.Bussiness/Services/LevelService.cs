using AutoMapper;
using FluentValidation;
using HK.VocationalSchoolAutomason.Bussiness.Extensions;
using HK.VocationalSchoolAutomason.Bussiness.Interfaces;
using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.DataAccess.UnitOfWork;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.GroupDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.LevelDtos;
using HK.VocationalSchoolAutomason.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Services
{
    public class LevelService : ILevel
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<LevelCreateDto> _createValidator;
        private readonly IValidator<LevelUpdateDto> _updateValidator;

        public LevelService(IUow uow, IMapper mapper, IValidator<LevelCreateDto> createValidator, IValidator<LevelUpdateDto> updateValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<LevelCreateDto>> Create(LevelCreateDto dto)
        {
            var ValidationResult = _createValidator.Validate(dto);
            if (ValidationResult.IsValid)
            {
                await _uow.GetRepository<Levels>().Create(_mapper.Map<Levels>(dto));
                await _uow.SaveChanges();

                return new Response<LevelCreateDto>(ResponseType.Success, dto);
            }



            else
            {

                return new Response<LevelCreateDto>(ResponseType.ValidationError, dto, ValidationResult.CovertToCustomValidationError());
            }
        }

        public async Task<IResponse<List<LevelListDto>>> GetAllStudents()
        {
            var data = _mapper.Map<List<LevelListDto>>(await _uow.GetRepository<Levels>().GetAll());

            return new Response<List<LevelListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<Levels>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var deletedEntity = await _uow.GetRepository<Levels>().GetByFilter(x => x.Id == id);
            if (deletedEntity != null)
            {
                _uow.GetRepository<Levels>().Remove(deletedEntity);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            else
            {
                return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
        }

        public async Task<IResponse<LevelUpdateDto>> Update(LevelUpdateDto dto)
        {
            var result = _updateValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<Levels>().Find(dto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<Levels>().Update(_mapper.Map<Levels>(dto), updatedEntity);
                    _uow.SaveChanges();

                    return new Response<LevelUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<LevelUpdateDto>(ResponseType.NotFound, $"{dto.Id} ait data bulunamadı");

            }
            else
            {
                return new Response<LevelUpdateDto>(ResponseType.ValidationError, dto, result.CovertToCustomValidationError());
            }
        }
    }
}
