using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Entities.Domains
{
    public class ScheduleInformation :BaseEntity
    {
        public int SemesterWeeksId { get; set; }
        public int WeeklyScheduleId { get; set; }
        public bool IsCompleted { get; set; }
        public int AbsentStudentId { get; set; }

        public SemesterWeek SemesterWeek { get; set; }
        public WeeklySchedule WeeklySchedule { get; set; }
        public Students AbsentStudent { get; set; }
    }
}
