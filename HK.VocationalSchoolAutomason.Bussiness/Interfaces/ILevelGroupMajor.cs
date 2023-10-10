using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.GroupDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.LevelGroupMajorDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Interfaces
{
    public interface ILevelGroupMajor
    {
        Task<IResponse<List<LevelGroupMajorListDto>>> GetAllStudents();
        Task<IResponse<LevelGroupMajorCreateDto>> Create(LevelGroupMajorCreateDto dto);
        Task<IResponse<IDto>> GetById<IDto>(int id);
        Task<IResponse> Remove(int id);
        Task<IResponse<LevelGroupMajorUpdateDto>> Update(LevelGroupMajorUpdateDto dto);
    }
}
