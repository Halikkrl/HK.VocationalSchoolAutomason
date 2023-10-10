using HK.VocationalSchoolAutomason.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeContact
{
    public class EmployeeContactCreateDto : IDto
    {
        public int EmployeeId { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Neighbourhood { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string? PhoneNumber2 { get; set; }
        public DateTime DateOfIssue { get; set; } = DateTime.Now;
    }
}
