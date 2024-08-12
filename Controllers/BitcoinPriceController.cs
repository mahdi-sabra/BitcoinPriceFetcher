using BitcoinPriceFetcher.Models;
using BitcoinPriceFetcher.Repositories;
using BitcoinPriceFetcher.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitcoinPriceFetcher.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BitcoinPriceController : ControllerBase
    {
        private readonly IBitcoinPriceRepository _repository;
        private readonly IEnumerable<IBitcoinPriceService> _services;
        private readonly IPriceSourceProvider _priceSourceProvider;

        public BitcoinPriceController(IBitcoinPriceRepository repository, IEnumerable<IBitcoinPriceService> services, IPriceSourceProvider priceSourceProvider)
        {
            _repository = repository;
            _services = services;
            _priceSourceProvider = priceSourceProvider;
        }
        [HttpGet("available-sources")]
        public IActionResult GetAvailableSources()
        {
            var sources = _priceSourceProvider.GetAvailableSources();
            return Ok(sources);
        }
        // Fetch and save bitcoin price for all sources
        [HttpGet("fetch-all")]
        public async Task<IActionResult> FetchAllPrices()
        {
            foreach (var service in _services)
            {
                var price = await service.FetchBitcoinPriceAsync();
                await _repository.AddAsync(price);
            }
            return Ok();
        }

        // Fetch bitcoin price for a specific source
        [HttpGet("fetch/{source}")]
        public async Task<IActionResult> FetchPrice(string source)
        {
            var service = _services.FirstOrDefault(s => s.GetType().Name.StartsWith(source));
            if (service == null) return NotFound("Source not found");

            var price = await service.FetchBitcoinPriceAsync();
            await _repository.AddAsync(price);

            return Ok(price);
        }

        // Get history of bitcoin prices
        [HttpGet("history")]
        public async Task<IEnumerable<BitcoinPrice>> GetHistory()
        {
            return await _repository.GetAllAsync();
        }
    }
}
