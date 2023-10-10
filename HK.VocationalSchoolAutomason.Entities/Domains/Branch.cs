using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Entities.Domains
{
    public class Branch : BaseEntity
    {
        public string Name { get; set; }
        public List<EmployeeDutyBranch> EmployeeDutyBranches { get; set; }
        public List<CourseBranch> CourseBranches { get; set; }

    }
}
