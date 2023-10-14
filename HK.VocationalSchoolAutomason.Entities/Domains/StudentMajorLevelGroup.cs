using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Entities.Domains
{
    public class StudentMajorLevelGroup :BaseEntity
    {
        public int? StudentId { get; set; }
        public int MajorLevelGroupId { get; set; }
        public int SemesterId { get; set; }
        public decimal TotalContinuity { get; set; }

        public Students Students { get; set; }
        public LevelGruopMojor LevelGruopMojor { get; set; }
        public Semester Semester { get; set; }
        public List<GradeSystem> GradeSystems { get; set; }

    }
}
