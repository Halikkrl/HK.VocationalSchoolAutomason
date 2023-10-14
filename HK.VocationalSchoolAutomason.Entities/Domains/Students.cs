
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Entities.Domains
{
    public class Students : BaseEntity
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
        public DateTime DateOfIssue { get; set; } 
        public DateTime RegistrationYear { get; set; } 
        public StudentContact StudentContact {get; set;}
        public List<StudentMajorLevelGroup> StudentMajorLevelGroups { get; set; }
        public List<ScheduleInformation> ScheduleInformations { get; set; }


    }
}