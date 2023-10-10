using HK.VocationalSchoolAutomason.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Dtos.SchoolDtos.WeeklyScheduleDtos
{
    public class WeeklyScheduleCreateDto : IDto
    {
        public int ClassLessonsId { get; set; }
        public int ClassRoomId { get; set; }
        public int LessonDayandTimeInformationId { get; set; }
        public int EmployeeId { get; set; }
    }
}
