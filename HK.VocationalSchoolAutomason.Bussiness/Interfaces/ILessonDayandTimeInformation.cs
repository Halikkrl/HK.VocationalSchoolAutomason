using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.DayDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.LessonDayandTimeInformationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Interfaces
{
    public interface ILessonDayandTimeInformation
    {
        Task<IResponse<List<LessonDayandTimeInformationListDto>>> GetAllStudents();
        Task<IResponse<LessonDayandTimeInformationCreateDto>> Create(LessonDayandTimeInformationCreateDto dto);
        Task<IResponse<IDto>> GetById<IDto>(int id);
        Task<IResponse> Remove(int id);
        Task<IResponse<LessonDayandTimeInformationUpdateDto>> Update(LessonDayandTimeInformationUpdateDto dto);
    }
}
