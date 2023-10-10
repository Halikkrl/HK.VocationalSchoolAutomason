using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.Parent_Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Interfaces
{
    public interface IEmployee
    {
        Task<IResponse<List<EmployeeListDto>>> GetAllStudents();
        Task<IResponse<EmployeeCreateDto>> Create(EmployeeCreateDto dto);
        Task<IResponse<IDto>> GetById<IDto>(int id);
        Task<IResponse> Remove(int id);
        Task<IResponse<EmployeeUpdateDto>> Update(EmployeeUpdateDto dto);
    }
}
