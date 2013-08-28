using System;

namespace CodingDojo4_Minesweeper
{
	public class Minesweeper
	{
		public char[] Field { get; private set; }

		public Minesweeper()
		{
			Field = "0000000000000000".ToCharArray();
		}

		public void AddBombToFieldAt(int index)
		{
			Field[index] = '*';
		}

		public char[] Solve()
		{
			//var row1 = Field.ToString().Substring(0, 4);
			//var row2 = Field.ToString().Substring(4, 4);
			//var row3 = Field.ToString().Substring(8, 4);
			//var row4 = Field.ToString().Substring(12, 4);
			return Field;
		}
	}
}

