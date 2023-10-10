using HK.VocationalSchoolAutomason.Entities.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.DataAccess.Configurations
{
    public class Student_has_ParentInformationConfiguration : IEntityTypeConfiguration<Student_has_ParentInformation>
    {
        public void Configure(EntityTypeBuilder<Student_has_ParentInformation> builder)
        {

            builder.HasOne(sp => sp.Students)
                   .WithMany(s => s.Student_HasParentInformation)
                   .HasForeignKey(sp => sp.StudentId);

            builder.HasOne(sp => sp.Parent_Information)
                   .WithMany(p => p.Student_HasParentInformation)
                   .HasForeignKey(sp => sp.ParentInformationId);

            builder.HasKey(x=> x.Id);

        }
    }


}
