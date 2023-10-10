using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeInformationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Interfaces
{
    public interface IEmployeeInformation
    {
        Task<IResponse<List<EmployeeInformationListDto>>> GetAllStudents();
        Task<IResponse<EmployeeInformationCreateDto>> Create(EmployeeInformationCreateDto dto);
        Task<IResponse<IDto>> GetById<IDto>(int id);
        Task<IResponse> Remove(int id);
        Task<IResponse<EmployeeInformationUpdateDto>> Update(EmployeeInformationUpdateDto dto);
    }
}
