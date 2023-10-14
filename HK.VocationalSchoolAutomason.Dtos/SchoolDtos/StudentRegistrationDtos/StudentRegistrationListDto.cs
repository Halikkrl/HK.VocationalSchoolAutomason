using HK.VocationalSchoolAutomason.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Dtos.SchoolDtos.StudentRegistrationDtos
{
    public class StudentRegistrationListDto
    {
        public int Id { get; set; }
        public decimal TotalContinuity { get; set; }


        public string StudentIdentificationNumber { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public int StudentNumber { get; set; }
        public string StudentGender { get; set; }



        public string GroupName { get; set; }
        public string MajorName { get; set; }
        public string LevelName { get; set; }




        internal int MajorId { get; set; }
        internal int LevelId { get; set; }
        internal int GruopId { get; set; }

        public string SemesterName { get; set; }



        internal Majors Majors { get; set; }
        internal Levels Levels { get; set; }
        internal Groups Groups { get; set; }





        internal Students Students { get; set; }
        internal LevelGruopMojor LevelGruopMojor { get; set; }
        internal Semester Semester { get; set; }



        public StudentContact StudentContact { get; set; }
        public List<StudentMajorLevelGroup> StudentMajorLevelGroups { get; set; }

    }
}
