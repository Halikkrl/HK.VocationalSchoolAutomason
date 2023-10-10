using AutoMapper;
using FluentValidation;
using HK.VocationalSchoolAutomason.Bussiness.Extensions;
using HK.VocationalSchoolAutomason.Bussiness.Interfaces;
using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.DataAccess.UnitOfWork;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeDutyDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.GroupDtos;
using HK.VocationalSchoolAutomason.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Services
{
    public class GroupService : IGroup
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<GroupCreateDto> _createValidator;
        private readonly IValidator<GroupUpdateDto> _updateValidator;

        public GroupService(IUow uow, IMapper mapper, IValidator<GroupCreateDto> createValidator, IValidator<GroupUpdateDto> updateValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<GroupCreateDto>> Create(GroupCreateDto dto)
        {
            var ValidationResult = _createValidator.Validate(dto);
            if (ValidationResult.IsValid)
            {
                await _uow.GetRepository<Groups>().Create(_mapper.Map<Groups>(dto));
                await _uow.SaveChanges();

                return new Response<GroupCreateDto>(ResponseType.Success, dto);
            }



            else
            {

                return new Response<GroupCreateDto>(ResponseType.ValidationError, dto, ValidationResult.CovertToCustomValidationError());
            }
        }

        public async Task<IResponse<List<GroupListDto>>> GetAllStudents()
        {
            var data = _mapper.Map<List<GroupListDto>>(await _uow.GetRepository<Groups>().GetAll());

            return new Response<List<GroupListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<Groups>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var deletedEntity = await _uow.GetRepository<Groups>().GetByFilter(x => x.Id == id);
            if (deletedEntity != null)
            {
                _uow.GetRepository<Groups>().Remove(deletedEntity);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            else
            {
                return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
        }

        public async Task<IResponse<GroupUpdateDto>> Update(GroupUpdateDto dto)
        {
            var result = _updateValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<Groups>().Find(dto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<Groups>().Update(_mapper.Map<Groups>(dto), updatedEntity);
                    _uow.SaveChanges();

                    return new Response<GroupUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<GroupUpdateDto>(ResponseType.NotFound, $"{dto.Id} ait data bulunamadı");

            }
            else
            {
                return new Response<GroupUpdateDto>(ResponseType.ValidationError, dto, result.CovertToCustomValidationError());
            }
        }
    }
}
