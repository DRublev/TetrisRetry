using System;
using System.Collections.Generic;
using TetrisRetry.EventSystem;

namespace TetrisRetry
{
	public partial class Field
	{
		public static void InitFieldEvent(List<String> field)
		{
			CustomEventHandler.Instance.Call("InitFieldEvent", new object[] { field });
		}
	}
	public partial class Field
	{
		protected FieldEventManager eventManager = new FieldEventManager();

		public Field()
		{
			Init();
		}

		private int height = Config.FIELD_HEIGHT;
		private int width = Config.FIELD_WIDTH;
		private List<String> field = new List<String>();

		private void Init()
		{
			String empty = new String('-', width);

			for(int i = 0; i < height; i++)
			{
				field.Add(empty);
			}

			InitFieldEvent(field);
		}
	}
}
