using BitcoinPriceFetcher.Data;
using BitcoinPriceFetcher.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitcoinPriceFetcher.Repositories
{
    public class BitcoinPriceRepository : IBitcoinPriceRepository
    {
        private readonly BitcoinPriceContext _context;

        public BitcoinPriceRepository(BitcoinPriceContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BitcoinPrice>> GetAllAsync()
        {
            return await _context.BitcoinPrices.ToListAsync();
        }

        public async Task<BitcoinPrice> GetBySourceAsync(string source)
        {
            return await _context.BitcoinPrices
                .OrderByDescending(p => p.Timestamp)
                .FirstOrDefaultAsync(p => p.Source == source);
        }

        public async Task AddAsync(BitcoinPrice price)
        {
            _context.BitcoinPrices.Add(price);
            await _context.SaveChangesAsync();
        }
    }

}
