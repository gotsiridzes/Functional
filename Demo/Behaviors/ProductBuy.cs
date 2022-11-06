using Demo.Extensions;
using Demo.Models;
using System.Reflection.Emit;

namespace Demo.Behaviors;

internal static class ProductBuy
{
	public static InvoiceLine Buy(this Product product, int quantity) => product.GetPriceSpecification(quantity).ToInvoiceLine(product.Name);
	
	private static InvoiceLine ToInvoiceLine(this (Amount basePrice, Amount tax) spec, string name) => new InvoiceLine(name, spec.basePrice, spec.tax);

	public static (Amount basePrice, Amount tax) GetPriceSpecification(this Product product, int quantity) => product.GetBasePrice(quantity).Map(basePrice => (basePrice, basePrice.Scale(.2m)));

	private static Amount GetBasePrice(this Product product, int quantity) => product.UnitPrice.Scale(quantity);

	private static TResult Map<T, TResult>(this T obj, Func<T, TResult> map) => map(obj);

	public static Func<int, Amount> TotalPriceCalculator(this Product product) => quantity => product.GetPriceSpecification(quantity).Map(tuple => tuple.basePrice.Add(tuple.tax.Value));
}
