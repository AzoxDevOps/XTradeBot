namespace Azox.XTradeBot.Data.Mappings
{
    using Azox.Data.Mappings;
    using Azox.XTradeBot.DomainModel;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class SystemUserExchangeMapping :
        MappingBase<SystemUserExchange>
    {
        protected override void Configure(EntityTypeBuilder<SystemUserExchange> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Exchanges);

            builder.HasOne(x => x.Exchange)
                .WithMany();

            builder.Property(x => x.ApiKey)
                .HasMaxLength(1024)
                .IsRequired();

            builder.Property(x => x.ApiSecretKey)
                .HasMaxLength(1024)
                .IsRequired();
        }
    }
}
