internal partial class Program
{
	class Cash : IMoney
	{
		public decimal Value { get; }
		public Currency Currency { get; }

		public Cash(decimal value, Currency currency)
		{
			Value = value;
			Currency = currency
				?? throw new ArgumentNullException($"'{nameof(currency)}' cannot be null.");
		}
	}
}