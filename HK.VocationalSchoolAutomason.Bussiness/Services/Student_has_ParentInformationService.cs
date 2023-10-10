using AutoMapper;
using FluentValidation;
using HK.VocationalSchoolAutomason.Bussiness.Extensions;
using HK.VocationalSchoolAutomason.Bussiness.Interfaces;
using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.DataAccess.UnitOfWork;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.Parent_Information;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.Student_has_ParentInformation;
using HK.VocationalSchoolAutomason.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Services
{


    public class Student_has_ParentInformationService : IStudent_has_ParentInformation
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<Student_has_ParentInformationCreate> _createValidator;
        private readonly IValidator<Student_has_ParentInformationUpdate> _updateValidator;

        public Student_has_ParentInformationService(IUow uow, IMapper mapper, IValidator<Student_has_ParentInformationCreate> createValidator, IValidator<Student_has_ParentInformationUpdate> updateValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<Student_has_ParentInformationCreate>> Create(Student_has_ParentInformationCreate dto)
        {
            var ValidationResult = _createValidator.Validate(dto);
            if (ValidationResult.IsValid)
            {
                await _uow.GetRepository<Student_has_ParentInformation>().Create(_mapper.Map<Student_has_ParentInformation>(dto));
                await _uow.SaveChanges();

                return new Response<Student_has_ParentInformationCreate>(ResponseType.Success, dto);
            }

            

            else
            {

                return new Response<Student_has_ParentInformationCreate>(ResponseType.ValidationError, dto, ValidationResult.CovertToCustomValidationError());
            }
        }

        public async Task<IResponse<List<Student_has_ParentInformationList>>> GetAllStudents()
        {
            var data = _mapper.Map<List<Student_has_ParentInformationList>>(await _uow.GetRepository<Student_has_ParentInformation>().GetAll());

            return new Response<List<Student_has_ParentInformationList>>(ResponseType.Success, data);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<Student_has_ParentInformation>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var deletedEntity = await _uow.GetRepository<Student_has_ParentInformation>().GetByFilter(x => x.Id == id);
            if (deletedEntity != null)
            {
                _uow.GetRepository<Student_has_ParentInformation>().Remove(deletedEntity);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            else
            {
                return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
        }

        public async Task<IResponse<Student_has_ParentInformationUpdate>> Update(Student_has_ParentInformationUpdate dto)
        {
            var result = _updateValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<Student_has_ParentInformation>().Find(dto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<Student_has_ParentInformation>().Update(_mapper.Map<Student_has_ParentInformation>(dto), updatedEntity);
                    _uow.SaveChanges();

                    return new Response<Student_has_ParentInformationUpdate>(ResponseType.Success, dto);
                }
                return new Response<Student_has_ParentInformationUpdate>(ResponseType.NotFound, $"{dto.Id} ait data bulunamadı");

            }
            else
            {
                return new Response<Student_has_ParentInformationUpdate>(ResponseType.ValidationError, dto, result.CovertToCustomValidationError());
            }
        }
    }
}
