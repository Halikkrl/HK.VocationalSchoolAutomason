using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeRegistrationDto;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.StudentRegistrationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Interfaces
{
    public interface IEmployeeInformationAll
    {
        IQueryable<EmployeeRegistrationListDto> GetAllEmployee();
        Task<IResponse<EmployeeRegistrationCreateDto>> Create(EmployeeRegistrationCreateDto dto);
        Task<IResponse> Remove(int id);
    }
}
