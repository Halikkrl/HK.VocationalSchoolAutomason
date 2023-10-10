using HK.VocationalSchoolAutomason.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Dtos.SchoolDtos.SemesterWeekDtos
{
    public class SemesterWeekUpdateDto : IDto
    {
        public int Id { get; set; }
        public int SemesterId { get; set; }
        public int WeeksId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
