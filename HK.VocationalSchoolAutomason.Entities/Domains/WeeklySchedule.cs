using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Entities.Domains
{
    public class WeeklySchedule : BaseEntity
    {
        public int ClassLessonsId  { get; set; }
        public int ClassRoomId { get; set; }
        public int LessonDayandTimeInformationId { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public ClassLessons ClassLessons  { get; set; }
        public ClassRoom ClassRoom { get; set; }
        public LessonDayandTimeInformation LessonDayandTimeInformation { get; set; }
        public List<ScheduleInformation> ScheduleInformations { get; set; }


    }
}
