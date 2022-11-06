using Demo.Models;

namespace Demo.Extensions;

internal static class ArithmeticExt
{
	public static Amount Scale(this Amount amount, decimal factor) =>
		new Amount(amount.Value * factor, amount.Currency);

	public static Amount Add(this Amount amount, decimal value) =>
		new Amount(amount.Value + value, amount.Currency);
}
