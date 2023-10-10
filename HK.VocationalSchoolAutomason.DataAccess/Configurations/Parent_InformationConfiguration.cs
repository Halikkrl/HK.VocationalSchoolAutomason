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
    public class Parent_InformationConfiguration : IEntityTypeConfiguration<Parent_Information>
    {
        public void Configure(EntityTypeBuilder<Parent_Information> builder)
        {
            #region Parent_Iformation Alanı Configurasyonu
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasIndex(x => x.Id).IsUnique();
            #endregion

            #region Parent_Iformation Proximity Alanı Configurasyonu
            builder.Property(x => x.Proximity).IsRequired();
            #endregion

            #region Parent_Iformation IdentificationNumber Alanı Configurasyonu
            builder.Property(x => x.IdentificationNumber).IsRequired();
            builder.Property(x => x.IdentificationNumber).HasMaxLength(11);
            builder.HasIndex(x => x.IdentificationNumber).IsUnique();
            #endregion

            #region Parent_Iformation FirstName Alanı Configurasyonu
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.FirstName).HasMaxLength(50);
            #endregion

            #region Parent_Iformation LastName Alanı Configurasyonu
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(50);
            #endregion

            #region Parent_Iformation PhoneNumber Alanı Configurasyonu
            builder.Property(x => x.PhoneNumber).IsRequired(false);
            builder.Property(x => x.PhoneNumber).HasMaxLength(13);
            #endregion

            #region Parent_Iformation DateOfIssue  Alanı Configurasyonu
            builder.Property(x => x.DateOfIssue).IsRequired();
            builder.Property(x => x.DateOfIssue).HasColumnType("datetime");
            #endregion

        }
    }
}
