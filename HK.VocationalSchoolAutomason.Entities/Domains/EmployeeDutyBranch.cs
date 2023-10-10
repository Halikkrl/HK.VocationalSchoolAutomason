using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Entities.Domains
{
    public class EmployeeDutyBranch :BaseEntity
    {
        public int EmployeeDutyId { get; set; }
        public int BranchId { get; set; }

        public EmployeeDuty EmployeeDuty { get; set; }
        public Branch Branch { get; set; }

    }
}
