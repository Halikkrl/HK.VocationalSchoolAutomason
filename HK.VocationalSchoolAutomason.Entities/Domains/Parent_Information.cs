using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Entities.Domains
{
    public class Parent_Information :BaseEntity
    {
        public string Proximity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string IdentificationNumber { get; set; }
        public DateTime DateOfIssue { get; set; }
        public List<Student_has_ParentInformation> Student_HasParentInformation { get; set; }

    }
}
