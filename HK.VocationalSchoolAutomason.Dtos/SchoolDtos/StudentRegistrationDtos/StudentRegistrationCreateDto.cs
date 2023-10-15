using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Dtos.SchoolDtos.StudentRegistrationDtos
{
    public class StudentRegistrationCreateDto
    {
        public string StudentIdentificationNumber { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public int StudentNumber { get; set; }
        public string StudentGender { get; set; }
        public DateTime DateOfBirthDay { get; set; }
        public byte[] Photo { get; set; }
        public bool IsActive { get; set; }
        public string RepeatingAGrade { get; set; }
        public DateTime DateOfIssue { get; set; }  = DateTime.UtcNow;
        public DateTime RegistrationYear { get; set; } = DateTime.UtcNow;



        public int StudentPKId { get; set; } 
        public string City { get; set; }
        public string District { get; set; }
        public string Neighbourhood { get; set; }
        public string Address { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactPhoneNumber2 { get; set; }
        public DateTime ContactDateOfIssue { get; set; } = DateTime.UtcNow;


        public int? StudentId { get; set; }
        public int MajorLevelGroupId { get; set; }
        public int SemesterId { get; set; }
        public int TotalCominity { get; set; } = 0;

    }
}
