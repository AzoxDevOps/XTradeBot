namespace Azox.XTradeBot.Data
{
    using Azox.Data;

    using Microsoft.EntityFrameworkCore;

    internal class XTradeBotDbContext :
        DbContextBase<XTradeBotDbContext>
    {
        public XTradeBotDbContext(DbContextOptions<XTradeBotDbContext> options) :
            base(options)
        {
        }
    }
}
