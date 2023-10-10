using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.Interfaces
{
    public interface InterfaceGenel<TListDto, TCreateDto,TUpdateDto>
    {
        Task<IResponse<List<TListDto>>> GetAllStudents();
        Task<IResponse<TCreateDto>> Create(TCreateDto dto);
        Task<IResponse<IDto>> GetById<IDto>(int id);
        Task<IResponse> Remove(int id);
        Task<IResponse<TUpdateDto>> Update(TUpdateDto dto);
    }
}
