using AutoMapper;
using FluentValidation;
using HK.VocationalSchoolAutomason.Bussiness.Extensions;
using HK.VocationalSchoolAutomason.Bussiness.Interfaces;
using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.DataAccess.UnitOfWork;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.CourseBranchDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.DayDtos;
using HK.VocationalSchoolAutomason.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Services
{
    public class CourseBranchService : ICourseBranch
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<CourseBranchCreateDto> _createValidator;
        private readonly IValidator<CourseBranchUpdateDto> _updateValidator;

        public CourseBranchService(IUow uow, IMapper mapper, IValidator<CourseBranchCreateDto> createValidator, IValidator<CourseBranchUpdateDto> updateValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<CourseBranchCreateDto>> Create(CourseBranchCreateDto dto)
        {
            var ValidationResult = _createValidator.Validate(dto);
            if (ValidationResult.IsValid)
            {
                await _uow.GetRepository<CourseBranch>().Create(_mapper.Map<CourseBranch>(dto));
                await _uow.SaveChanges();

                return new Response<CourseBranchCreateDto>(ResponseType.Success, dto);
            }



            else
            {

                return new Response<CourseBranchCreateDto>(ResponseType.ValidationError, dto, ValidationResult.CovertToCustomValidationError());
            }
        }

        public async Task<IResponse<List<CourseBranchListDto>>> GetAllStudents()
        {
            var data = _mapper.Map<List<CourseBranchListDto>>(await _uow.GetRepository<CourseBranch>().GetAll());

            return new Response<List<CourseBranchListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<CourseBranch>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var deletedEntity = await _uow.GetRepository<CourseBranch>().GetByFilter(x => x.Id == id);
            if (deletedEntity != null)
            {
                _uow.GetRepository<CourseBranch>().Remove(deletedEntity);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            else
            {
                return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
        }

        public async Task<IResponse<CourseBranchUpdateDto>> Update(CourseBranchUpdateDto dto)
        {
            var result = _updateValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<CourseBranch>().Find(dto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<CourseBranch>().Update(_mapper.Map<CourseBranch>(dto), updatedEntity);
                    _uow.SaveChanges();

                    return new Response<CourseBranchUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<CourseBranchUpdateDto>(ResponseType.NotFound, $"{dto.Id} ait data bulunamadı");

            }
            else
            {
                return new Response<CourseBranchUpdateDto>(ResponseType.ValidationError, dto, result.CovertToCustomValidationError());
            }
        }
    }
}
