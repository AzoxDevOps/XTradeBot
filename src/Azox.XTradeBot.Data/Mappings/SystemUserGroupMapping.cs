namespace Azox.XTradeBot.Data.Mappings
{
    using Azox.Data.Mappings;
    using Azox.XTradeBot.DomainModel;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class SystemUserGroupMapping :
        MappingBase<SystemUserGroup>
    {
        protected override void Configure(EntityTypeBuilder<SystemUserGroup> builder)
        {
            base.Configure(builder);
        }
    }
}
