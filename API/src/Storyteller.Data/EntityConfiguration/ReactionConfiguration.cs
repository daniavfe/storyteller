using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Storyteller.Constants;
using Storyteller.Domain;

namespace Storyteller.Data.EntityConfiguration
{
    public class ReactionConfiguration : IEntityTypeConfiguration<Reaction>
    {
        public void Configure(EntityTypeBuilder<Reaction> builder)
        {
            builder.ToTable("Reactions");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .HasMaxLength(ReactionConstants.NameMaxLength)
                   .IsUnicode()
                   .IsRequired();
        }
    }
}
