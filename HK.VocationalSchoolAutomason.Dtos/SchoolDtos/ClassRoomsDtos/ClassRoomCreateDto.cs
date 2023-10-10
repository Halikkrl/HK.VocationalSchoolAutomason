using HK.VocationalSchoolAutomason.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Dtos.SchoolDtos.ClassRoomsDtos
{
    public class ClassRoomCreateDto : IDto
    {
        public string Name { get; set; }
    }
}
