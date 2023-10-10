using AutoMapper;
using FluentValidation;
using HK.VocationalSchoolAutomason.Bussiness.Extensions;
using HK.VocationalSchoolAutomason.Bussiness.Interfaces;
using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.DataAccess.UnitOfWork;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.GroupDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.LevelGroupMajorDtos;
using HK.VocationalSchoolAutomason.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Services
{
    public class LevelGroupMajorService : ILevelGroupMajor
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<LevelGroupMajorCreateDto> _createValidator;
        private readonly IValidator<LevelGroupMajorUpdateDto> _updateValidator;

        public LevelGroupMajorService(IUow uow, IMapper mapper, IValidator<LevelGroupMajorCreateDto> createValidator, IValidator<LevelGroupMajorUpdateDto> updateValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<LevelGroupMajorCreateDto>> Create(LevelGroupMajorCreateDto dto)
        {
            var ValidationResult = _createValidator.Validate(dto);
            if (ValidationResult.IsValid)
            {
                await _uow.GetRepository<LevelGruopMojor>().Create(_mapper.Map<LevelGruopMojor>(dto));
                await _uow.SaveChanges();

                return new Response<LevelGroupMajorCreateDto>(ResponseType.Success, dto);
            }



            else
            {

                return new Response<LevelGroupMajorCreateDto>(ResponseType.ValidationError, dto, ValidationResult.CovertToCustomValidationError());
            }
        }

        public async Task<IResponse<List<LevelGroupMajorListDto>>> GetAllStudents()
        {
            var data = _mapper.Map<List<LevelGroupMajorListDto>>(await _uow.GetRepository<LevelGruopMojor>().GetAll());

            return new Response<List<LevelGroupMajorListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<LevelGruopMojor>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var deletedEntity = await _uow.GetRepository<LevelGruopMojor>().GetByFilter(x => x.Id == id);
            if (deletedEntity != null)
            {
                _uow.GetRepository<LevelGruopMojor>().Remove(deletedEntity);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            else
            {
                return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
        }

        public async Task<IResponse<LevelGroupMajorUpdateDto>> Update(LevelGroupMajorUpdateDto dto)
        {
            var result = _updateValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<LevelGruopMojor>().Find(dto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<LevelGruopMojor>().Update(_mapper.Map<LevelGruopMojor>(dto), updatedEntity);
                    _uow.SaveChanges();

                    return new Response<LevelGroupMajorUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<LevelGroupMajorUpdateDto>(ResponseType.NotFound, $"{dto.Id} ait data bulunamadı");

            }
            else
            {
                return new Response<LevelGroupMajorUpdateDto>(ResponseType.ValidationError, dto, result.CovertToCustomValidationError());
            }
        }
    }
}
