using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Entities.Domains
{
    public class Day : BaseEntity
    {
        public string Days { get; set; }
        public List<LessonDayandTimeInformation> LessonDayandTimeInformations { get; set; }
    }
}
