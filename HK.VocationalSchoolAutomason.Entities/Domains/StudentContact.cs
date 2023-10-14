using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Entities.Domains
{
    public class StudentContact : BaseEntity
    {
        public int StudentPKId { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Neighbourhood { get; set; }
        public string Address { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactPhoneNumber2 { get; set; }
        public DateTime ContactDateOfIssue { get; set; }
        public Students Students { get; set; }



    }
}
