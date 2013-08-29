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
		char[,] fields;
		FinderFieldsPosition finderPosition;


		public Minesweeper()
		{
			fields = new char[width,height];
			finderPosition = new FinderFieldsPosition (width, height);
		}

		public void AddBombAt(int row, int col)
		{
			fields[row, col] = bombMark;
		}

		public string Solve()
		{
			// prepare result
			GoThroughAllFields ((field, row, col) => {
				if (ExistsABombAt(row, col)) {
					MarkFieldsAroundIt (row, col);
				}
			});

			// pass to inline
			return ToInline (blankValue);
		}

		private void MarkFieldsAroundIt(int row, int col)
		{
			finderPosition.At(row, col);

			IncrementPointAt(finderPosition.TopLeft());
			IncrementPointAt(finderPosition.Top());
			IncrementPointAt(finderPosition.TopRight());
			IncrementPointAt(finderPosition.Left());
			IncrementPointAt(finderPosition.Right());
			IncrementPointAt(finderPosition.BottomLeft());
			IncrementPointAt(finderPosition.Bottom());
			IncrementPointAt(finderPosition.BottomRight());
		}

		private void IncrementPointAt(int[] position)
		{
			if (position == null || position.Length < 2)
				return;

			int row = position [0];
			int col = position [1];

			if (ExistsABombAt (row, col))
				return;

			int point;
			int.TryParse (fields [row, col].ToString(), out point);

			point++;

			fields [row, col] = Convert.ToChar (point.ToString());
		}

		private bool ExistsABombAt(int row, int col)
		{
			return fields [row, col] == bombMark;
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
					forEachFieldDo (fields [row, col], row, col);
				}
			}
		}
	}
}