using AutoMapper;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.BranchDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.ClassLessonDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.ClassRoomsDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.CourseBranchDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.CourseDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.DayDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.DutiesDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeContact;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeDutyBranchDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeDutyDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeInformationDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeRegistrationDto;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.GradeSystemDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.GroupDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.LessonDayandTimeInformationDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.LevelDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.LevelGroupMajorDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.MajorDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.ScheduleInformationDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.SemesterDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.SemesterWeekDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.StudentContactDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.StudentDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.StudentMajorLevelGroupDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.StudentRegistrationDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.WeeklyLessonHoursDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.WeeklyScheduleDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.WeeksDtos;
using HK.VocationalSchoolAutomason.Entities.Domains;

namespace HK.VocationalSchoolAutomason.Bussiness.Mapping.AutoMapper
{
    public class SchoolProfile : Profile
    {
        public SchoolProfile()
        {
            CreateMap<Students, StudentListDto>().ReverseMap();
            CreateMap<Students, StudentUpdateDto>().ReverseMap();
            CreateMap<Students, StudentCreateDto>().ReverseMap();
            CreateMap<StudentListDto, StudentUpdateDto>().ReverseMap();





            CreateMap<StudentContact, StudentContactListDto>().ReverseMap();
            CreateMap<StudentContact, StudentContactCreateDto>().ReverseMap();
            CreateMap<StudentContact, StudentContactUpdateDto>().ReverseMap();
            CreateMap<StudentContactListDto, StudentContactUpdateDto>().ReverseMap();



            CreateMap<Employee, EmployeeListDto>().ReverseMap();
            CreateMap<Employee, EmployeeCreateDto>().ReverseMap();
            CreateMap<Employee, EmployeeUpdateDto>().ReverseMap();
            CreateMap<EmployeeListDto, EmployeeUpdateDto>().ReverseMap();


            CreateMap<EmployeeInformation, EmployeeInformationListDto>().ReverseMap();
            CreateMap<EmployeeInformation, EmployeeInformationCreateDto>().ReverseMap();
            CreateMap<EmployeeInformation, EmployeeInformationUpdateDto>().ReverseMap();
            CreateMap<EmployeeInformationListDto, EmployeeInformationUpdateDto>().ReverseMap();



            CreateMap<EmployeeContact, EmployeeContactListDto>().ReverseMap();
            CreateMap<EmployeeContact, EmployeeContactCreateDto>().ReverseMap();
            CreateMap<EmployeeContact, EmployeeContactUpdateDto>().ReverseMap();
            CreateMap<EmployeeContactListDto, EmployeeContactUpdateDto>().ReverseMap();



            CreateMap<Duty, DutyListDto>().ReverseMap();
            CreateMap<Duty, DutyCreateDto>().ReverseMap();
            CreateMap<Duty, DutyUpdateDto>().ReverseMap();
            CreateMap<DutyListDto, DutyUpdateDto>().ReverseMap();



            CreateMap<EmployeeDuty, EmployeeDutyListDto>().ReverseMap();
            CreateMap<EmployeeDuty, EmployeeDutyCreateDto>().ReverseMap();
            CreateMap<EmployeeDuty, EmployeeDutyUpdateDto>().ReverseMap();
            CreateMap<EmployeeDutyListDto, EmployeeDutyUpdateDto>().ReverseMap();


            CreateMap<Branch, BranchListDto>().ReverseMap();
            CreateMap<Branch, BranchCreateDto>().ReverseMap();
            CreateMap<Branch, BranchUpdatedto>().ReverseMap();
            CreateMap<BranchListDto, BranchUpdatedto>().ReverseMap();



            CreateMap<EmployeeDutyBranch, EmployeeDutyBranchListDto>().ReverseMap();
            CreateMap<EmployeeDutyBranch, EmployeeDutyBranchCreateDto>().ReverseMap();
            CreateMap<EmployeeDutyBranch, EmployeeDutyBranchUpdateDto>().ReverseMap();
            CreateMap<EmployeeDutyBranchListDto, EmployeeDutyBranchUpdateDto>().ReverseMap();


            CreateMap<Majors, MajorListDto>().ReverseMap();
            CreateMap<Majors, MajorUpdateDto>().ReverseMap();
            CreateMap<Majors, MajorCreateDto>().ReverseMap();
            CreateMap<MajorListDto, MajorUpdateDto>().ReverseMap();


            CreateMap<Levels, LevelListDto>().ReverseMap();
            CreateMap<Levels, LevelUpdateDto>().ReverseMap();
            CreateMap<Levels, LevelCreateDto>().ReverseMap();
            CreateMap<LevelListDto, LevelUpdateDto>().ReverseMap();



            CreateMap<Groups, GroupListDto>().ReverseMap();
            CreateMap<Groups, GroupCreateDto>().ReverseMap();
            CreateMap<Groups, GroupUpdateDto>().ReverseMap();
            CreateMap<GroupListDto, GroupUpdateDto>().ReverseMap();



            CreateMap<LevelGruopMojor, LevelGroupMajorListDto>().ReverseMap();
            CreateMap<LevelGruopMojor, LevelGroupMajorUpdateDto>().ReverseMap();
            CreateMap<LevelGruopMojor, LevelGroupMajorCreateDto>().ReverseMap();
            CreateMap<LevelGroupMajorListDto, LevelGroupMajorUpdateDto>().ReverseMap();


            CreateMap<Day, DayListDto>().ReverseMap();
            CreateMap<Day, DayCreateDto>().ReverseMap();
            CreateMap<Day, DayUpdateDto>().ReverseMap();
            CreateMap<DayListDto, DayUpdateDto>().ReverseMap();



            CreateMap<WeeklyLessonHours, WeeklyLessonHoursCreateDto>().ReverseMap();
            CreateMap<WeeklyLessonHours, WeeklyLessonHoursListDto>().ReverseMap();
            CreateMap<WeeklyLessonHours, WeeklyLessonHoursUpdateDto>().ReverseMap();
            CreateMap<WeeklyLessonHoursListDto, WeeklyLessonHoursUpdateDto>().ReverseMap();


            CreateMap<LessonDayandTimeInformation, LessonDayandTimeInformationListDto>().ReverseMap();
            CreateMap<LessonDayandTimeInformation, LessonDayandTimeInformationCreateDto>().ReverseMap();
            CreateMap<LessonDayandTimeInformation, LessonDayandTimeInformationUpdateDto>().ReverseMap();
            CreateMap<LessonDayandTimeInformationListDto, LessonDayandTimeInformationUpdateDto>().ReverseMap();



            CreateMap<ClassRoom, ClassRoomListDto>().ReverseMap();
            CreateMap<ClassRoom, ClassRoomCreateDto>().ReverseMap();
            CreateMap<ClassRoom, ClassRoomUpdateDto>().ReverseMap();
            CreateMap<ClassRoomListDto, ClassRoomUpdateDto>().ReverseMap();


            CreateMap<Course, CourseListDto>().ReverseMap();
            CreateMap<Course, CourseCreateDto>().ReverseMap();
            CreateMap<Course, CourseUpdateDto>().ReverseMap();
            CreateMap<CourseListDto, CourseUpdateDto>().ReverseMap();


            CreateMap<ClassLessons, ClassLessonListDto>().ReverseMap();
            CreateMap<ClassLessons, ClassLessonCreateDto>().ReverseMap();
            CreateMap<ClassLessons, ClassLessonUpdateDto>().ReverseMap();
            CreateMap<ClassLessonListDto, ClassLessonUpdateDto>().ReverseMap();




            CreateMap<CourseBranch, CourseBranchListDto>().ReverseMap();
            CreateMap<CourseBranch, CourseBranchCreateDto>().ReverseMap();
            CreateMap<CourseBranch, CourseBranchUpdateDto>().ReverseMap();
            CreateMap<CourseBranchListDto, CourseBranchUpdateDto>().ReverseMap();



            CreateMap<Semester, SemesterListDto>().ReverseMap();
            CreateMap<Semester, SemesterCreateDto>().ReverseMap();
            CreateMap<Semester, SemesterUpdateDto>().ReverseMap();
            CreateMap<SemesterListDto, SemesterUpdateDto>().ReverseMap();


            CreateMap<Weeks, WeekListDto>().ReverseMap();
            CreateMap<Weeks, WeeKCreateDto>().ReverseMap();
            CreateMap<Weeks, WeekUpdateDto>().ReverseMap();
            CreateMap<WeekListDto, WeekUpdateDto>().ReverseMap();




            CreateMap<SemesterWeek, SemesterWeekListDto>().ReverseMap();
            CreateMap<SemesterWeek, SemesterWeekCreateDto>().ReverseMap();
            CreateMap<SemesterWeek, SemesterWeekUpdateDto>().ReverseMap();
            CreateMap<SemesterWeekListDto, SemesterWeekUpdateDto>().ReverseMap();




            CreateMap<GradeSystem, GradeSystemListDto>().ReverseMap();
            CreateMap<GradeSystem, GradeSystemCreateDto>().ReverseMap();
            CreateMap<GradeSystem, GradeSystemUpdateDto>().ReverseMap();
            CreateMap<GradeSystemListDto, GradeSystemUpdateDto>().ReverseMap();



            CreateMap<StudentMajorLevelGroup, StudentMajorLevelGroupCreateDto>().ReverseMap();
            CreateMap<StudentMajorLevelGroup, StudentMajorLevelGroupListDto>().ReverseMap();
            CreateMap<StudentMajorLevelGroup, StudentMajorLevelGroupUpdateDto>().ReverseMap();
            CreateMap<StudentMajorLevelGroupListDto, StudentMajorLevelGroupUpdateDto>().ReverseMap();


            CreateMap<WeeklySchedule, WeeklyLessonHoursCreateDto>().ReverseMap();
            CreateMap<WeeklySchedule, WeeklyScheduleListDto>().ReverseMap();
            CreateMap<WeeklySchedule, WeeklyScheduleUpdateDto>().ReverseMap();
            CreateMap<WeeklyScheduleListDto, WeeklyScheduleUpdateDto>().ReverseMap();


            CreateMap<ScheduleInformation, ScheduleInformationCreateDto>().ReverseMap();
            CreateMap<ScheduleInformation, ScheduleInformationListDto>().ReverseMap();
            CreateMap<ScheduleInformation, ScheduleInformationUpdateDto>().ReverseMap();
            CreateMap<ScheduleInformationListDto, ScheduleInformationUpdateDto>().ReverseMap();


            CreateMap<Students, StudentRegistrationCreateDto>().ReverseMap();
            CreateMap<StudentContact, StudentRegistrationCreateDto>().ReverseMap();
            CreateMap<StudentMajorLevelGroup, StudentRegistrationCreateDto>().ReverseMap();


            CreateMap<Students, StudentregistrationUpdateDto>().ReverseMap();
            CreateMap<StudentContact, StudentregistrationUpdateDto>().ReverseMap();
            CreateMap<StudentMajorLevelGroup, StudentregistrationUpdateDto>().ReverseMap();



            CreateMap<Employee, EmployeeRegistrationCreateDto>().ReverseMap();
            CreateMap<EmployeeContact, EmployeeRegistrationCreateDto>().ReverseMap();
            CreateMap<EmployeeInformation, EmployeeRegistrationCreateDto>().ReverseMap();
            CreateMap<EmployeeDuty, EmployeeRegistrationCreateDto>().ReverseMap();
            CreateMap<EmployeeDutyBranch, EmployeeRegistrationCreateDto>().ReverseMap();




        }
    }
}
