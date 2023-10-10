using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Entities.Domains
{
    public class Student_has_ParentInformation : BaseEntity
    {
        public int StudentId { get; set; }
        public int ParentInformationId { get; set; }
        public Students Students { get; set; }
        public Parent_Information Parent_Information { get; set; }


    }
}
