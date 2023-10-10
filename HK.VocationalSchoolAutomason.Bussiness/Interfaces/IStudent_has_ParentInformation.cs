using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.Student_has_ParentInformation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.StudentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Interfaces
{
    public interface IStudent_has_ParentInformation
    {
        Task<IResponse<List<Student_has_ParentInformationList>>> GetAllStudents();
        Task<IResponse<Student_has_ParentInformationCreate>> Create(Student_has_ParentInformationCreate dto);
        Task<IResponse<IDto>> GetById<IDto>(int id);
        Task<IResponse> Remove(int id);
        Task<IResponse<Student_has_ParentInformationUpdate>> Update(Student_has_ParentInformationUpdate dto);
    }
}
