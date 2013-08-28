using System;
using System.Linq;
using System.Text;

namespace CodingDojo4_Minesweeper.Tests
{
    public class Minesweeper
    {
        private readonly MinePlace[] _minePlaces;
        public Minesweeper(params MinePlace[] minePlaces)
        {
            _minePlaces = minePlaces;
        }

        public string DrawBoard()
        {
            var result = new StringBuilder();

            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    result.Append(
                        _minePlaces.Any(a => a.Row == i && a.Col == j) ? "*" : "-"
                    );
                }
            }

            return result.ToString();
        }

        public string GetResult()
        {
            var board = new char[4,4];

            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    board[i, j] = _minePlaces.Any(a => a.Row == i && a.Col == j)
                                      ? '*'
                                      : '-';
                }
            }

            foreach (var minePlace in _minePlaces)
            {
                var row = minePlace.Row;
                var col = minePlace.Col;

                var prevCol = col - 1;
                var nextCol = col + 1;

                if (prevCol != 0 && prevCol < col) 
                    board[row, prevCol] = '1';
                
                if (nextCol != 5 && nextCol > col)
                    board[row, nextCol] = '1';
            }

            return board.ToString();
        }
    }
}