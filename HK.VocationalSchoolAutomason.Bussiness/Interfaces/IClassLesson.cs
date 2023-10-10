using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.ClassLessonDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.DayDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Interfaces
{
    public interface IClassLesson
    {
        Task<IResponse<List<ClassLessonListDto>>> GetAllStudents();
        Task<IResponse<ClassLessonCreateDto>> Create(ClassLessonCreateDto dto);
        Task<IResponse<IDto>> GetById<IDto>(int id);
        Task<IResponse> Remove(int id);
        Task<IResponse<ClassLessonUpdateDto>> Update(ClassLessonUpdateDto dto);
    }
}
