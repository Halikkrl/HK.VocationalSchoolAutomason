using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Entities.Domains
{
    public class AbsenceInformation : BaseEntity
    {
        public int StudentId { get; set; }
        public int CourseId  { get; set; }
        public DateTime DateTime { get; set; }

        public Students Students { get; set; }
        public Course Course { get; set; }

    }
}
// Devamsızlık Tablsu Tamamlanmadı.!!!