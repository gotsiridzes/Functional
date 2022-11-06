namespace Demo.Models;

class Currency
{
	public string Symbol { get; }
	public Currency(string symbol)
	{
		Symbol = !string.IsNullOrEmpty(symbol)
			? symbol
			: throw new ArgumentNullException($"'{nameof(symbol)}' cannot be null or empty.", nameof(symbol));
	}
}