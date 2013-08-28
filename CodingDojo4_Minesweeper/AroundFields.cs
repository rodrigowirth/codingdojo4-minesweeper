using System;

namespace CodingDojo4_Minesweeper
{
	public class AroundFields
	{
		char[,] fields;
		internal int currentRow;
		int currentCol;

		public AroundFields (char[,] fields)
		{
			this.fields = fields;
		}

		public void At(int row, int col)
		{
			currentRow = row;
			currentCol = col;
		}

		public char? TopLeft()
		{
			if(currentRow - 1 >= 0 && currentRow - 1 >= 0)
				return fields[currentRow - 1, currentRow - 1];

			return null;
		}
	}
}

