using Demo.Interfaces;

namespace Demo.Models;

class Gift : IMoney
{
	public decimal Value { get; }
	public Currency Currency { get; }
	public DateTime ValidBefore { get; }

	public Gift(decimal value, Currency currency, DateTime validBefore)
	{
		Value = value;
		Currency = currency ?? throw new ArgumentNullException($"'{nameof(currency)}' cannot be null.");
		ValidBefore = validBefore;
	}
}