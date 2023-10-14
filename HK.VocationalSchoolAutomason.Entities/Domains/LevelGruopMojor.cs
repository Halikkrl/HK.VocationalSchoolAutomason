using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Entities.Domains
{
    public class LevelGruopMojor : BaseEntity
    {
        public int MajorId { get; set; }
        public int LevelId { get; set; }
        public int GruopId { get; set; }

        public Majors Majors { get; set; }
        public Levels Level { get; set; }
        public Groups Groups { get; set; }

        public List<StudentMajorLevelGroup> StudentMajorLevelGroups { get; set; }
        public List<ClassLessons> ClassLessons { get; set; }
    }
}
