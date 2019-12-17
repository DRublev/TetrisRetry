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
												Timer timer = new Timer();
												timer.Interval = 1000;
												timer.Elapsed += new ElapsedEventHandler(Update);
												timer.Enabled = true;

												GC.KeepAlive(timer);

												Field field = new Field();

												Console.ReadLine();
								}
				}
}
