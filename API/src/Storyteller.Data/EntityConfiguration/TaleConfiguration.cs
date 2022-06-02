using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Storyteller.Constants;
using Storyteller.Domain;

namespace Storyteller.Data.EntityConfiguration
{
    public class TaleConfiguration : IEntityTypeConfiguration<Tale>
    {
        public void Configure(EntityTypeBuilder<Tale> builder)
        {
            builder.ToTable("Tales");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                   .HasMaxLength(TaleConstants.TitleMaxLength)
                   .IsUnicode()
                   .IsRequired();

            builder.Property(x => x.Abstract)
                   .HasMaxLength(TaleConstants.AbstractMaxLength)
                   .IsUnicode()
                   .IsRequired();

            builder.Property(x => x.Language)
                   .HasMaxLength(TaleConstants.LanguageMaxLength)
                   .IsUnicode()
                   .IsRequired();

            builder.Property(x => x.CreationDate)
                   .IsRequired();

            builder.HasOne(x=>x.Creator).WithMany(x=>x.Tales).HasForeignKey(x=>x.CreatorId);
        }
    }
}
