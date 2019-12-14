using System;
using System.Collections.Generic;

namespace TetrisRetry
{
	class Program
	{
		static void Main(string[] args)
		{
			List<String> toRender = new List<string> { "Hello, world", "This is ConsoleRenderer" };

			ConsoleRenderer.Render(toRender);

			Console.ReadLine();
		}
	}
}
