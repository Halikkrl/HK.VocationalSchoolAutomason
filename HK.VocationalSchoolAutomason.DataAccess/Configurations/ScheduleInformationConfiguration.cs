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
    public class ScheduleInformationConfiguration : IEntityTypeConfiguration<ScheduleInformation>
    {
        public void Configure(EntityTypeBuilder<ScheduleInformation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.AbsentStudent).WithMany(x => x.ScheduleInformations).HasForeignKey(x => x.AbsentStudentId);
            builder.HasOne(x => x.SemesterWeek).WithMany(x => x.ScheduleInformations).HasForeignKey(x => x.SemesterWeeksId);
            builder.HasOne(x => x.WeeklySchedule).WithMany(x => x.ScheduleInformations).HasForeignKey(x => x.WeeklyScheduleId);

            builder.HasIndex(x => new {x.AbsentStudentId,x.SemesterWeeksId,x.WeeklyScheduleId}).IsUnique();

        }
    }
}
