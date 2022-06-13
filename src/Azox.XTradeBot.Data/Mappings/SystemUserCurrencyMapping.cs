namespace Azox.XTradeBot.Data.Mappings
{
    using Azox.Data.Mappings;
    using Azox.XTradeBot.DomainModel;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class SystemUserCurrencyMapping :
        MappingBase<SystemUserCurrency>
    {
        protected override void Configure(EntityTypeBuilder<SystemUserCurrency> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.UserExchange)
                .WithMany(x => x.Currencies);

            builder.HasOne(x => x.Currency)
                .WithMany();

            builder.Property(x => x.Available)
                .HasPrecision(36, 18)
                .IsRequired();

            builder.Property(x => x.Locked)
                .HasPrecision(36, 18)
                .IsRequired();

            builder.Property(x => x.SoftLocked)
                .HasPrecision(36, 18)
                .IsRequired();
        }
    }
}
