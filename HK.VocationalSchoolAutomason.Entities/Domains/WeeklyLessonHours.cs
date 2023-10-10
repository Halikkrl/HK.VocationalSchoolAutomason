using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Entities.Domains
{
    public class WeeklyLessonHours :BaseEntity
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public List<LessonDayandTimeInformation> LessonDayandTimeInformations { get; set; }


    }
}
