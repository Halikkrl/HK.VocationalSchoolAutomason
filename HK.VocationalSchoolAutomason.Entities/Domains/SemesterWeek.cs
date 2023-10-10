using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Entities.Domains
{
    public class SemesterWeek : BaseEntity
    {
        public int SemesterId { get; set; }
        public int WeeksId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Semester Semester { get; set; }
        public Weeks Weeks { get; set; }
        public List<ScheduleInformation> ScheduleInformations { get; set; }

    }
}
