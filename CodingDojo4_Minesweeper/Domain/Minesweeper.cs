using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo4_Minesweeper.Domain
{
    public class Minesweeper
    {
        private Boolean[,] _spreadsheet;

        public Int32 Dimension
        {
            get { return _spreadsheet.GetLength(0); }
        }

        public Minesweeper(Int32 dimension)
        {
            if (dimension <= 0)
                throw new ArgumentException("The dimension should be a positive number");

            _spreadsheet = new bool[dimension, dimension];
        }

        public void AddBomb(Int32 x, Int32 y)
        {
            if (x >= Dimension || y >= Dimension)
                throw new InvalidOperationException("You can not add a bomb in that position");

            _spreadsheet[x, y] = true;
        }

        public void RemoveBomb(Int32 x, Int32 y)
        {
            if (x >= Dimension || y >= Dimension)
                throw new InvalidOperationException("You can not remove a bomb in that position");

            _spreadsheet[x, y] = false;
        }

        public Int32 GetValue(Int32 x, Int32 y)
        {
            if (this.HasBombAt(x, y))
                return -1;
            
            Int32 count = 0;

            if (this.HasBombOnTheLeftAt(x, y))
                count++;

            if (this.HasBombOnTheRightAt(x, y))
                count++;

            if (this.HasBombAtTheTopAt(x, y))
                count++;

            if (this.HasBombAtTheBottomAt(x, y))
                count++;

            if (this.HasBombOnLeftBottomAt(x, y))
                count++;

            if (this.HasBombOnRightBottomAt(x, y))
                count++;

            if (this.HasBombOnLeftTopAt(x, y))
                count++;

            if (this.HasBombOnRightTopAt(x, y))
                count++;

            return count;
        }

        public Boolean HasBombAt(Int32 x, Int32 y)
        {
            if (x < 0 || y < 0 || x >= Dimension || y >= Dimension)
                return false;

            return _spreadsheet[x, y];
        }

        private Boolean HasBombOnTheLeftAt(Int32 x, Int32 y)
        {
            return this.HasBombAt(x - 1, y);
        }

        private Boolean HasBombOnTheRightAt(Int32 x, Int32 y)
        {
            return this.HasBombAt(x + 1, y);
        }

        private Boolean HasBombAtTheTopAt(Int32 x, Int32 y)
        {
            return this.HasBombAt(x, y - 1);
        }

        private Boolean HasBombAtTheBottomAt(Int32 x, Int32 y)
        {
            return this.HasBombAt(x, y + 1);
        }

        private Boolean HasBombOnLeftBottomAt(Int32 x, Int32 y)
        {
            return this.HasBombAt(x - 1, y + 1);
        }

        private Boolean HasBombOnRightBottomAt(Int32 x, Int32 y)
        {
            return this.HasBombAt(x + 1, y + 1);
        }

        private Boolean HasBombOnLeftTopAt(Int32 x, Int32 y)
        {
            return this.HasBombAt(x - 1, y - 1);
        }

        private Boolean HasBombOnRightTopAt(Int32 x, Int32 y)
        {
            return this.HasBombAt(x + 1, y - 1);
        }
    }
}
