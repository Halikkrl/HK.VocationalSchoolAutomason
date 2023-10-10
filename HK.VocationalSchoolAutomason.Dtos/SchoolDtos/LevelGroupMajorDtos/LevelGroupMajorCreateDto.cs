using HK.VocationalSchoolAutomason.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Dtos.SchoolDtos.LevelGroupMajorDtos
{
    public class LevelGroupMajorCreateDto : IDto
    {
        public int MajorId { get; set; }
        public int LevelId { get; set; }
        public int GruopId { get; set; }
    }
}
