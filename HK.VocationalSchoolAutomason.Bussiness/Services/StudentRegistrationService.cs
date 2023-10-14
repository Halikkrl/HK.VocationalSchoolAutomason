using AutoMapper;
using FluentValidation;
using HK.VocationalSchoolAutomason.Bussiness.Extensions;
using HK.VocationalSchoolAutomason.Bussiness.Interfaces;
using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.DataAccess.Contexts;
using HK.VocationalSchoolAutomason.DataAccess.UnitOfWork;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.DayDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.LevelGroupMajorDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.StudentDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.StudentMajorLevelGroupDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.StudentRegistrationDtos;
using HK.VocationalSchoolAutomason.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HK.VocationalSchoolAutomason.Bussiness.Services
{
    public class StudentRegistrationService : IStudentRegistration
    {
        private readonly SchoolContext _context;
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        private readonly IValidator<StudentRegistrationCreateDto> _createValidator;


        public StudentRegistrationService(SchoolContext context, IMapper mapper, IUow uow, IValidator<StudentRegistrationCreateDto> createValidator)
        {
            _context = context;
            _mapper = mapper;
            _uow = uow;
            _createValidator = createValidator;
        }

        public async Task<IResponse<StudentRegistrationCreateDto>> Create(StudentRegistrationCreateDto dto)
        {
            var ValidationResult = _createValidator.Validate(dto);
            if (ValidationResult.IsValid)
            {
                var NewStudent = _mapper.Map<Students>(dto);
                await _uow.GetRepository<Students>().Create(NewStudent);
                await _uow.SaveChanges();
                int StudentId = NewStudent.Id;
                dto.StudentPKId = StudentId;

                var Contact = _mapper.Map<StudentContact>(dto);
                await _uow.GetRepository<StudentContact>().Create(Contact);

                dto.StudentId = StudentId;
                var Class = _mapper.Map<StudentMajorLevelGroup>(dto);
                await _uow.GetRepository<StudentMajorLevelGroup>().Create(Class);


                await _uow.SaveChanges();

                return new Response<StudentRegistrationCreateDto>(ResponseType.Success, dto);


            }
            else
            {
                return new Response<StudentRegistrationCreateDto>(ResponseType.ValidationError, dto, ValidationResult.CovertToCustomValidationError());
            }
        }

        public IQueryable<StudentRegistrationListDto> GetAllStudents()
        {
            var joins = (from generalStudent in _context.StudentMajorLevelGroups

                         join _student in _context.Students
                         on generalStudent.Id equals _student.Id into listStudent


                         from list in listStudent.DefaultIfEmpty()

                         select new StudentRegistrationListDto
                         {
                             Id = generalStudent.Id,
                             StudentFirstName = generalStudent.Students.StudentFirstName,
                             StudentLastName = generalStudent.Students.StudentLastName,
                             StudentIdentificationNumber = generalStudent.Students.StudentIdentificationNumber,
                             StudentNumber = generalStudent.Students.StudentNumber,
                             StudentGender = generalStudent.Students.StudentGender,
                             GroupName = generalStudent.LevelGruopMojor.Groups.GroupName,
                             LevelName = generalStudent.LevelGruopMojor.Level.LevelName,
                             MajorName = generalStudent.LevelGruopMojor.Majors.MajorName,
                             SemesterName = generalStudent.Semester.SemesterName,

                             StudentContact = new StudentContact
                             {
                                 Id = generalStudent.Students.StudentContact.Id,
                                 StudentPKId = generalStudent.Students.StudentContact.StudentPKId,
                                 City = generalStudent.Students.StudentContact.City,
                                 Address = generalStudent.Students.StudentContact.Address,
                                 District = generalStudent.Students.StudentContact.District,
                                 Neighbourhood = generalStudent.Students.StudentContact.Neighbourhood,

                             }
                             


                         });

            return joins.AsQueryable();
        }

    }
}
