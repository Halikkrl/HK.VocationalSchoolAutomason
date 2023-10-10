using HK.VocationalSchoolAutomason.DataAccess.Configurations;
using HK.VocationalSchoolAutomason.Entities.Domains;
using Microsoft.EntityFrameworkCore;

namespace HK.VocationalSchoolAutomason.DataAccess.Contexts
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new Parent_InformationConfiguration());
            modelBuilder.ApplyConfiguration(new Student_has_ParentInformationConfiguration());
            modelBuilder.ApplyConfiguration(new StudentContactConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeContactConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeInformationConfiguration());
            modelBuilder.ApplyConfiguration(new MajorConfiguration());
            modelBuilder.ApplyConfiguration(new LevelConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new SemesterConfiguration());
            modelBuilder.ApplyConfiguration(new LevelGruopMojorConfiguration());
            modelBuilder.ApplyConfiguration(new StudentMajorLevelGroupConfiguration());
            modelBuilder.ApplyConfiguration(new DutyConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeDutyConfiguration());
            modelBuilder.ApplyConfiguration(new BranchConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeDutyBranchConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new ClassLessonConfiguration());
            modelBuilder.ApplyConfiguration(new ClassRoomConfiguration());
            modelBuilder.ApplyConfiguration(new WeeklyLessonHoursConfiguration());
            modelBuilder.ApplyConfiguration(new DayConfiguration());
            modelBuilder.ApplyConfiguration(new WeeksConfiguration());
            modelBuilder.ApplyConfiguration(new ScheduleInformationConfiguration());
            modelBuilder.ApplyConfiguration(new GradeSystemConfiguration());
            modelBuilder.ApplyConfiguration(new CourseBranchConfiguration());
        }

        public DbSet<Students> Students { get; set; }
        public DbSet<Parent_Information> Parent_Informations { get; set; }
        public DbSet<Student_has_ParentInformation> Student_HasParentInformation { get; set; }
        public DbSet<StudentContact> StudentContacts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeContact> EmployeeContacts { get; set; }
        public DbSet<EmployeeInformation> EmployeeInformations { get; set; }
        public DbSet<Majors> Majors { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<LevelGruopMojor> LevelGruopMojors { get; set; }
        public DbSet<StudentMajorLevelGroup> StudentMajorLevelGroups { get; set; }
        public DbSet<Duty> Duties { get; set; }
        public DbSet<EmployeeDuty> EmployeeDuties { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<EmployeeDutyBranch> EmployeeDutyBranches { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<ClassLessons> ClassLessons { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<WeeklyLessonHours> WeeklyLessonHours { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Weeks> Weeks { get; set; }
        public DbSet<ScheduleInformation> ScheduleInformations { get; set; }
        public DbSet<GradeSystem> GradeSystems { get; set; }
        public DbSet<CourseBranch> CourseBranches { get; set; }



    }
}
