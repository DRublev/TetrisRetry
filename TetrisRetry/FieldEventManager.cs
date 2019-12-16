using System;
using System.Collections.Generic;
using TetrisRetry.EventSystem;

namespace TetrisRetry
{
	public class FieldEventManager
	{
		[CustomEventHandler.MessageHandler]
		public void OnInitFieldEvent(List<String> frame)
		{
			ConsoleRenderer.Instance.AddToRenderQueue(frame);
		}
	}
}
