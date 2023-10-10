using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.DayDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.WeeklyLessonHoursDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Interfaces
{
    public interface IWeeklyLessonHours
    {
        Task<IResponse<List<WeeklyLessonHoursListDto>>> GetAllStudents();
        Task<IResponse<WeeklyLessonHoursCreateDto>> Create(WeeklyLessonHoursCreateDto dto);
        Task<IResponse<IDto>> GetById<IDto>(int id);
        Task<IResponse> Remove(int id);
        Task<IResponse<WeeklyLessonHoursUpdateDto>> Update(WeeklyLessonHoursUpdateDto dto);
    }
}
