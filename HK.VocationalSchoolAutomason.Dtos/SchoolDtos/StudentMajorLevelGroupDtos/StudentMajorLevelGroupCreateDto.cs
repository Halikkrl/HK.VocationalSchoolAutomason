using HK.VocationalSchoolAutomason.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Dtos.SchoolDtos.StudentMajorLevelGroupDtos
{
    public class StudentMajorLevelGroupCreateDto : IDto
    {
        public int StudentId { get; set; }
        public int MajorLevelGroupId { get; set; }
        public int SemesterId { get; set; }
        public decimal TotalContinuity { get; set; }
    }
}
