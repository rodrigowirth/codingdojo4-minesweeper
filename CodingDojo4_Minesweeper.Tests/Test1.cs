using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodingDojo4_Minesweeper.Tests
{
    [TestFixture]
    public class MinesweeperTest
    {
        private Minesweeper _minesweeper;

        [SetUp]
        public void Setup()
        {
            _minesweeper = new Minesweeper();
        }

        [Test]
        public void GivenAnEmptyMinesweeperShouldReturnsAll0()
        {
            Assert.AreEqual("0000000000000000", _minesweeper.Field);
        }

        [Test]
        public void GivenAnFieldWithOneBombShouldReturnOneStar()
        {
            _minesweeper.AddBombToFieldAt(0);
            Assert.AreEqual("*000000000000000", _minesweeper.Field);
        }

        [Test]
        public void GivenAnFieldWithOneBombInPosition3ShouldReturnOneStar()
        {
            _minesweeper.AddBombToFieldAt(3);
            Assert.AreEqual("000*000000000000", _minesweeper.Field);
        }

        [Test]
        public void GivenAnFieldWithOneBombInPosition0ShouldReturnCorrectSolution()
        {
            _minesweeper.AddBombToFieldAt(0);
            Assert.AreEqual("*100110000000000", _minesweeper.Solve());
        }

        [Test]
        public void GivenAnFieldWithOneBombInPosition1ShouldReturnCorrectSolution()
        {
            _minesweeper.AddBombToFieldAt(1);
            Assert.AreEqual("1*10111000000000", _minesweeper.Solve());
        }

        [Test]
        public void GivenAnFieldWithOneBombInPosition6ShouldReturnCorrectSolution()
        {
            /*
            * 0    1   1   1
            * 0    1   *   1
            * 0    1   1   1
            * 0    0   0   0
            */
            _minesweeper.AddBombToFieldAt(6);
            Assert.AreEqual("011101*101110000", _minesweeper.Solve());
        }

        [Test]
        public void GivenAnFieldWithBombInPositions5And6ShouldReturnCorrectSolution()
        {
            /*
            * 1    2   2   1
            * 1    *   *   1
            * 1    2   2   1
            * 0    0   0   0
            */
            _minesweeper.AddBombToFieldAt(5);
            _minesweeper.AddBombToFieldAt(6);
            Assert.AreEqual("12211**112210000", _minesweeper.Solve());
        }

        [Test]
        public void GivenAnEmptyField_SolutionWillBeAllZeroes()
        {
            Assert.AreEqual("0000000000000000", _minesweeper.Solve());
        }

        [Test]
        public void ShouldVerifyIfLengthIsSixteen()
        {
            Assert.AreEqual(16, _minesweeper.Field.Count);
        }

        private class Minesweeper
        {
            public List<char> Field { get; private set; }
            private List<int> BombPositions { get; set; }
            private const int SquareMatrixDimension = 4;
            private const int SquareMatrixLength = SquareMatrixDimension*SquareMatrixDimension;

            public Minesweeper()
            {
                BombPositions = new List<int>();
                Field = "0000000000000000".ToList();
            }

            public void AddBombToFieldAt(int index)
            {
                Field[index] = '*';
                BombPositions.Add(index);
            }

            

            internal List<char> Solve()
            {
                /*
                 * 0    1   2   3
                 * 4    5   6   7
                 * 8    9   10  11
                 * 12   13  14  15
                 */
                FindBombs();
                var result = new string(Field.ToArray());
                return Field;
            }

            private void FindBombs()
            {
                foreach (var pos in BombPositions)
                {
                    var adjacentPositions = new[]
                        {
                            (pos - SquareMatrixDimension) + 1,  //leftTop
                            pos - SquareMatrixDimension,        //top
                            (pos - SquareMatrixDimension) - 1,  //rightTop //BUG
                            pos - 1,                            //left
                            pos + 1,                            //right
                            (pos + SquareMatrixDimension) - 1,  //leftDown //BUG
                            pos + SquareMatrixDimension,        //down
                            (pos + SquareMatrixDimension) + 1,  //rightDown
                        };
                    foreach (var adjacentPosition in adjacentPositions)
                    {
                        if (adjacentPosition >= 0 && adjacentPosition <= SquareMatrixLength)
                        {
                            var item = Field[adjacentPosition].ToString();
                            if (!item.Equals("*"))
                                Field[adjacentPosition] = (Convert.ToInt32(item) + 1).ToString()[0];
                        }
                    }
                }
            }
        }
    }
}
