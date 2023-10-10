using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.ClassRoomsDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.DayDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Interfaces
{
    public interface IClassRoom
    {
        Task<IResponse<List<ClassRoomListDto>>> GetAllStudents();
        Task<IResponse<ClassRoomCreateDto>> Create(ClassRoomCreateDto dto);
        Task<IResponse<IDto>> GetById<IDto>(int id);
        Task<IResponse> Remove(int id);
        Task<IResponse<ClassRoomUpdateDto>> Update(ClassRoomUpdateDto dto);
    }
}
