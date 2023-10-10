using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Entities.Domains
{
    public class EmployeeInformation : BaseEntity
    {
        public int EmployeeId { get; set; }
        public string Graduation { get; set; }
        public string GraduationYear { get; set; }
        public string GraduatedSchool { get; set; }
        public Employee Employee { get; set; }
    }
}
