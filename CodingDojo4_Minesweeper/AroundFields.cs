using System;

namespace CodingDojo4_Minesweeper
{
	public class AroundFields
	{
		char[,] fields;
		internal int row;
		int col;
		int width;
		int height;

		public AroundFields (char[,] fields)
		{
			this.fields = fields;
			width = fields.GetLength (0);
			height = fields.GetLength(1);
		}

		public void At(int row, int col)
		{
			this.row = row;
			this.col = col;
		}

		public char? TopLeft()
		{
			if(row - 1 >= 0 && col - 1 >= 0)
				return fields[row - 1, col - 1];

			return null;
		}

		public char? Top()
		{
			if(row - 1 >= 0)
				return fields[row - 1, col];

			return null;
		}

		public char? TopRight()
		{
			if(row - 1 >= 0 && col + 1 <= width - 1)
				return fields[row - 1, col + 1];

			return null;
		}

		public char? Left()
		{
			if(col - 1 >= 0)
				return fields[row, col - 1];

			return null;
		}

		public char? Right()
		{
			if(col + 1 <= width - 1)
				return fields[row, col + 1];

			return null;
		}

		public char? BottomLeft()
		{
			if(row + 1 <= height - 1 && col - 1 >= 0)
				return fields[row + 1, col - 1];

			return null;
		}

		public char? Bottom()
		{
			if(row + 1 <= height - 1)
				return fields[row + 1, col];

			return null;
		}

		public char? BottomRight()
		{
			if(row + 1 <= height - 1 && col + 1 <= width - 1)
				return fields[row + 1, col + 1];

			return null;
		}
	}
}

