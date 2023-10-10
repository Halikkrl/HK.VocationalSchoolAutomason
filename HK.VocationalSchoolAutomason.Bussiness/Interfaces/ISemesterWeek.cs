using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.SemesterWeekDtos;

namespace HK.VocationalSchoolAutomason.Bussiness.Interfaces
{
    public interface ISemesterWeek
    {
        Task<IResponse<List<SemesterWeekListDto>>> GetAllStudents();
        Task<IResponse<SemesterWeekCreateDto>> Create(SemesterWeekCreateDto dto);
        Task<IResponse<IDto>> GetById<IDto>(int id);
        Task<IResponse> Remove(int id);
        Task<IResponse<SemesterWeekUpdateDto>> Update(SemesterWeekUpdateDto dto);
    }
}
