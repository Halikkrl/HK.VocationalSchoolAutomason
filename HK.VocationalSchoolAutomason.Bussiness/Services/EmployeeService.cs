using AutoMapper;
using FluentValidation;
using HK.VocationalSchoolAutomason.Bussiness.Extensions;
using HK.VocationalSchoolAutomason.Bussiness.Interfaces;
using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.DataAccess.UnitOfWork;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeDtos;
using HK.VocationalSchoolAutomason.Entities.Domains;

namespace HK.VocationalSchoolAutomason.Bussiness.Services
{
    public class EmployeeService : IEmployee
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<EmployeeCreateDto> _createValidator;
        private readonly IValidator<EmployeeUpdateDto> _updateValidator;

        public EmployeeService(IUow uow, IMapper mapper, IValidator<EmployeeCreateDto> createValidator, IValidator<EmployeeUpdateDto> updateValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<EmployeeCreateDto>> Create(EmployeeCreateDto dto)
        {
            var ValidationResult = _createValidator.Validate(dto);
            if (ValidationResult.IsValid)
            {
                await _uow.GetRepository<Employee>().Create(_mapper.Map<Employee>(dto));
                await _uow.SaveChanges();

                return new Response<EmployeeCreateDto>(ResponseType.Success, dto);
            }



            else
            {

                return new Response<EmployeeCreateDto>(ResponseType.ValidationError, dto, ValidationResult.CovertToCustomValidationError());
            }
        }

        public async Task<IResponse<List<EmployeeListDto>>> GetAllStudents()
        {
            var data = _mapper.Map<List<EmployeeListDto>>(await _uow.GetRepository<Employee>().GetAll());

            return new Response<List<EmployeeListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<Employee>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var deletedEntity = await _uow.GetRepository<Employee>().GetByFilter(x => x.Id == id);
            if (deletedEntity != null)
            {
                _uow.GetRepository<Employee>().Remove(deletedEntity);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            else
            {
                return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
        }

        public async Task<IResponse<EmployeeUpdateDto>> Update(EmployeeUpdateDto dto)
        {
            var result = _updateValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<Employee>().Find(dto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<Employee>().Update(_mapper.Map<Employee>(dto), updatedEntity);
                    _uow.SaveChanges();

                    return new Response<EmployeeUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<EmployeeUpdateDto>(ResponseType.NotFound, $"{dto.Id} ait data bulunamadı");

            }
            else
            {
                return new Response<EmployeeUpdateDto>(ResponseType.ValidationError, dto, result.CovertToCustomValidationError());
            }
        }
    }
}
