using HK.VocationalSchoolAutomason.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Dtos.SchoolDtos.Parent_Information
{
    public class Parent_InformationList : IDto
    {
        public int Id { get; set; }
        public string Proximity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string IdentificationNumber { get; set; }
        public DateTime DateOfIssue { get; set; }
    }
}
