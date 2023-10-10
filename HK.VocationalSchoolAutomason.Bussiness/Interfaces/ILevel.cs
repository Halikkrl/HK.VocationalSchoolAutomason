using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.BranchDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.LevelDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Interfaces
{
    public interface ILevel
    {
        Task<IResponse<List<LevelListDto>>> GetAllStudents();
        Task<IResponse<LevelCreateDto>> Create(LevelCreateDto dto);
        Task<IResponse<IDto>> GetById<IDto>(int id);
        Task<IResponse> Remove(int id);
        Task<IResponse<LevelUpdateDto>> Update(LevelUpdateDto dto);
    }
}
