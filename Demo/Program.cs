internal partial class Program
{
	class Gift: IMoney
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

	private static void Main(string[] args)
	{


		Console.WriteLine("Hello, World!");
	}
}