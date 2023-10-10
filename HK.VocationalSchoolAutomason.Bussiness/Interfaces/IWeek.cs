using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.DayDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.WeeksDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Interfaces
{
    public interface IWeek
    {
        Task<IResponse<List<WeekListDto>>> GetAllStudents();
        Task<IResponse<WeeKCreateDto>> Create(WeeKCreateDto dto);
        Task<IResponse<IDto>> GetById<IDto>(int id);
        Task<IResponse> Remove(int id);
        Task<IResponse<WeekUpdateDto>> Update(WeekUpdateDto dto);
    }
}
