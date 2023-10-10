using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.DayDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.WeeklyScheduleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Interfaces
{
    public interface IWeeklySchedule
    {
        Task<IResponse<List<WeeklyScheduleListDto>>> GetAllStudents();
        Task<IResponse<WeeklyScheduleCreateDto>> Create(WeeklyScheduleCreateDto dto);
        Task<IResponse<IDto>> GetById<IDto>(int id);
        Task<IResponse> Remove(int id);
        Task<IResponse<WeeklyScheduleUpdateDto>> Update(WeeklyScheduleUpdateDto dto);
    }
}
