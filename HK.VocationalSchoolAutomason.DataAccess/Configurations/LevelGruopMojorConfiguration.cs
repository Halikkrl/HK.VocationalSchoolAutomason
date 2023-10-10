using HK.VocationalSchoolAutomason.Entities.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HK.VocationalSchoolAutomason.DataAccess.Configurations
{
    public class LevelGruopMojorConfiguration : IEntityTypeConfiguration<LevelGruopMojor>
    {
        public void Configure(EntityTypeBuilder<LevelGruopMojor> builder)
        {
            builder.HasKey(lgm => lgm.Id);

            // Yabancı anahtar ilişkileri
            builder.HasOne(lgm => lgm.Majors)
                .WithMany(x => x.LevelGruopMojors)
                .HasForeignKey(lgm => lgm.MajorId);

            builder.HasOne(lgm => lgm.Level)
                .WithMany(x => x.LevelGruopMojors)
                .HasForeignKey(lgm => lgm.LevelId);

            builder.HasOne(lgm => lgm.Groups)
                .WithMany(x => x.LevelGruopMojors)
                .HasForeignKey(lgm => lgm.GruopId);

        }
    }
}
