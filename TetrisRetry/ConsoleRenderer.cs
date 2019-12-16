using System;
using System.Collections.Generic;

namespace TetrisRetry
{
	public class ConsoleRenderer
	{
		private static ConsoleRenderer instance = null;
		public static ConsoleRenderer Instance
		{

			get
			{
				if(instance == null)
				{
					instance = new ConsoleRenderer();
				}

				return instance;
			}
		}

		public static Queue<List<String>> frames = new Queue<List<string>>();

		public void AddToRenderQueue(List<String> frame)
		{
			frames.Enqueue(frame);
		}

		public static void Render()
		{
			if(frames.Count == 0)
			{
				return;
			}

			List<String> frame = frames.Dequeue();

			for(int i = 0; i < frame.Count; i++)
			{
				Console.SetCursorPosition(0, i);
				Console.Write(frame[i]);
			}
		}

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
