using System;
using System.Text;
using System.Linq;
using System.Diagnostics;

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

		public string Solve()
		{
			// prepare result
			GoThroughAllFields ((field, row, col) => {
				if (ExistsABombAt(row, col)) {
					Fields [row, col] = bombMark;
					MarkFieldsAroundIt (row, col);
				}
			});

			// pass to inline
			return ToInline (blankValue);
		}

		private void MarkFieldsAroundIt(int row, int col)
		{
			// left top
			if(row - 1 >= 0 && col - 1 >= 0)
				IncrementPointAt(row - 1, col - 1);
			// top
			if(row - 1 >= 0)
				IncrementPointAt(row - 1, col);
			// right top
			if(row - 1 >= 0 && col + 1 <= width - 1)
				IncrementPointAt(row - 1, col + 1);
			// left
			if(col - 1 >= 0)
				IncrementPointAt(row, col - 1);
			// right
			if(col + 1 <= width - 1)
				IncrementPointAt(row, col + 1);
			// left bottom
			if(row + 1 <= height - 1 && col - 1 >= 0)
				IncrementPointAt(row + 1, col - 1);
			// bottom
			if(row + 1 <= height - 1)
				IncrementPointAt(row + 1, col);
			// right bottom
			if(row + 1 <= height - 1 && col + 1 <= width - 1)
				IncrementPointAt(row + 1, col + 1);
		}

		private void IncrementPointAt(int row, int col)
		{
			if (ExistsABombAt (row, col))
				return;

			int point; 			int.TryParse (Fields [row, col].ToString(), out point);

			point++;

			Fields [row, col] = Convert.ToChar (point.ToString());
		}

		private bool ExistsABombAt(int row, int col)
		{
			return Fields [row, col] == bombMark;
		}

		public override string ToString()
		{
			return ToInline (blankMark);
		}

		private string ToInline(char replaceEmptytWithIt)
		{
			var sb = new StringBuilder ();
			GoThroughAllFields (field => sb.Append (field == char.MinValue ? replaceEmptytWithIt : field));
			return sb.ToString ();
		}

		private void GoThroughAllFields(Action<char> forEachFieldDo)
		{
			GoThroughAllFields ((field, row, col) => forEachFieldDo(field));
		}

		private void GoThroughAllFields(Action<char, int, int> forEachFieldDo)
		{
			for (int row = 0; row < height; row++) {
				for (int col = 0; col < width; col++) {
					forEachFieldDo (Fields [row, col], row, col);
				}
			}
		}
	}
}

