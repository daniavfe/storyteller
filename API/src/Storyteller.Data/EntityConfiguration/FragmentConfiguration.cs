using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Storyteller.Constants;
using Storyteller.Domain;

namespace Storyteller.Data.EntityConfiguration
{
    public class FragmentConfiguration : IEntityTypeConfiguration<Fragment>
    {
        public void Configure(EntityTypeBuilder<Fragment> builder)
        {
            builder.ToTable("Fragments");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Content)
                   .HasMaxLength(FragmentConstants.ContentMaxLength)
                   .IsUnicode()
                   .IsRequired();

            builder.HasOne(x => x.Creator).WithMany(x => x.Fragments).HasForeignKey(x => x.CreatorId);
           
            builder.HasOne(x => x.Tale).WithMany(x => x.Fragments).HasForeignKey(x => x.TaleId);

            builder.HasOne(x => x.ParentFragment).WithMany(x => x.Fragments).HasForeignKey(x => x.ParentFragmentId);
        }
    }
}
