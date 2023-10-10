using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.StudentContactDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.StudentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Interfaces
{
    public interface IStudentContactService
    {
        Task<IResponse<List<StudentContactListDto>>> GetAllStudents();
        Task<IResponse<StudentContactCreateDto>> Create(StudentContactCreateDto dto);
        Task<IResponse<IDto>> GetById<IDto>(int id);
        Task<IResponse> Remove(int id);
        Task<IResponse<StudentContactUpdateDto>> Update(StudentContactUpdateDto dto);
    }
}
