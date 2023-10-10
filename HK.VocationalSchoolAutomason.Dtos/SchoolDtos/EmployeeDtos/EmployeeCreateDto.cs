using HK.VocationalSchoolAutomason.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeDtos
{
    public class EmployeeCreateDto : IDto
    {
        public string IdentificationNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirthDay { get; set; }
        public byte[] Photo { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateOfIssue { get; set; } = DateTime.Now;
    }
}
