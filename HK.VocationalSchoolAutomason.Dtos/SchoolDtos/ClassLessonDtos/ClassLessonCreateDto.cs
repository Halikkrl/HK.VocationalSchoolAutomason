using HK.VocationalSchoolAutomason.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Dtos.SchoolDtos.ClassLessonDtos
{
    public class ClassLessonCreateDto : IDto
    {
        public int CourseId { get; set; }
        public int LGMId { get; set; }
        public bool IsActive { get; set; }
    }
}
