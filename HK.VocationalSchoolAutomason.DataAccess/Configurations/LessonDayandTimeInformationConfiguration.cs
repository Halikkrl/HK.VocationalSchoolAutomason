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
    public class LessonDayandTimeInformationConfiguration : IEntityTypeConfiguration<LessonDayandTimeInformation>
    {
        public void Configure(EntityTypeBuilder<LessonDayandTimeInformation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.WeeklyLessonHoursId).HasColumnName("WeeklyLessonHourId");

            builder.HasOne(x => x.WeeklyLessonHours).WithMany(x => x.LessonDayandTimeInformations).HasForeignKey(x => x.WeeklyLessonHoursId);
            builder.HasOne(x => x.Days).WithMany(x => x.LessonDayandTimeInformations).HasForeignKey(x => x.DayId);
            builder.HasIndex(x => new {x.WeeklyLessonHoursId, x.DayId}).IsUnique();
        }
    }
}
