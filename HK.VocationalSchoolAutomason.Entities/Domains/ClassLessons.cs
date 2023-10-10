using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Entities.Domains
{
    public class ClassLessons :BaseEntity
    {
        public int CourseId { get; set; }
        public int LGMId { get; set; }
        public bool IsActive { get; set; }
        public Course Course { get; set; }
        public LevelGruopMojor LevelGruopMojor { get; set; }
        public List<WeeklySchedule> WeeklySchedules { get; set; }

    }
}
