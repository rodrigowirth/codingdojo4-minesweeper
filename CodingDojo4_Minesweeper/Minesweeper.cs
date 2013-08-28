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

			for (int row = 0; row < height; row++) {
				for (int col = 0; col < width; col++) {
					Fields [row, col] = '.';
				}
			}
		}

		public void AddBombToFieldAt(int row, int col)
		{
			Fields[row, col] = bombMark;
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder ();
			for (int row = 0; row < height; row++) {
				for (int col = 0; col < width; col++) {
					sb.Append (Fields [row, col]);
				}
			}
			return sb.ToString ();
		}

		public string Solve()
		{
			char field;
			StringBuilder sb = new StringBuilder ();
			for (int row = 0; row < height; row++) {
				for (int col = 0; col < width; col++) {
					field = Fields [row, col];
					sb.Append (field == '.' ? blankValue : field);
				}
			}
			return sb.ToString ();
		}
	}
}

