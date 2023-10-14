using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Entities.Domains
{
    public class Semester : BaseEntity
    {
        public string SemesterName { get; set; }
        public List<StudentMajorLevelGroup> StudentMajorLevelGroups { get; set; }
        public List<SemesterWeek> SemesterWeeks { get; set; }

    }
}
