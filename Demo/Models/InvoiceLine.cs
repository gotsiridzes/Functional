using Demo.Extensions;

namespace Demo.Models;

internal class InvoiceLine
{
	public string Label { get; }
	public Amount BasePrice { get; }
	public Amount Tax { get; }
	public Amount TotalPrice => this.BasePrice.Add(this.Tax.Value);

	public InvoiceLine(string label, Amount basePrice, Amount tax)
	{
		Label = label;
		BasePrice = basePrice;
		Tax = tax;
	}
}
