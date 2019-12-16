using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace TetrisRetry.EventSystem
{
	public class CustomEventHandler
	{
		private static CustomEventHandler instance = null;
		public static CustomEventHandler Instance
		{
			get
			{
				if(instance == null)
				{
					instance = new CustomEventHandler();
				}

				return instance;
			}
		}

		public class MessageHandler : Attribute
		{
		}

		private class MessageHandlerData
		{
			public object Caller;
			public MethodInfo Method;
		}

		private Hashtable subscribers = new Hashtable();
		private List<MessageHandlerData> removed = new List<MessageHandlerData>();

		/// <summary>
		/// Method name withoun "On"
		/// </summary>
		private string GetMethodName(string methodName)
		{
			return methodName.Substring(2);
		}

		public void RegisterHandler(object caller, MethodInfo methodInfo)
		{
			string messageId = GetMethodName(methodInfo.Name);

			if(!subscribers.ContainsKey(messageId))
			{
				subscribers.Add(messageId,
					new List<MessageHandlerData>() {
						new MessageHandlerData
						{
							Caller = caller,
							Method = methodInfo
						}
					});
			}

			List<MessageHandlerData> handlers = (List<MessageHandlerData>) subscribers[messageId];

			handlers.Add(new MessageHandlerData() { Caller = caller, Method = methodInfo });
		}

		public void UnregisterHandler(object caller, MethodInfo methodInfo)
		{
			string messageId = GetMethodName(methodInfo.Name);

			if(subscribers.ContainsKey(messageId))
			{
				List<MessageHandlerData> handlers = (List<MessageHandlerData>) subscribers[messageId];

				for(int i = 0; i < handlers.Count; i++)
				{
					var handler = handlers[i];

					if(handler.Caller == caller && handler.Method == methodInfo)
					{
						handlers.Remove(handler);
						return;
					}
				}
			}
		}

		public void Call(string messageId, object[] args = null)
		{
			if(!subscribers.ContainsKey(messageId))
			{
				return;
			}
			Console.WriteLine("Event call");
			List<MessageHandlerData> handlers = (List<MessageHandlerData>) subscribers[messageId];

			for(int i = 0; i < handlers.Count; i++)
			{
				MessageHandlerData handler = handlers[i];
				object caller = handler.Caller;

				if(caller != null)
				{
					handler.Method.Invoke(handler.Caller, args);
				}
				else
				{
					removed.Add(handler);
				}
			}

			removed.ForEach(r =>
			{
				handlers.Remove(r);
			});

			removed.Clear();
		}
	}
}
