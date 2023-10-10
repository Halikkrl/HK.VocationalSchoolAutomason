using AutoMapper;
using FluentValidation;
using HK.VocationalSchoolAutomason.Bussiness.Extensions;
using HK.VocationalSchoolAutomason.Bussiness.Interfaces;
using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.DataAccess.UnitOfWork;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.Parent_Information;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.StudentDtos;
using HK.VocationalSchoolAutomason.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Services
{
    public class Parent_InformationService : IParent_Information
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<Parent_InformationCreate> _createValidator;
        private readonly IValidator<Parent_InformationUpdate> _updateValidator;

        public Parent_InformationService(IUow uow, IMapper mapper, IValidator<Parent_InformationCreate> createValidator, IValidator<Parent_InformationUpdate> updateValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<Parent_InformationCreate>> Create(Parent_InformationCreate dto)
        {
            var ValidationResult = _createValidator.Validate(dto);
            if (ValidationResult.IsValid)
            {
                await _uow.GetRepository<Parent_Information>().Create(_mapper.Map<Parent_Information>(dto));
                await _uow.SaveChanges();

                return new Response<Parent_InformationCreate>(ResponseType.Success, dto);
            }

            else
            {

                return new Response<Parent_InformationCreate>(ResponseType.ValidationError, dto, ValidationResult.CovertToCustomValidationError());
            }
        }

        public async Task<IResponse<List<Parent_InformationList>>> GetAllStudents()
        {
            var data = _mapper.Map<List<Parent_InformationList>>(await _uow.GetRepository<Parent_Information>().GetAll());

            return new Response<List<Parent_InformationList>>(ResponseType.Success, data);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<Parent_Information>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var deletedEntity = await _uow.GetRepository<Parent_Information>().GetByFilter(x => x.Id == id);
            if (deletedEntity != null)
            {
                _uow.GetRepository<Parent_Information>().Remove(deletedEntity);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            else
            {
                return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
        }

        public async Task<IResponse<Parent_InformationUpdate>> Update(Parent_InformationUpdate dto)
        {
            var result = _updateValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<Parent_Information>().Find(dto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<Parent_Information>().Update(_mapper.Map<Parent_Information>(dto), updatedEntity);
                    _uow.SaveChanges();

                    return new Response<Parent_InformationUpdate>(ResponseType.Success, dto);
                }
                return new Response<Parent_InformationUpdate>(ResponseType.NotFound, $"{dto.Id} ait data bulunamadı");

            }
            else
            {
                return new Response<Parent_InformationUpdate>(ResponseType.ValidationError, dto, result.CovertToCustomValidationError());
            }
        }
    }
}
