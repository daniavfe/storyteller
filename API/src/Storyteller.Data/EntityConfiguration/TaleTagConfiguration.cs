using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Storyteller.Domain;

namespace Storyteller.Data.EntityConfiguration
{
    public class TaleTagConfiguration : IEntityTypeConfiguration<TaleTag>
    {
        public void Configure(EntityTypeBuilder<TaleTag> builder)
        {
            builder.ToTable("TalesTags");

            builder.HasKey(x => new { x.TaleId, x.TagId });

            builder.HasOne(x => x.Tale).WithMany(x => x.Tags).HasForeignKey(x => x.TaleId);
            builder.HasOne(x => x.Tag).WithMany(x => x.Tales).HasForeignKey(x => x.Tag);

        }
    }
}
