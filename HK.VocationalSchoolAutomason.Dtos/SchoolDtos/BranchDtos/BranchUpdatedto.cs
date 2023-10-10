using HK.VocationalSchoolAutomason.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Dtos.SchoolDtos.BranchDtos
{
    public class BranchUpdatedto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
