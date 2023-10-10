using AutoMapper;
using FluentValidation;
using HK.VocationalSchoolAutomason.Bussiness.Interfaces;
using HK.VocationalSchoolAutomason.Bussiness.Mapping.AutoMapper;
using HK.VocationalSchoolAutomason.Bussiness.Services;
using HK.VocationalSchoolAutomason.Bussiness.ValidationRules.BranchValidation;
using HK.VocationalSchoolAutomason.Bussiness.ValidationRules.ClassLessonValidation;
using HK.VocationalSchoolAutomason.Bussiness.ValidationRules.ClassRoomValidation;
using HK.VocationalSchoolAutomason.Bussiness.ValidationRules.CourseBranchValidation;
using HK.VocationalSchoolAutomason.Bussiness.ValidationRules.CourseValidation;
using HK.VocationalSchoolAutomason.Bussiness.ValidationRules.DayValidation;
using HK.VocationalSchoolAutomason.Bussiness.ValidationRules.DutyValidation;
using HK.VocationalSchoolAutomason.Bussiness.ValidationRules.EmployeeContactValidation;
using HK.VocationalSchoolAutomason.Bussiness.ValidationRules.EmployeeDutyBranchValidation;
using HK.VocationalSchoolAutomason.Bussiness.ValidationRules.EmployeeDutyValidation;
using HK.VocationalSchoolAutomason.Bussiness.ValidationRules.EmployeeInformationValidation;
using HK.VocationalSchoolAutomason.Bussiness.ValidationRules.EmployeeValidation;
using HK.VocationalSchoolAutomason.Bussiness.ValidationRules.GradeSystemValidation;
using HK.VocationalSchoolAutomason.Bussiness.ValidationRules.GroupValidation;
using HK.VocationalSchoolAutomason.Bussiness.ValidationRules.LessonDayandTimeInformationValidation;
using HK.VocationalSchoolAutomason.Bussiness.ValidationRules.LevelGroupMajorValidation;
using HK.VocationalSchoolAutomason.Bussiness.ValidationRules.LevelValidation;
using HK.VocationalSchoolAutomason.Bussiness.ValidationRules.MajorValidation;
using HK.VocationalSchoolAutomason.Bussiness.ValidationRules.Parent_InformationValidation;
using HK.VocationalSchoolAutomason.Bussiness.ValidationRules.ScheduleInformationValidation;
using HK.VocationalSchoolAutomason.Bussiness.ValidationRules.SemesterValidation;
using HK.VocationalSchoolAutomason.Bussiness.ValidationRules.SemesterWeekValidation;
using HK.VocationalSchoolAutomason.Bussiness.ValidationRules.Student_has_ParentInformation;
using HK.VocationalSchoolAutomason.Bussiness.ValidationRules.Student_has_ParentInformationValidation;
using HK.VocationalSchoolAutomason.Bussiness.ValidationRules.StudentContactValidations;
using HK.VocationalSchoolAutomason.Bussiness.ValidationRules.StudentMajorLevelGroupValidation;
using HK.VocationalSchoolAutomason.Bussiness.ValidationRules.StudentValidations;
using HK.VocationalSchoolAutomason.Bussiness.ValidationRules.WeeklyLessonHoursValidation;
using HK.VocationalSchoolAutomason.Bussiness.ValidationRules.WeeklyScheduleValidation;
using HK.VocationalSchoolAutomason.Bussiness.ValidationRules.WeekValidation;
using HK.VocationalSchoolAutomason.DataAccess.Contexts;
using HK.VocationalSchoolAutomason.DataAccess.UnitOfWork;
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
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.GradeSystemDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.GroupDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.LessonDayandTimeInformationDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.LevelDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.LevelGroupMajorDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.MajorDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.Parent_Information;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.ScheduleInformationDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.SemesterDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.SemesterWeekDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.Student_has_ParentInformation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.StudentContactDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.StudentDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.StudentMajorLevelGroupDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.WeeklyLessonHoursDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.WeeklyScheduleDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.WeeksDtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace HK.VocationalSchoolAutomason.Bussiness.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<SchoolContext>(opt =>
            {
                opt.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=HKSchoolAutomason;Trusted_Connection=True;TrustServerCertificate=True");
                opt.LogTo(Console.WriteLine, LogLevel.Information);
            });

            var configuration = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new SchoolProfile());
            });

            var mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);


            services.AddScoped<IUow,Uow>();
            services.AddScoped<IStudentService,StudentService>();
            services.AddScoped<IStudentContactService,StudentContactService>();
            services.AddScoped<IParent_Information,Parent_InformationService>();
            services.AddScoped<IStudent_has_ParentInformation,Student_has_ParentInformationService>();
            services.AddScoped<IEmployee,EmployeeService>();
            services.AddScoped<IEmployeeInformation,EmployeeInformationService>();
            services.AddScoped<IEmployeeContact, EmployeeContactService>();
            services.AddScoped<InterfaceGenel<DutyListDto,DutyCreateDto,DutyUpdateDto>,DutyService>();
            services.AddScoped<IEmployeeDuty, EmployeeDutyService>();
            services.AddScoped<IBranch,BranchService>();
            services.AddScoped<IEmployeeDutyBranch, EmployeeDutyBranchService>();
            services.AddScoped<ILevel, LevelService>();
            services.AddScoped<IMajor, MajorService>();
            services.AddScoped<IGroup, GroupService>();
            services.AddScoped<ILevelGroupMajor, LevelGroupMajorService>();
            services.AddScoped<IDay,DayService>();
            services.AddScoped<IWeeklyLessonHours, WeeklyLessonHoursService>();
            services.AddScoped<ILessonDayandTimeInformation, LessonDayandTimeInformationService>();
            services.AddScoped<IClassRoom, ClassRoomService>();
            services.AddScoped<ICourse, CourseService>();
            services.AddScoped<ICourseBranch, CourseBranchService>();
            services.AddScoped<IClassLesson, ClassLessonService>();
            services.AddScoped<ISemester, SemesterService>();
            services.AddScoped<IWeek,WeekService>();
            services.AddScoped<ISemesterWeek, SemesterWeekService>();
            services.AddScoped<IGradeSystem, GradeSystemService>();
            services.AddScoped<IStudentMajorLevelGroup, StudentMajorLevelGroupService>();
            services.AddScoped<IWeeklySchedule, WeeklyScheduleService>();
            services.AddScoped<IScheduleInformation, ScheduleInformationService>();


            services.AddTransient<IValidator<StudentCreateDto>,StudentCreateValidation>();
            services.AddTransient<IValidator<StudentUpdateDto>, StudentUpdateValidation>();


            services.AddTransient<IValidator<StudentContactCreateDto>, StudentContactCreateValidation>();
            services.AddTransient<IValidator<StudentContactUpdateDto>, StudentContactUpdateValidation>();

            services.AddTransient<IValidator<Parent_InformationCreate>, Parent_InformationCreateValidation>();
            services.AddTransient<IValidator<Parent_InformationUpdate>, Parent_InformationUpdateValidation>();

            services.AddTransient<IValidator<Student_has_ParentInformationCreate>, Student_has_ParentInformationCreateValidation>();
            services.AddTransient<IValidator<Student_has_ParentInformationUpdate>, Student_has_ParentInformationUpdateValidation>();

            services.AddTransient<IValidator<EmployeeCreateDto>, EmployeeCreateValidation>();
            services.AddTransient<IValidator<EmployeeUpdateDto>, EmployeeUpdateValidation>();

            services.AddTransient<IValidator<EmployeeInformationCreateDto>, EmployeeInformationCreateValidation>();
            services.AddTransient<IValidator<EmployeeInformationUpdateDto>, EmployeeInformationUpdateValidation>();

            services.AddTransient<IValidator<EmployeeContactCreateDto>, EmployeeContactCreateValidation>();
            services.AddTransient<IValidator<EmployeeContactUpdateDto>, EmployeeContactUpdateValidation>();

            services.AddTransient<IValidator<DutyCreateDto>, DutyCreateValidation>();
            services.AddTransient<IValidator<DutyUpdateDto>, DutyUpdateValidation>();

            services.AddTransient<IValidator<EmployeeDutyCreateDto>, EmployeeDutyCreateValidation>();
            services.AddTransient<IValidator<EmployeeDutyUpdateDto>, EmployeeDutyUpdateValidation>();

            services.AddTransient<IValidator<BranchCreateDto>, BranchCreateValidation>();
            services.AddTransient<IValidator<BranchUpdatedto>, BranchUpdateValidation>();

            services.AddTransient<IValidator<EmployeeDutyBranchCreateDto>, EmployeeDutyBranchCreateValidation>();
            services.AddTransient<IValidator<EmployeeDutyBranchUpdateDto>, EmployeeDutyBranchUpdateValidation>();

            services.AddTransient<IValidator<GroupCreateDto>, GroupCreateValidation>();
            services.AddTransient<IValidator<GroupUpdateDto>, GroupUpdateValidation>();

            services.AddTransient<IValidator<LevelCreateDto>, LevelCreateValidation>();
            services.AddTransient<IValidator<LevelUpdateDto>, LevelUpdateValidation>();

            services.AddTransient<IValidator<MajorCreateDto>, MajorCreateValidation>();
            services.AddTransient<IValidator<MajorUpdateDto>, MajorUpdateValidation>();

            services.AddTransient<IValidator<LevelGroupMajorCreateDto>, LevelGroupMajorCreateValidation>();
            services.AddTransient<IValidator<LevelGroupMajorUpdateDto>, LevelGroupMajorUpdateValidation>();

            services.AddTransient<IValidator<WeeklyLessonHoursCreateDto>, WeeklyLessonHoursCreateValidation>();
            services.AddTransient<IValidator<WeeklyLessonHoursUpdateDto>, WeeklyLessonHoursUpdateValidation>();

            services.AddTransient<IValidator<DayCreateDto>, DayCreateValidation>();
            services.AddTransient<IValidator<DayUpdateDto>, DayUpdateValidation>();

            services.AddTransient<IValidator<LessonDayandTimeInformationCreateDto>, LessonDayandTimeInformationCreateValidation>();
            services.AddTransient<IValidator<LessonDayandTimeInformationUpdateDto>, LessonDayandTimeInformationUpdateValidation>();

            services.AddTransient<IValidator<ClassRoomCreateDto>, ClassRoomCreateValidation>();
            services.AddTransient<IValidator<ClassRoomUpdateDto>, ClassRoomUpdateValidation>();
            
            services.AddTransient<IValidator<CourseCreateDto>,CourseCreateValidation>();
            services.AddTransient<IValidator<CourseUpdateDto>, CourseUpdateValidation>();

            services.AddTransient<IValidator<CourseBranchCreateDto>, CourseBranchCreateValidation>();
            services.AddTransient<IValidator<CourseBranchUpdateDto>, CourseBranchUpdateValidation>();

            services.AddTransient<IValidator<ClassLessonCreateDto>, ClassLessonCreateValidation>();
            services.AddTransient<IValidator<ClassLessonUpdateDto>, ClassLessonUpdateValidation>();

            services.AddTransient<IValidator<SemesterCreateDto>, SemesterCreateValidation>();
            services.AddTransient<IValidator<SemesterUpdateDto>, SemesterUpdateValidation>();

            services.AddTransient<IValidator<WeeKCreateDto>, WeekCreateValidation>();
            services.AddTransient<IValidator<WeekUpdateDto>, WeekUpdateValidation>();

            services.AddTransient<IValidator<SemesterWeekCreateDto>, SemesterWeekCreateValidation>();
            services.AddTransient<IValidator<SemesterWeekUpdateDto>, SemesterWeekUpdateValidation>();

            services.AddTransient<IValidator<GradeSystemCreateDto>, GradeSystemCreateValidation>();
            services.AddTransient<IValidator<GradeSystemUpdateDto>, GradeSystemUpdateValidation>();

            services.AddTransient<IValidator<StudentMajorLevelGroupCreateDto>, StudentMajorLevelGroupCreateValidation>();
            services.AddTransient<IValidator<StudentMajorLevelGroupUpdateDto>, StudentMajorLevelGroupUpdateValidation>();

            services.AddTransient<IValidator<WeeklyScheduleCreateDto>, WeeklyScheduleCreateValidation>();
            services.AddTransient<IValidator<WeeklyScheduleUpdateDto>, WeeklyScheduleUpdateValidation>();

            services.AddTransient<IValidator<ScheduleInformationCreateDto>, ScheduleInformationCreateValidation>();
            services.AddTransient<IValidator<ScheduleInformationUpdateDto>, ScheduleInformationUpdateValidation>();
        }
    }
}
