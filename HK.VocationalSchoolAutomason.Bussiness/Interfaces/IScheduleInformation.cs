using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.DayDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.ScheduleInformationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Interfaces
{
    public interface IScheduleInformation
    {
        Task<IResponse<List<ScheduleInformationListDto>>> GetAllStudents();
        Task<IResponse<ScheduleInformationCreateDto>> Create(ScheduleInformationCreateDto dto);
        Task<IResponse<IDto>> GetById<IDto>(int id);
        Task<IResponse> Remove(int id);
        Task<IResponse<ScheduleInformationUpdateDto>> Update(ScheduleInformationUpdateDto dto);
    }
}
