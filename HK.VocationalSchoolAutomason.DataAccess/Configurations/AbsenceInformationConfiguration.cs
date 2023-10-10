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
    public class AbsenceInformationConfiguration : IEntityTypeConfiguration<AbsenceInformation>
    {
        public void Configure(EntityTypeBuilder<AbsenceInformation> builder)
        {
            
        }
    }
}
