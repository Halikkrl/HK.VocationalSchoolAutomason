using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeDutyDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Interfaces
{
    public interface IEmployeeDuty
    {
        Task<IResponse<List<EmployeeDutyListDto>>> GetAllStudents();
        Task<IResponse<EmployeeDutyCreateDto>> Create(EmployeeDutyCreateDto dto);
        Task<IResponse<IDto>> GetById<IDto>(int id);
        Task<IResponse> Remove(int id);
        Task<IResponse<EmployeeDutyUpdateDto>> Update(EmployeeDutyUpdateDto dto);
    }
}
