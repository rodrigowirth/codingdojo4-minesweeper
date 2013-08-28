using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingDojo4_Minesweeper.Tests
{
    public class MinePlace
    {
        public int Row { get; private set; }
        public int Col { get; private set; }

        public MinePlace(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }
}
