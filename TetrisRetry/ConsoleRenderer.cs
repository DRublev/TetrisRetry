using System;
using System.Collections.Generic;

namespace TetrisRetry
{
	public class ConsoleRenderer
	{
		public static void Render(List<String> toRender)
		{
			Console.SetCursorPosition(0, 0);
			toRender.ForEach(str => Console.WriteLine(str));
		}

		public static void Render(List<String> toRender, int x, int y)
		{
			Console.SetCursorPosition(x, y);
			toRender.ForEach(str => Console.WriteLine(str));
		}
	}
}
