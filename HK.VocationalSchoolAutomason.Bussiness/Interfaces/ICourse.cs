using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.CourseDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.DayDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Interfaces
{
    public interface ICourse
    {
        Task<IResponse<List<CourseListDto>>> GetAllStudents();
        Task<IResponse<CourseCreateDto>> Create(CourseCreateDto dto);
        Task<IResponse<IDto>> GetById<IDto>(int id);
        Task<IResponse> Remove(int id);
        Task<IResponse<CourseUpdateDto>> Update(CourseUpdateDto dto);
    }
}
