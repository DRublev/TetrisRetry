using System;
using System.Collections.Generic;

namespace TetrisRetry
{
	public class Field
	{
		private Field instance;
		public Field Instance
		{
			get
			{
				if(instance == null)
				{
					instance = new Field();
				}

				return instance;
			}
		}

		private Field()
		{
			Init();
		}

		private int height = Config.FIELD_HEIGHT;
		private int width = Config.FIELD_WIDTH;
		private LinkedList<String> field = new LinkedList<String>();

		private void Init()
		{
			String empty = new string(' ', width);

			for(int i = 0; i < height; i++)
			{
				field.AddLast(empty);
			}
		}
	}
}
