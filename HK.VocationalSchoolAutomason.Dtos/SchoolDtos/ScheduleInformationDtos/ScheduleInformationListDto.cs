using HK.VocationalSchoolAutomason.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Dtos.SchoolDtos.ScheduleInformationDtos
{
    public class ScheduleInformationListDto : IDto
    {
        public int Id { get; set; }
        public int SemesterWeeksId { get; set; }
        public int WeeklyScheduleId { get; set; }
        public bool IsCompleted { get; set; }
        public int AbsentStudentId { get; set; }
    }
}
