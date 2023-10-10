using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.BranchDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.MajorDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Interfaces
{
    public interface IMajor
    {
        Task<IResponse<List<MajorListDto>>> GetAllStudents();
        Task<IResponse<MajorCreateDto>> Create(MajorCreateDto dto);
        Task<IResponse<IDto>> GetById<IDto>(int id);
        Task<IResponse> Remove(int id);
        Task<IResponse<MajorUpdateDto>> Update(MajorUpdateDto dto);
    }
}
