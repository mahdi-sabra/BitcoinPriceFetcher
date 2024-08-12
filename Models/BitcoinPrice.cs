using System;

namespace BitcoinPriceFetcher.Models
{
	public class BitcoinPrice
	{
		public int Id { get; set; }
		public string Source { get; set; }
		public decimal Price { get; set; }
		public DateTime Timestamp { get; set; }
	}
}
