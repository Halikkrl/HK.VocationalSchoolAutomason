using HK.VocationalSchoolAutomason.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Dtos.SchoolDtos.Student_has_ParentInformation
{
    public class Student_has_ParentInformationCreate : IDto
    {
        public int StudentId { get; set; }
        public int ParentInformationId { get; set; }
    }
}
