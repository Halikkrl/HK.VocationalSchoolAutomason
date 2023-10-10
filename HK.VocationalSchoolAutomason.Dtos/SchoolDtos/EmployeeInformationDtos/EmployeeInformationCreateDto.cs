using HK.VocationalSchoolAutomason.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeInformationDtos
{
    public class EmployeeInformationCreateDto : IDto
    {
        public int EmployeeId { get; set; }
        public string Graduation { get; set; }
        public string GraduationYear { get; set; }
        public string GraduatedSchool { get; set; }
    }
}
