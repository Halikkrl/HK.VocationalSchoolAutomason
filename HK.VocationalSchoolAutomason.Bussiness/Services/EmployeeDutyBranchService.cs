using AutoMapper;
using FluentValidation;
using HK.VocationalSchoolAutomason.Bussiness.Extensions;
using HK.VocationalSchoolAutomason.Bussiness.Interfaces;
using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.DataAccess.UnitOfWork;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.DutiesDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeDutyBranchDtos;
using HK.VocationalSchoolAutomason.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Services
{
    public class EmployeeDutyBranchService : IEmployeeDutyBranch
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<EmployeeDutyBranchCreateDto> _createValidator;
        private readonly IValidator<EmployeeDutyBranchUpdateDto> _updateValidator;

        public EmployeeDutyBranchService(IUow uow, IMapper mapper, IValidator<EmployeeDutyBranchCreateDto> createValidator, IValidator<EmployeeDutyBranchUpdateDto> updateValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<EmployeeDutyBranchCreateDto>> Create(EmployeeDutyBranchCreateDto dto)
        {
            var ValidationResult = _createValidator.Validate(dto);
            if (ValidationResult.IsValid)
            {
                await _uow.GetRepository<EmployeeDutyBranch>().Create(_mapper.Map<EmployeeDutyBranch>(dto));
                await _uow.SaveChanges();

                return new Response<EmployeeDutyBranchCreateDto>(ResponseType.Success, dto);
            }



            else
            {

                return new Response<EmployeeDutyBranchCreateDto>(ResponseType.ValidationError, dto, ValidationResult.CovertToCustomValidationError());
            }
        }

        public async Task<IResponse<List<EmployeeDutyBranchListDto>>> GetAllStudents()
        {
            var data = _mapper.Map<List<EmployeeDutyBranchListDto>>(await _uow.GetRepository<EmployeeDutyBranch>().GetAll());

            return new Response<List<EmployeeDutyBranchListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<EmployeeDutyBranch>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var deletedEntity = await _uow.GetRepository<EmployeeDutyBranch>().GetByFilter(x => x.Id == id);
            if (deletedEntity != null)
            {
                _uow.GetRepository<EmployeeDutyBranch>().Remove(deletedEntity);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            else
            {
                return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
        }

        public async Task<IResponse<EmployeeDutyBranchUpdateDto>> Update(EmployeeDutyBranchUpdateDto dto)
        {
            var result = _updateValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<EmployeeDutyBranch>().Find(dto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<EmployeeDutyBranch>().Update(_mapper.Map<EmployeeDutyBranch>(dto), updatedEntity);
                    _uow.SaveChanges();

                    return new Response<EmployeeDutyBranchUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<EmployeeDutyBranchUpdateDto>(ResponseType.NotFound, $"{dto.Id} ait data bulunamadı");

            }
            else
            {
                return new Response<EmployeeDutyBranchUpdateDto>(ResponseType.ValidationError, dto, result.CovertToCustomValidationError());
            }
        }
    }
}
