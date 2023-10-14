using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Entities.Domains
{
    public class Groups : BaseEntity
    {
        public string GroupName { get; set; }
        public List<LevelGruopMojor> LevelGruopMojors { get; set; }

    }
}
