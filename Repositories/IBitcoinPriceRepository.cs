using BitcoinPriceFetcher.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitcoinPriceFetcher.Repositories
{
    public interface IBitcoinPriceRepository
    {
        Task<IEnumerable<BitcoinPrice>> GetAllAsync();
        Task<BitcoinPrice> GetBySourceAsync(string source);
        Task AddAsync(BitcoinPrice price);
    }
}
