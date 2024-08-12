public class PriceSourceProvider : IPriceSourceProvider
{
    private readonly List<string> _sources = new List<string>
    {
        "Bitstamp",
        "Bitfinex"
    };

    public IEnumerable<string> GetAvailableSources()
    {
        return _sources;
    }
}
