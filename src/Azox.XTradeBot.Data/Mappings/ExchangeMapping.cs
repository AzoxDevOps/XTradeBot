namespace Azox.XTradeBot.Data.Mappings
{
    using Azox.Data.Mappings;
    using Azox.XTradeBot.DomainModel;

    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

    using Newtonsoft.Json;

    internal class ExchangeMapping :
        MappingBase<Exchange>
    {
        protected override void Configure(EntityTypeBuilder<Exchange> builder)
        {
            base.Configure(builder);

            ValueConverter<ExchangeExtended?, string> converter = new(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<ExchangeExtended>(v));

            builder.Property(x => x.Extended)
                .HasConversion(converter)
                .IsRequired(false);
        }
    }
}
