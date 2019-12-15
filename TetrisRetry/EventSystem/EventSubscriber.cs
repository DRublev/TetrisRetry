using System.Reflection;

namespace TetrisRetry.EventSystem
{
	public class EventSubscriber
	{
		private BindingFlags flags =
			BindingFlags.Public |
			BindingFlags.Static |
			BindingFlags.NonPublic |
			BindingFlags.Instance |
			BindingFlags.FlattenHierarchy;

		public EventSubscriber()
		{
			MethodInfo[] methods = this.GetType().GetMethods(flags);

			foreach(MethodInfo info in methods)
			{
				if(info.GetCustomAttributes(typeof(CustomEventHandler.MessageHandler), true).Length != 0)
				{
					CustomEventHandler.Instance.RegisterHandler(this, info);
				}
			}
		}

		protected void Subscribe(string methodName)
		{
			MethodInfo info = this.GetType().GetMethod(methodName, flags);

			CustomEventHandler.Instance.RegisterHandler(this, info);
		}

		protected void Unsubscribe(string methodName)
		{
			MethodInfo info = this.GetType().GetMethod(methodName, flags);

			CustomEventHandler.Instance.UnregisterHandler(this, info);
		}
	}
}
