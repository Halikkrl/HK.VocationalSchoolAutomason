using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeContact;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Interfaces
{
    public interface IEmployeeContact
    {
        Task<IResponse<List<EmployeeContactListDto>>> GetAllStudents();
        Task<IResponse<EmployeeContactCreateDto>> Create(EmployeeContactCreateDto dto);
        Task<IResponse<IDto>> GetById<IDto>(int id);
        Task<IResponse> Remove(int id);
        Task<IResponse<EmployeeContactUpdateDto>> Update(EmployeeContactUpdateDto dto);
    }
}
