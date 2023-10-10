using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Entities.Domains
{
    public class CourseBranch : BaseEntity
    {
        public int CourseId { get; set; }
        public int BranchId { get; set; }
        public Course Course { get; set; }
        public Branch Branch { get; set; }

    }
}
