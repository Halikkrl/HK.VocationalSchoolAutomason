using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.CourseBranchDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.DayDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Interfaces
{
    public interface ICourseBranch
    {
        Task<IResponse<List<CourseBranchListDto>>> GetAllStudents();
        Task<IResponse<CourseBranchCreateDto>> Create(CourseBranchCreateDto dto);
        Task<IResponse<IDto>> GetById<IDto>(int id);
        Task<IResponse> Remove(int id);
        Task<IResponse<CourseBranchUpdateDto>> Update(CourseBranchUpdateDto dto);
    }
}
