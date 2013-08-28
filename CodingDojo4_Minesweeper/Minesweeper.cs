using System;
using System.Text;
using System.Linq;

namespace CodingDojo4_Minesweeper
{
	public class Minesweeper
	{
		const int width = 4;
		const int height = 4;
		const char blankMark = '.';
		const char bombMark = '*';
		const char blankValue = '0';
		public char[,] Fields { get; private set; }

		public Minesweeper()
		{
			Fields = new char[width,height];
		}

		public void AddBombToFieldAt(int row, int col)
		{
			Fields[row, col] = bombMark;
		}

		public override string ToString()
		{
			var sb = new StringBuilder ();
			GoThroughAllFields (field => sb.Append (field == char.MinValue ? blankMark : field));
			return sb.ToString ();
		}

		public string Solve()
		{
			// prepare result
			var fields = Fields;
			for (int row = 0; row < height; row++) {
				for (int col = 0; col < width; col++) {
					if (fields [row, col] == bombMark) {
						fields [row, col] = bombMark;
						MarkFieldsAroundIt (row, col, fields);
					}
				}
			}

			// pass to inline
			var sb = new StringBuilder ();
			GoThroughAllFields (field => sb.Append (field == char.MinValue ? blankValue : field));
			return sb.ToString ();
		}

		private void MarkFieldsAroundIt(int row, int col, char[,] fields)
		{
			// left top
			if(row - 1 >= 0 && col - 1 >= 0)
				fields [row - 1, col - 1] = '1';
			// top
			if(row - 1 >= 0)
				fields [row - 1, col] = '1';
			// right top
			if(row - 1 >= 0 && col + 1 <= width - 1)
				fields [row - 1, col + 1] = '1';
			// left
			if(col - 1 >= 0)
				fields [row, col - 1] = '1';
			// right
			if(col + 1 <= width - 1)
				fields [row, col + 1] = '1';
			// left bottom
			if(row + 1 <= height - 1 && col - 1 >= 0)
				fields [row + 1, col - 1] = '1';
			// bottom
			if(row + 1 <= height - 1)
				fields [row + 1, col] = '1';
			// right bottom
			if(row + 1 <= height - 1 && col + 1 <= width - 1)
				fields [row + 1, col + 1] = '1';
		}

		private void GoThroughAllFields(Action<char> forEachFieldDo)
		{
			for (int row = 0; row < height; row++) {
				for (int col = 0; col < width; col++) {
					forEachFieldDo (Fields [row, col]);
				}
			}
		}
	}
}

