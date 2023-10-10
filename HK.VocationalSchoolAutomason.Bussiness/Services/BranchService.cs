using AutoMapper;
using FluentValidation;
using HK.VocationalSchoolAutomason.Bussiness.Extensions;
using HK.VocationalSchoolAutomason.Bussiness.Interfaces;
using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.DataAccess.UnitOfWork;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.BranchDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.DayDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.DutiesDtos;
using HK.VocationalSchoolAutomason.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Services
{
    public class BranchService : IBranch
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<BranchCreateDto> _createValidator;
        private readonly IValidator<BranchUpdatedto> _updateValidator;

        public BranchService(IUow uow, IMapper mapper, IValidator<BranchCreateDto> createValidator, IValidator<BranchUpdatedto> updateValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<BranchCreateDto>> Create(BranchCreateDto dto)
        {
            var ValidationResult = _createValidator.Validate(dto);
            if (ValidationResult.IsValid)
            {
                await _uow.GetRepository<Branch>().Create(_mapper.Map<Branch>(dto));
                await _uow.SaveChanges();

                return new Response<BranchCreateDto>(ResponseType.Success, dto);
            }



            else
            {

                return new Response<BranchCreateDto>(ResponseType.ValidationError, dto, ValidationResult.CovertToCustomValidationError());
            }
        }

        public async Task<IResponse<List<BranchListDto>>> GetAllStudents()
        {
            var data = _mapper.Map<List<BranchListDto>>(await _uow.GetRepository<Branch>().GetAll());

            return new Response<List<BranchListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<Branch>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var deletedEntity = await _uow.GetRepository<Branch>().GetByFilter(x => x.Id == id);
            if (deletedEntity != null)
            {
                _uow.GetRepository<Branch>().Remove(deletedEntity);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            else
            {
                return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
        }

        public async Task<IResponse<BranchUpdatedto>> Update(BranchUpdatedto dto)
        {
            var result = _updateValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<Branch>().Find(dto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<Branch>().Update(_mapper.Map<Branch>(dto), updatedEntity);
                    _uow.SaveChanges();

                    return new Response<BranchUpdatedto>(ResponseType.Success, dto);
                }
                return new Response<BranchUpdatedto>(ResponseType.NotFound, $"{dto.Id} ait data bulunamadı");

            }
            else
            {
                return new Response<BranchUpdatedto>(ResponseType.ValidationError, dto, result.CovertToCustomValidationError());
            }
        }
    }
}
