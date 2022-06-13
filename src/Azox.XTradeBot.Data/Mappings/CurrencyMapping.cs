namespace Azox.XTradeBot.Data.Mappings
{
    using Azox.Data.Mappings;
    using Azox.XTradeBot.DomainModel;

    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

    using Newtonsoft.Json;

    internal class CurrencyMapping :
        MappingBase<Currency>
    {
        protected override void Configure(EntityTypeBuilder<Currency> builder)
        {
            base.Configure(builder);

            ValueConverter<CurrencyExtended, string> converter = new(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<CurrencyExtended>(v));

            builder.Property(x => x.Extended)
                .HasConversion(converter)
                .IsRequired(false);
        }
    }
}
