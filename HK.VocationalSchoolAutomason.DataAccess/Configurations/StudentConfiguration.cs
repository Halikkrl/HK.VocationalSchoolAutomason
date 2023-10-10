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



            builder.Property(x =>x.IdentificationNumber).IsRequired();
            builder.Property(x => x.IdentificationNumber).HasMaxLength(11);
            builder.HasIndex(x =>x.IdentificationNumber).IsUnique();



            builder.Property(x =>x.FirstName).IsRequired();
            builder.Property(x => x.FirstName).HasMaxLength(50);



            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(50);



            builder.Property(x => x.Number).IsRequired();
            builder.HasIndex(x => x.Number).IsUnique();



            builder.Property(x => x.Gender).IsRequired();



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
