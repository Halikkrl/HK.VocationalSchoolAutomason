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
    public class EmployeeInformationConfiguration : IEntityTypeConfiguration<EmployeeInformation>
    {
        public void Configure(EntityTypeBuilder<EmployeeInformation> builder)
        {
            #region EmployeeInformation Classı Konfigurasyonu

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Graduation).IsRequired(false);
            builder.Property(x => x.Graduation).HasMaxLength(50);

            builder.Property(x => x.GraduationYear).HasMaxLength(50);
            builder.Property(x => x.GraduationYear).IsRequired(false);

            builder.Property(x=> x.GraduatedSchool).IsRequired(false);





            builder.HasOne(x => x.Employee).WithOne(x => x.EmployeeInformation).HasForeignKey<EmployeeInformation>(x => x.EmployeeId);
            #endregion
        }
    }
}
