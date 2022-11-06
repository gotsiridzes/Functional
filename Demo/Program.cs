using Demo.Behaviors;
using Demo.Extensions;
using Demo.Interfaces;
using Demo.Models;
using System;

internal partial class Program
{
	static (IMoney final, Amount added) Add(IMoney money, Amount amount, DateOnly at)
	{
		switch (money)
		{
			case Cash cash when amount.Currency == cash.Currency:
				return (new Cash(cash.Value + amount.Value, cash.Currency), amount);
			case Cash _:
				return (money, new Amount(0, amount.Currency));
			case Gift gift when amount.Currency == gift.Currency:
				return (new Gift(gift.Value + amount.Value, gift.Currency, gift.ValidBefore), amount);
			case Gift _:
				return (money, new Amount(0, amount.Currency));
			default: throw new ArgumentException();
		}
	}

	static void PrintPrices(Product product, int from, int to) => Enumerable.Range(from, to - from + 1)
			.Select(quantity => (quantity, totalPrice: product.Buy(quantity).TotalPrice))
			.Select(tuple => $"{tuple.quantity}\t{tuple.totalPrice}")
			.Join(Environment.NewLine)
			.WriteLine();

	private static void Main(string[] args)
	{
		var product = new Product("laptop", new Amount(1500m, new Currency("USD")));

		PrintPrices(product, 1, 10);

		//Console.WriteLine("Hello, World!");
	}
}