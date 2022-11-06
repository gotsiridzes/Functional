using Demo.Extensions;
using Demo.Models;
using System.Reflection.Emit;

namespace Demo.Behaviors;

internal static class ProductBuy
{
	public static InvoiceLine Buy(this Product product, int quantity, Func<Product, Amount, Amount> taxCalculator) => 
		product.GetPriceSpecification(quantity, taxCalculator).ToInvoiceLine(product.Name);

	private static InvoiceLine ToInvoiceLine(this (Amount basePrice, Amount tax) spec, string name) => new InvoiceLine(name, spec.basePrice, spec.tax);

	public static (Amount basePrice, Amount tax) GetPriceSpecification(this Product product, int quantity, Func<Product, Amount, Amount> taxCalculator) =>
		product.GetBasePrice(quantity).Map(basePrice => (basePrice, taxCalculator(product, basePrice)));

	private static Amount GetBasePrice(this Product product, int quantity) => product.UnitPrice.Scale(quantity);

	private static TResult Map<T, TResult>(this T obj, Func<T, TResult> map) => map(obj);

	public static Func<int, Amount> TotalPriceCalculator(this Product product) => product.TotalPriceCalculator((product, price) => price.DefaultTax());

	public static Func<int, Amount> TotalPriceCalculator(this Product product, Func<Product, Amount, Amount> taxCalculator) =>
		quantity => product.GetPriceSpecification(quantity, taxCalculator).Map(tuple => tuple.basePrice.Add(tuple.tax.Value));
}
