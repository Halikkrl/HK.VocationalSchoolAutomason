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
    public class EmployeeContactConfiguration : IEntityTypeConfiguration<EmployeeContact>
    {
        public void Configure(EntityTypeBuilder<EmployeeContact> builder)
        {
            #region StudentContact Classı Konfigurasyonu
            builder.HasKey(x => x.Id);


            builder.Property(x => x.City).IsRequired();
            builder.Property(x => x.City).HasMaxLength(100);

            builder.Property(x => x.District).IsRequired();
            builder.Property(x => x.District).HasMaxLength(100);

            builder.Property(sc => sc.Neighbourhood).HasMaxLength(150);

            builder.Property(sc => sc.Address).HasMaxLength(500);

            builder.Property(sc => sc.PhoneNumber).HasMaxLength(13);
            builder.Property(sc => sc.PhoneNumber).IsRequired(false);

            builder.Property(sc => sc.PhoneNumber2).HasMaxLength(13);
            builder.Property(sc => sc.PhoneNumber2).IsRequired(false);

            builder.Property(sc => sc.DateOfIssue).IsRequired();

            builder.HasOne(sc => sc.Employee).WithOne(s => s.EmployeeContact).HasForeignKey<EmployeeContact>(sc => sc.EmployeeId);
        }

        #endregion
    }
}

