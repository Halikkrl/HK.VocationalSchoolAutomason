using HK.VocationalSchoolAutomason.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeRegistrationDto
{
    public class EmployeeRegistrationListDto
    {
        public int Id { get; set; }
        public string IdentificationNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }



        public string City { get; set; }
        public string District { get; set; }
        public string Neighbourhood { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }




        public string Graduation { get; set; }
        public string GraduationYear { get; set; }
        public string GraduatedSchool { get; set; }



        public string DutyName { get; set; }


        public string BranchName { get; set; }


        //public HK.VocationalSchoolAutomason.Entities.Domains.EmployeeContact EmployeeContact { get; set; }
        //public EmployeeInformation EmployeeInformation { get; set; }
        //public List<EmployeeDuty> EmployeeDuties { get; set; }
        //public List<WeeklySchedule> WeeklySchedules { get; set; }



        //public Employee Employee { get; set; }
        //public Duty Duty { get; set; }
        //public List<EmployeeDutyBranch> EmployeeDutyBranches { get; set; }

    }
}
