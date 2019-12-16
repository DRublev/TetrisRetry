using System;
using System.Collections.Generic;
using TetrisRetry.EventSystem;

namespace TetrisRetry
{
				public class FieldEventManager : EventSubscriber
				{
								[CustomEventHandler.MessageHandler]
								public void OnInitFieldEvent(List<String> frame)
								{
												ConsoleRenderer.Instance.AddToRenderQueue(frame);
								}

								[CustomEventHandler.MessageHandler]
								public void OnFieldUpdateEvent(List<String> frame)
								{
												ConsoleRenderer.Instance.AddToRenderQueue(frame);
								}
				}
}
