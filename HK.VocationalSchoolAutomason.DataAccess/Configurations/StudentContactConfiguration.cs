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
    public class StudentContactConfiguration : IEntityTypeConfiguration<StudentContact>
    {
        public void Configure(EntityTypeBuilder<StudentContact> builder)
        {
            #region StudentContact Classı Konfigurasyonu
            builder.HasKey(x => x.Id);


            builder.Property(x =>x.City).IsRequired();
            builder.Property(x =>x.City).HasMaxLength(100);

            builder.Property(x =>x.District).IsRequired();
            builder.Property(x=>x.District).HasMaxLength(100);

            builder.Property(sc => sc.Neighbourhood).HasMaxLength(150);

            builder.Property(sc => sc.Address).HasMaxLength(500);

            builder.Property(sc => sc.ContactPhoneNumber).HasMaxLength(13);
            builder.Property(sc => sc.ContactPhoneNumber).IsRequired(false);

            builder.Property(sc => sc.ContactPhoneNumber2).HasMaxLength(13);
            builder.Property(sc => sc.ContactPhoneNumber2).IsRequired(false);

            builder.Property(sc => sc.ContactPhoneNumber).IsRequired();

            // StudentContact ile Students arasındaki ilişkiyi tanımlama
            builder.HasOne(sc => sc.Students).WithOne(s => s.StudentContact).HasForeignKey<StudentContact>(sc => sc.StudentPKId);
        }

        #endregion
    }
}
