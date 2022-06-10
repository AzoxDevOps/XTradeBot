namespace Azox.XTradeBot.Data.Mapping
{
    using Azox.Data.Mappings;
    using Azox.XTradeBot.DomainModel;

    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class ExchangePairMapping :
        MappingBase<ExchangePair>
    {
        protected override void Configure(EntityTypeBuilder<ExchangePair> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.Exchange)
                .WithMany(x => x.Pairs);

            builder.HasOne(x => x.BaseAsset)
                .WithMany();

            builder.HasOne(x => x.QuoteAsset)
                .WithMany();

            builder.Property(x => x.PairType)
                .IsRequired();

            builder.Ignore(x => x.SymbolShort);
            builder.Ignore(x => x.SymbolFull);
        }
    }
}
