using AutoMapper;
using FluentValidation;
using HK.VocationalSchoolAutomason.Bussiness.Extensions;
using HK.VocationalSchoolAutomason.Bussiness.Interfaces;
using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.DataAccess.UnitOfWork;
using HK.VocationalSchoolAutomason.Dtos.Interfaces;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.StudentDtos;
using HK.VocationalSchoolAutomason.Entities.Domains;

namespace HK.VocationalSchoolAutomason.Bussiness.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<StudentCreateDto> _createValidator;
        private readonly IValidator<StudentUpdateDto> _updateValidator;

        public StudentService(IUow uow, IMapper mapper, IValidator<StudentCreateDto> createValidator, IValidator<StudentUpdateDto> updateValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<StudentCreateDto>> Create(StudentCreateDto dto)
        {
            var ValidationResult = _createValidator.Validate(dto);
            if(ValidationResult.IsValid)
            {
                await _uow.GetRepository<Students>().Create(_mapper.Map<Students>(dto));
                await _uow.SaveChanges();

                return new Response<StudentCreateDto>(ResponseType.Success,dto);
            }
            
            else
            {
                return new Response<StudentCreateDto>(ResponseType.ValidationError, dto, ValidationResult.CovertToCustomValidationError());
            }
        }
        



        public async Task<IResponse<List<StudentListDto>>> GetAllStudents()
        {
            var data = _mapper.Map<List<StudentListDto>>(await _uow.GetRepository<Students>().GetAll());
            if(data != null)
            {
                return new Response<List<StudentListDto>>(ResponseType.Success, data);
                
            }


            return new Response<List<StudentListDto>>(ResponseType.NotFound, "Veri Bulunamadı");
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<Students>().GetByFilter(x => x.Id == id)); 
            if(data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success,data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var deletedStudent = await _uow.GetRepository<Students>().GetByFilter(x => x.Id == id);
            if (deletedStudent != null)
            {
                _uow.GetRepository<Students>().Remove(deletedStudent);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            else
            {
                return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
            

        }

        public async Task<IResponse<StudentUpdateDto>> Update(StudentUpdateDto dto)
        {
            var result = _updateValidator.Validate(dto);
            if(result.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<Students>().Find(dto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<Students>().Update(_mapper.Map<Students>(dto),updatedEntity);
                    _uow.SaveChanges();

                    return new Response<StudentUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<StudentUpdateDto>(ResponseType.NotFound, $"{dto.Id} ait data bulunamadı");

            }
            else
            {
                return new Response<StudentUpdateDto>(ResponseType.ValidationError, dto, result.CovertToCustomValidationError());
            }
        }
    }
}
