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
    public class StudentConfiguration : IEntityTypeConfiguration<Students>
    {
        public void Configure(EntityTypeBuilder<Students> builder)
        {
            #region Student Classı Configurasyonu


            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasIndex(x => x.Id).IsUnique();



            builder.Property(x =>x.StudentIdentificationNumber).IsRequired();
            builder.Property(x => x.StudentIdentificationNumber).HasMaxLength(11);
            builder.HasIndex(x =>x.StudentIdentificationNumber).IsUnique();



            builder.Property(x =>x.StudentFirstName).IsRequired();
            builder.Property(x => x.StudentFirstName).HasMaxLength(50);



            builder.Property(x => x.StudentLastName).IsRequired();
            builder.Property(x => x.StudentLastName).HasMaxLength(50);



            builder.Property(x => x.StudentNumber).IsRequired();
            builder.HasIndex(x => x.StudentNumber).IsUnique();



            builder.Property(x => x.StudentGender).IsRequired();



            builder.Property(x => x.DateOfBirthDay).IsRequired();
            builder.Property(x => x.DateOfBirthDay).HasColumnType("Date");



            builder.Property(x => x.Photo).HasColumnType("varbinary(max)");
            builder.Property(x => x.Photo).IsRequired(false);



            builder.Property(x => x.IsActive).IsRequired();



            builder.Property(x => x.DateOfIssue).IsRequired();
            builder.Property(x => x.DateOfIssue).HasColumnType("datetime");



            builder.Property(x => x.RegistrationYear).IsRequired();
            builder.Property(x => x.RegistrationYear).HasColumnType("date");


            #endregion


        }
    }
}
