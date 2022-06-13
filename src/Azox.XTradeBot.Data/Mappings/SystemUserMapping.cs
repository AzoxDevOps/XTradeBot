namespace Azox.XTradeBot.Data.Mappings
{
    using Azox.Data.Mappings;
    using Azox.XTradeBot.DomainModel;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
    using Newtonsoft.Json;

    internal class SystemUserMapping :
        MappingBase<SystemUser>
    {
        protected override void Configure(EntityTypeBuilder<SystemUser> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.UserGroup)
                .WithMany(x => x.Memberships);

            builder.Property(x => x.Username)
               .HasMaxLength(1024)
               .IsRequired();

            builder.Property(x => x.PasswordHash)
                .HasMaxLength(1024)
                .IsRequired();

            builder.Property(x => x.PasswordSalt)
                .HasMaxLength(1024)
                .IsRequired();

            builder.Property(x => x.PasswordHashed)
                .IsRequired();

            builder.Property(x => x.FirstName)
                .HasMaxLength(1024);

            builder.Property(x => x.LastName)
                .HasMaxLength(1024);

            builder.Property(x => x.IsActive)
                .IsRequired();

            builder.Property(x => x.IsLocked)
                .IsRequired();

            builder.Property(x => x.FailedLoginAttemptCount)
                .IsRequired();

            builder.Property(x => x.LastLockTime);

            builder.Property(x => x.LastLoginTime);

            builder.HasIndex(x => x.Username)
                .IsUnique();

            builder.Ignore(x => x.FullName);

            ValueConverter<SystemUserExtended, string> converter = new(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<SystemUserExtended>(v));

            builder.Property(x => x.Extended)
                .HasConversion(converter)
                .IsRequired(false);
        }
    }
}
