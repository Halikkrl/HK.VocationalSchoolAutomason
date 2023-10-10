using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Entities.Domains
{
    public class LessonDayandTimeInformation : BaseEntity
    {
        public int DayId { get; set; }
        public int WeeklyLessonHoursId { get; set; }

        public WeeklyLessonHours WeeklyLessonHours { get; set; }
        public Day Days { get; set; }
        public List<WeeklySchedule> WeeklySchedules { get; set; }

    }
}
