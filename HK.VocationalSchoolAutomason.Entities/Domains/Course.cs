using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Entities.Domains
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public List<ClassLessons> ClassLessons { get; set; }
        public List<GradeSystem> GradeSystems { get; set; }
        public List<CourseBranch> CourseBranches { get; set; }


    }
}
