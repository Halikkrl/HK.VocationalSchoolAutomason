using HK.VocationalSchoolAutomason.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeDutyDtos
{
    public class EmployeeDutyCreateDto : IDto
    {
        public int EmployeeId { get; set; }
        public int DutyId { get; set; }
    }
}
