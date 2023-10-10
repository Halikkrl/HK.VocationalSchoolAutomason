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
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            #region Employee Classı Konfigurasyon ayarları
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasIndex(x => x.Id).IsUnique();


            builder.Property(x => x.IdentificationNumber).IsRequired();
            builder.Property(x => x.IdentificationNumber).HasMaxLength(11);
            builder.HasIndex(x => x.IdentificationNumber).IsUnique();



            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.FirstName).HasMaxLength(50);



            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(50);

            builder.Property(x => x.Gender).IsRequired();



            builder.Property(x => x.DateOfBirthDay).IsRequired();
            builder.Property(x => x.DateOfBirthDay).HasColumnType("Date");



            builder.Property(x => x.Photo).HasColumnType("varbinary(max)");
            builder.Property(x => x.Photo).IsRequired(false);



            builder.Property(x => x.IsActive).IsRequired();



            builder.Property(x => x.DateOfIssue).IsRequired();
            builder.Property(x => x.DateOfIssue).HasColumnType("datetime");

            

            #endregion

        }
    }
}