using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Entities.Domains
{
    public class EmployeeDuty : BaseEntity
    {
        public int EmployeeId { get; set; }
        public int DutyId { get; set; }
        public Employee Employee { get; set; }
        public Duty Duty { get; set; }
        public List<EmployeeDutyBranch> EmployeeDutyBranches { get; set; }




    }
}
