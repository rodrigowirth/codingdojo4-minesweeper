using System;
using System.Collections.Generic;
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
                    board[i - 1, j - 1] = _minePlaces.Any(a => a.Row == i && a.Col == j)
                                      ? '*'
                                      : '0';
                }
            }

            foreach (var minePlace in _minePlaces)
            {
                var row = minePlace.Row;
                var col = minePlace.Col;

                var siblings = new List<int[]> {
                    new []{row, col + 1},
                    new []{row, col - 1},
                    new []{row + 1, col},
                    new []{row - 1, col},

                    new []{row + 1, col + 1},
                    new []{row + 1, col - 1},
                    new []{row - 1, col + 1},
                    new []{row - 1, col - 1},
                };

                foreach (var sibling in siblings)
                {
                    if (sibling[0] > 4 || sibling[0] == 0)
                        continue;
                    if (sibling[1] > 4 || sibling[1] == 0)
                        continue;

                    var currentVal = board[sibling[0] - 1, sibling[1] - 1];
                    if (currentVal == '*')
                        continue;

                    var nextVal = Convert.ToInt32(currentVal) + 1;
                    board[sibling[0] - 1, sibling[1] - 1] = Convert.ToChar(nextVal);
                }
            }

            var result = new StringBuilder();

            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    result.Append(
                        board[i - 1, j - 1]
                    );
                }
            }

            return result.ToString();
        }

        
    }
}