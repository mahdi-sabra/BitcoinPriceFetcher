using BitcoinPriceFetcher.Models;
using System.Threading.Tasks;

namespace BitcoinPriceFetcher.Services
{
	public interface IBitcoinPriceService
	{
		Task<BitcoinPrice> FetchBitcoinPriceAsync();
	}
}
