using System;
using System.Collections.Generic;

namespace TetrisRetry
{
	enum FigureTypes
	{
		I, T, J, L, S, Z, O
	}
	public class Figure
	{
		public List<String> figure { get; private set; } = new List<string>();
		public Figure()
		{
			Random random = new Random();
			figure = Create((FigureTypes) random.Next(7));
		}
		private List<string> Create(FigureTypes type)
		{
			List<string> figure = new List<string>();

			switch(type)
			{
				case FigureTypes.I:
					figure.Add(new String(Config.FILLING, 1));
					figure.Add(new String(Config.FILLING, 1));
					figure.Add(new String(Config.FILLING, 1));
					figure.Add(new String(Config.FILLING, 1));
					break;
				case FigureTypes.J:
					figure.Add($" {Config.FILLING}");
					figure.Add($" {Config.FILLING}");
					figure.Add(new String(Config.FILLING, 2));
					break;
				case FigureTypes.L:
					figure.Add($"{Config.FILLING} ");
					figure.Add($"{Config.FILLING} ");
					figure.Add(new String(Config.FILLING, 2));
					break;
				case FigureTypes.O:
					figure.Add(new string(Config.FILLING, 2));
					figure.Add(new string(Config.FILLING, 2));
					break;
				case FigureTypes.S:
					figure.Add($" {Config.FILLING}{Config.FILLING}");
					figure.Add($"{Config.FILLING}{Config.FILLING} ");
					break;
				case FigureTypes.T:
					figure.Add($" {Config.FILLING} ");
					figure.Add($"{Config.FILLING}{Config.FILLING}{Config.FILLING}");
					break;
				case FigureTypes.Z:
					figure.Add($"{Config.FILLING}{Config.FILLING} ");
					figure.Add($" {Config.FILLING}{Config.FILLING}");
					break;
			}

			return figure;
		}
	}
}
