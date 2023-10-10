using AutoMapper;
using FluentValidation;
using HK.VocationalSchoolAutomason.Bussiness.Extensions;
using HK.VocationalSchoolAutomason.Bussiness.Interfaces;
using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.DataAccess.UnitOfWork;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.ClassRoomsDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.DayDtos;
using HK.VocationalSchoolAutomason.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Services
{
    public class ClassRoomService : IClassRoom
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<ClassRoomCreateDto> _createValidator;
        private readonly IValidator<ClassRoomUpdateDto> _updateValidator;

        public ClassRoomService(IUow uow, IMapper mapper, IValidator<ClassRoomCreateDto> createValidator, IValidator<ClassRoomUpdateDto> updateValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<ClassRoomCreateDto>> Create(ClassRoomCreateDto dto)
        {
            var ValidationResult = _createValidator.Validate(dto);
            if (ValidationResult.IsValid)
            {
                await _uow.GetRepository<ClassRoom>().Create(_mapper.Map<ClassRoom>(dto));
                await _uow.SaveChanges();

                return new Response<ClassRoomCreateDto>(ResponseType.Success, dto);
            }



            else
            {

                return new Response<ClassRoomCreateDto>(ResponseType.ValidationError, dto, ValidationResult.CovertToCustomValidationError());
            }
        }

        public async Task<IResponse<List<ClassRoomListDto>>> GetAllStudents()
        {
            var data = _mapper.Map<List<ClassRoomListDto>>(await _uow.GetRepository<ClassRoom>().GetAll());

            return new Response<List<ClassRoomListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<ClassRoom>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var deletedEntity = await _uow.GetRepository<ClassRoom>().GetByFilter(x => x.Id == id);
            if (deletedEntity != null)
            {
                _uow.GetRepository<ClassRoom>().Remove(deletedEntity);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            else
            {
                return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
        }

        public async Task<IResponse<ClassRoomUpdateDto>> Update(ClassRoomUpdateDto dto)
        {
            var result = _updateValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<ClassRoom>().Find(dto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<ClassRoom>().Update(_mapper.Map<ClassRoom>(dto), updatedEntity);
                    _uow.SaveChanges();

                    return new Response<ClassRoomUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<ClassRoomUpdateDto>(ResponseType.NotFound, $"{dto.Id} ait data bulunamadı");

            }
            else
            {
                return new Response<ClassRoomUpdateDto>(ResponseType.ValidationError, dto, result.CovertToCustomValidationError());
            }
        }
    }
}
