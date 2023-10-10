using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.Dtos.Interfaces;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.StudentDtos;
using HK.VocationalSchoolAutomason.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Interfaces
{
    public interface IStudentService
    {
        Task<IResponse<List<StudentListDto>>> GetAllStudents();
        Task<IResponse<StudentCreateDto>> Create(StudentCreateDto dto);
        Task<IResponse<IDto>> GetById<IDto>(int id);
        Task<IResponse> Remove(int id);
        Task<IResponse<StudentUpdateDto>> Update(StudentUpdateDto dto);

    }
}
