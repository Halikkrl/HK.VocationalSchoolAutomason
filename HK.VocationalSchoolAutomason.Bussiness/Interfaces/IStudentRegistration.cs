using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.DayDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.StudentRegistrationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Interfaces
{
    public interface IStudentRegistration
    {

        IQueryable<StudentRegistrationListDto> GetAllStudents();
        Task<IResponse<StudentRegistrationCreateDto>> Create(StudentRegistrationCreateDto dto);
        //Task<IResponse> Remove(int id);
        //Task<IResponse<StudentregistrationUpdateDto>> Update(StudentregistrationUpdateDto dto);

    }
}
