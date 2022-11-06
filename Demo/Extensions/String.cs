using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Extensions
{
	internal static class StringExt
	{
		public static string Join(this IEnumerable<string> sequence, string separator) =>
			string.Join(separator, sequence.ToArray());

	}
}
