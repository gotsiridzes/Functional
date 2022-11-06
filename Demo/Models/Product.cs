using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Models;

internal class Product
{
	public string Name { get; }
	public Amount UnitPrice { get; }

	public Product(string name, Amount unitPrice)
	{
		Name = name ?? throw new ArgumentNullException(nameof(name));
		UnitPrice = unitPrice ?? throw new ArgumentNullException(nameof(unitPrice));
	}
}
