using Demo.Extensions;
using Demo.Models;

namespace Demo.Behaviors;

internal static class ProductBuy
{
	public static InvoiceLine Buy(this Product product, int quantity) =>
		new InvoiceLine(
			product.Name,
			product.UnitPrice.Scale(quantity),
			product.UnitPrice.Scale(quantity).Scale(.20m));
}
