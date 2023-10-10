using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.DayDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.StudentMajorLevelGroupDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Interfaces
{
    public interface IStudentMajorLevelGroup
    {
        Task<IResponse<List<StudentMajorLevelGroupListDto>>> GetAllStudents();
        Task<IResponse<StudentMajorLevelGroupCreateDto>> Create(StudentMajorLevelGroupCreateDto dto);
        Task<IResponse<IDto>> GetById<IDto>(int id);
        Task<IResponse> Remove(int id);
        Task<IResponse<StudentMajorLevelGroupUpdateDto>> Update(StudentMajorLevelGroupUpdateDto dto);
    }
}
