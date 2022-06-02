using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Storyteller.Constants;
using Storyteller.Domain;

namespace Storyteller.Data.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Alias)
                   .HasMaxLength(UserConstants.AliasMaxLength)
                   .IsUnicode()
                   .IsRequired();

            builder.Property(x => x.Email)
                   .HasMaxLength(UserConstants.EmailMaxLength)
                   .IsUnicode()
                   .IsRequired();

            builder.Property(x => x.PasswordHash)
                   .HasMaxLength(200)
                   .IsUnicode()
                   .IsRequired();

            builder.Property(x => x.CreationDate)
                   .IsRequired();
        }
    }
}
