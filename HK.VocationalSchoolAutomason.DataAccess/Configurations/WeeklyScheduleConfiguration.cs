using HK.VocationalSchoolAutomason.Entities.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.DataAccess.Configurations
{
    public class WeeklyScheduleConfiguration : IEntityTypeConfiguration<WeeklySchedule>
    {
        public void Configure(EntityTypeBuilder<WeeklySchedule> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(x => x.ClassLessons).WithMany(x => x.WeeklySchedules).HasForeignKey(x => x.ClassLessonsId);
            builder.HasOne(x => x.ClassRoom).WithMany(x => x.WeeklySchedules).HasForeignKey(x =>x.ClassRoomId);
            builder.HasOne(x => x.LessonDayandTimeInformation).WithMany(x => x.WeeklySchedules).HasForeignKey(x => x.LessonDayandTimeInformationId);
            builder.HasOne(x => x.Employee).WithMany(x => x.WeeklySchedules).HasForeignKey(x => x.EmployeeId);

        }
    }
}
