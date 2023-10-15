using HK.VocationalSchoolAutomason.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeRegistrationDto
{
    public class EmployeeRegistrationCreateDto
    {

        public string IdentificationNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirthDay { get; set; }
        public byte[] Photo { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateOfIssue { get; set; } = DateTime.UtcNow;



        public int EmployeeId { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Neighbourhood { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumber2 { get; set; }
        public DateTime ContactDateOfIssue { get; set; } = DateTime.UtcNow;



        public string Graduation { get; set; }
        public string GraduationYear { get; set; }
        public string GraduatedSchool { get; set; }



        public int DutyId { get; set; }
        public int BranchId { get; set; }
        public int EmployeeDutyId { get; set; }


    }
}

