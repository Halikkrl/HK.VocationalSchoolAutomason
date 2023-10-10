using HK.VocationalSchoolAutomason.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeDutyDtos
{
    public class EmployeeDutyUpdateDto : IDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int DutyId { get; set; }
    }
}
