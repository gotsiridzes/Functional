using System;
	
namespace Demo.Extensions
{
	internal static class ConsoleExt
	{
		public static void WriteLine(this string content) => Console.WriteLine(content);
	}
}
