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
    public class CourseBranchConfiguration : IEntityTypeConfiguration<CourseBranch>
    {
        public void Configure(EntityTypeBuilder<CourseBranch> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasOne(x => x.Course).WithMany(x => x.CourseBranches).HasForeignKey(x => x.CourseId);
            builder.HasOne(x => x.Branch).WithMany(x => x.CourseBranches).HasForeignKey(x =>x.BranchId);
        }
    }
}
