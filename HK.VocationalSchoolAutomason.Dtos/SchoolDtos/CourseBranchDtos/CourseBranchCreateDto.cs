using HK.VocationalSchoolAutomason.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Dtos.SchoolDtos.CourseBranchDtos
{
    public class CourseBranchCreateDto : IDto
    {
        public int CourseId { get; set; }
        public int BranchId { get; set; }
    }
}
