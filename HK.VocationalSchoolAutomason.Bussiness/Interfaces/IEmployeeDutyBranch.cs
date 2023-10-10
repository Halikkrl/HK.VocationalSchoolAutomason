using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeDutyBranchDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Interfaces
{
    public interface IEmployeeDutyBranch
    {
        Task<IResponse<List<EmployeeDutyBranchListDto>>> GetAllStudents();
        Task<IResponse<EmployeeDutyBranchCreateDto>> Create(EmployeeDutyBranchCreateDto dto);
        Task<IResponse<IDto>> GetById<IDto>(int id);
        Task<IResponse> Remove(int id);
        Task<IResponse<EmployeeDutyBranchUpdateDto>> Update(EmployeeDutyBranchUpdateDto dto);
    }
}
