using HK.VocationalSchoolAutomason.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Dtos.SchoolDtos.LessonDayandTimeInformationDtos
{
    public class LessonDayandTimeInformationUpdateDto : IDto
    {
        public int Id { get; set; }
        public int DayId { get; set; }
        public int WeeklyLessonHoursId { get; set; }
    }
}
