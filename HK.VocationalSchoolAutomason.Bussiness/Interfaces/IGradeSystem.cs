using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.DayDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.GradeSystemDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Interfaces
{
    public interface IGradeSystem
    {
        Task<IResponse<List<GradeSystemListDto>>> GetAllStudents();
        Task<IResponse<GradeSystemCreateDto>> Create(GradeSystemCreateDto dto);
        Task<IResponse<IDto>> GetById<IDto>(int id);
        Task<IResponse> Remove(int id);
        Task<IResponse<GradeSystemUpdateDto>> Update(GradeSystemUpdateDto dto);
    }
}
