using System.Timers;

namespace TetrisRetry
{
				public static class Config
				{
								public const int FIELD_HEIGHT = 16;
								public const int FIELD_WIDTH = 12;
								public const char FILLING = '*';

								public static Timer GLOBAL_TIMER = new Timer();
				}
}
