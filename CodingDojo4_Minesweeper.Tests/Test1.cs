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
            _minesweeper.AddBombToFieldAt(1);
            Assert.AreEqual("1000000000000000", _minesweeper.Solve());
        }

        [Test]
        public void GivenAnEmptyField_SolutionWillBeAllZeroes()
        {
            Assert.AreEqual("0000000000000000", _minesweeper.Solve());
        }

        [Test]
        public void GivenAnField_ShouldVerify()
        {
            Assert.AreEqual("0000000000000000", _minesweeper.Solve());
        }

        private class Minesweeper
        {

            public char[] Field { get; private set; }
            
            public Minesweeper()
            {
                Field = "0000000000000000".ToCharArray();
            }

            public void AddBombToFieldAt(int index)
            {
                Field[index] = '*';
            }

            internal char[] Solve()
            {
                //var row1 = Field.ToString().Substring(0, 4);
                //var row2 = Field.ToString().Substring(4, 4);
                //var row3 = Field.ToString().Substring(8, 4);
                //var row4 = Field.ToString().Substring(12, 4);
                return Field;
            }
        }
    }
}
