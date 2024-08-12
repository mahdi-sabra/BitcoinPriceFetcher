using Microsoft.EntityFrameworkCore;
using BitcoinPriceFetcher.Models;

namespace BitcoinPriceFetcher.Data
{
    public class BitcoinPriceContext : DbContext
    {
        public BitcoinPriceContext(DbContextOptions<BitcoinPriceContext> options) : base(options)
        {
        }

        public DbSet<BitcoinPrice> BitcoinPrices { get; set; }
    }
}
