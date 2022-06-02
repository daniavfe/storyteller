
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Storyteller.Domain;

namespace Storyteller.Data.EntityConfiguration
{
    public class FragmentReactionConfiguration : IEntityTypeConfiguration<FragmentReaction>
    {
        public void Configure(EntityTypeBuilder<FragmentReaction> builder)
        {
            builder.ToTable("FragmentsReactions");

            builder.HasKey(x => new { x.FragmentId, x.ReactionId });

            builder.HasOne(x => x.Fragment).WithMany(x => x.Reactions).HasForeignKey(x=>x.FragmentId);
            builder.HasOne(x => x.Reaction).WithMany(x => x.Fragments).HasForeignKey(x=>x.ReactionId);

        }
    }
}
