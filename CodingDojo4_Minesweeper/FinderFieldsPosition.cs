using System;

namespace CodingDojo4_Minesweeper
{
	public class FinderFieldsPosition
	{
		internal int row;
		int col;
		int width;
		int height;

		public FinderFieldsPosition (int width, int height)
		{
			this.width = width;
			this.height = height;
		}

		public void At(int row, int col)
		{
			this.row = row;
			this.col = col;
		}

		public int[] TopLeft()
		{
			if(row - 1 >= 0 && col - 1 >= 0)
				return Position(row - 1, col - 1);

			return null;
		}

		public int[] Top()
		{
			if(row - 1 >= 0)
				return Position(row - 1, col);

			return null;
		}

		public int[] TopRight()
		{
			if(row - 1 >= 0 && col + 1 <= width - 1)
				return Position(row - 1, col + 1);

			return null;
		}

		public int[] Left()
		{
			if(col - 1 >= 0)
				return Position(row, col - 1);

			return null;
		}

		public int[] Right()
		{
			if(col + 1 <= width - 1)
				return Position(row, col + 1);

			return null;
		}

		public int[] BottomLeft()
		{
			if(row + 1 <= height - 1 && col - 1 >= 0)
				return Position(row + 1, col - 1);

			return null;
		}

		public int[] Bottom()
		{
			if(row + 1 <= height - 1)
				return Position(row + 1, col);

			return null;
		}

		public int[] BottomRight()
		{
			if(row + 1 <= height - 1 && col + 1 <= width - 1)
				return Position(row + 1, col + 1);

			return null;
		}

		private int[] Position(int row, int col)
		{
			return new int[] { row, col };
		}
	}
}

