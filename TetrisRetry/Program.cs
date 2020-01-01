using System;
using System.Timers;

namespace TetrisRetry
{
				class Program
				{
								private static void Update(object sender, ElapsedEventArgs args)
								{
												ConsoleRenderer.Render();
								}

								static void Main(string[] args)
								{
												Config.GLOBAL_TIMER.Interval = 1000;
												Config.GLOBAL_TIMER.Elapsed += new ElapsedEventHandler(Update);
												Config.GLOBAL_TIMER.Enabled = true;

												GC.KeepAlive(Config.GLOBAL_TIMER);

												Field field = new Field();

												Console.ReadLine();
								}
				}
}
