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

        public static void FieldUpdateEvent(List<String> field)
        {
            CustomEventHandler.Instance.Call("FieldUpdateEvent", new object[] { field });
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

            for (int i = 0; i < height; i++)
            {
                field.Add(empty);
            }

            InitFieldEvent(field);
            AddFigure();
        }

        private void AddFigure()
        {
            Figure fig = new Figure();

            List<int> x = new List<int>();
            List<int> y = new List<int>();

            for (int i = 0; i < fig.figure.Count; i++)
            {
                for (int j = 0; j < fig.figure[0].Length; j++)
                {
                    if (fig.figure[i][j] == Config.FILLING)
                    {
                        x.Add(((width - fig.figure[0].Length) / 2) + j);
                        y.Add(height - i - 1);
                    }
                }
            }

            AddToField(new List<int[]>() { x.ToArray(), y.ToArray() });

            FieldUpdateEvent(field);
        }

        private void AddToField(List<int[]> coords)
        {
            int[] x = coords[0];
            int[] y = coords[1];

            for (int i = 0; i < x.Length; i++)
            {
                char[] row = field[y[i]].ToCharArray();
                row[x[i]] = Config.FILLING;
                field[y[i]] = new String(row);
            }
        }

        private void Move(int fromX, int fromY, int toX, int toY)
        {
            char[] row = field[toY].ToCharArray();
            row[toX] = field[fromY][fromX];
            field[toY] = new String(row);
        }
    }
}