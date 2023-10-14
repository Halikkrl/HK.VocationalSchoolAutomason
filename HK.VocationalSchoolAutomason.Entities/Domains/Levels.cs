using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Entities.Domains
{
    public class Levels : BaseEntity
    {
        public string LevelName { get; set; }
        public List<LevelGruopMojor> LevelGruopMojors { get; set; }
    }
}
