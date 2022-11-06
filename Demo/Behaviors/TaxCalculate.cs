using Demo.Extensions;
using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Behaviors
{
	internal static class TaxCalculate
	{
		public static Amount DefaultTax(this Amount basePrice) => basePrice.RelativeTax(.2m);
		
		public static Amount RelativeTax(this Amount basePrice, decimal factor) => basePrice.Scale(factor);

		public static Amount CalculateTax(this Product product, Amount basePrice) => basePrice.DefaultTax();
	}
}
