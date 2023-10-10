using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.BranchDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Interfaces
{
    public interface IBranch
    {
        Task<IResponse<List<BranchListDto>>> GetAllStudents();
        Task<IResponse<BranchCreateDto>> Create(BranchCreateDto dto);
        Task<IResponse<IDto>> GetById<IDto>(int id);
        Task<IResponse> Remove(int id);
        Task<IResponse<BranchUpdatedto>> Update(BranchUpdatedto dto);
    }
}
