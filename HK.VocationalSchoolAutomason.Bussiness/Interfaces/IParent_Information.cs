using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.Parent_Information;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.StudentContactDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Interfaces
{
    public interface IParent_Information
    {
        Task<IResponse<List<Parent_InformationList>>> GetAllStudents();
        Task<IResponse<Parent_InformationCreate>> Create(Parent_InformationCreate dto);
        Task<IResponse<IDto>> GetById<IDto>(int id);
        Task<IResponse> Remove(int id);
        Task<IResponse<Parent_InformationUpdate>> Update(Parent_InformationUpdate dto);
    }
}
