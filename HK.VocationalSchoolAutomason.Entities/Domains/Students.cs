using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Entities.Domains
{
    public class Students : BaseEntity
    {
        public string IdentificationNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Number { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirthDay { get; set; }
        public byte[] Photo { get; set; }
        public bool IsActive { get; set; }
        public string RepeatingAGrade { get; set; }
        public DateTime DateOfIssue { get; set; } 
        public DateTime RegistrationYear { get; set; } 
        public List<Student_has_ParentInformation> Student_HasParentInformation { get; set; }
        public StudentContact StudentContact {get; set;}
        public List<StudentMajorLevelGroup> StudentMajorLevelGroups { get; set; }
        public List<ScheduleInformation> ScheduleInformations { get; set; }


    }
}