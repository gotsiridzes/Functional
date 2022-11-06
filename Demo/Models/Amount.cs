namespace Demo.Models;

class Amount
{
	public decimal Value { get; }
	public Currency Currency { get; }

	public Amount(decimal value, Currency currency)
	{
		Value = value;
		Currency = currency
			?? throw new ArgumentNullException($"'{nameof(currency)}' cannot be null.");
	}
}
