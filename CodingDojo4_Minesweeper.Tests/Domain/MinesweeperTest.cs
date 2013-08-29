using System;
using CodingDojo4_Minesweeper.Domain;
using NUnit.Framework;

namespace CodingDojo4_Minesweeper.Tests.Domain
{
    [TestFixture]
    public class MinesweeperTest
    {
        private int _dimension = 4;
        private Minesweeper _minesweeper;

        [SetUp]
        public void Setup()
        {
            _minesweeper = new Minesweeper(_dimension);
        }

        [Test]
        public void ShouldNotCreateAMinesweeperWithDimensionLessThanOne()
        {
            Assert.Throws<ArgumentException>(() => new Minesweeper(0));
            Assert.Throws<ArgumentException>(() => new Minesweeper(-1));
        }

        [Test]        
        public void GivenASizeItShouldBeCreatedWithTheCorrectDimension()
        {
            Assert.AreEqual(_dimension, _minesweeper.Dimension);
        }

        [Test]
        public void MakeSureANewMinesweeperIsCreatedWithoutBombs()
        {
            for (int i = 0; i < _minesweeper.Dimension; i++)
            {
                for (int j = 0; j < _minesweeper.Dimension; j++)
                {
                    Assert.IsFalse(_minesweeper.HasBombAt(i, j));
                }
            }
        }

        [Test]
        public void ShouldAddBombInTheCorrectPlace()
        {
            _minesweeper.AddBomb(0, 0);
            _minesweeper.AddBomb(1, 2);

            Assert.IsTrue(_minesweeper.HasBombAt(0, 0));
            Assert.IsTrue(_minesweeper.HasBombAt(1, 2));
        }    

        [Test]
        public void ShouldNotAddBombInAIndexBesidesTheLimitOfTheSpreadsheet()
        {
            Assert.Throws<InvalidOperationException>(() => _minesweeper.AddBomb(5, 0));
        }
    
        [Test]
        public void ShouldRemoveBombInTheCorrectPlace()
        {
            _minesweeper.AddBomb(2, 2);
            _minesweeper.AddBomb(0, 3);
            _minesweeper.AddBomb(2, 1);

            _minesweeper.RemoveBomb(2, 2);
            _minesweeper.RemoveBomb(0, 3);
            _minesweeper.RemoveBomb(2, 1);

            Assert.IsFalse(_minesweeper.HasBombAt(2, 2));
            Assert.IsFalse(_minesweeper.HasBombAt(0, 3));
            Assert.IsFalse(_minesweeper.HasBombAt(2, 1));

        }

        [Test]
        public void ShouldNotRemoveBombInAIndexBesidesTheLimitOfTheSpreadsheet()
        {
            Assert.Throws<InvalidOperationException>(() => _minesweeper.RemoveBomb(5, 0));
        }

        [TestCase(0, 0, 1, 0, Result = 1)]
        [TestCase(0, 0, 0, 1, Result = 1)]
        [TestCase(0, 0, 1, 1, Result = 1)]
        [TestCase(0, 0, 3, 3, Result = 0)]
        [TestCase(1, 1, 0, 0, Result = 1)]
        [TestCase(1, 1, 1, 0, Result = 1)]
        [TestCase(1, 1, 2, 0, Result = 1)]
        [TestCase(1, 1, 0, 1, Result = 1)]
        [TestCase(1, 1, 1, 1, Result = -1)]
        [TestCase(1, 1, 2, 1, Result = 1)]
        [TestCase(1, 1, 0, 2, Result = 1)]
        [TestCase(1, 1, 1, 2, Result = 1)]
        [TestCase(1, 1, 2, 2, Result = 1)] 
        public Int32 ShouldHasACorrectValueAddingOneBomb(Int32 xAdd, Int32 yAdd, Int32 xResult, Int32 yResult)
        {
            _minesweeper.AddBomb(xAdd, yAdd);
            return _minesweeper.GetValue(xResult, yResult);
        }

        [Test]
        public void ShouldHasTheValueTwoAt2x1WhenAddedBombsAt1x1And3x1()
        {
            _minesweeper.AddBomb(1, 1);
            _minesweeper.AddBomb(3, 1);
            Assert.AreEqual(2, _minesweeper.GetValue(2, 1));
        }

        [TestCase(0, 0, Result = 1)]
        [TestCase(1, 0, Result = 1)]
        [TestCase(2, 0, Result = 2)]
        [TestCase(3, 0, Result = 1)]
        [TestCase(0, 1, Result = 2)]
        [TestCase(1, 1, Result = -1)]
        [TestCase(2, 1, Result = 3)]
        [TestCase(3, 1, Result = -1)]
        [TestCase(0, 2, Result = 2)]
        [TestCase(1, 2, Result = -1)]
        [TestCase(2, 2, Result = 5)]
        [TestCase(3, 2, Result = 3)]
        [TestCase(0, 3, Result = 1)]
        [TestCase(1, 3, Result = 2)]
        [TestCase(2, 3, Result = -1)]
        [TestCase(3, 3, Result = -1)]
        public Int32 ShouldHasTheCorrectResultAtThePositionWhenUsingTheFirstGame(Int32 x, Int32 y)
        {
            this.CreateFirstGame();
            return _minesweeper.GetValue(x, y);
        }

        [TestCase(0, 0, Result = -1)]
        [TestCase(1, 0, Result = 2)]
        [TestCase(2, 0, Result = 0)]
        [TestCase(3, 0, Result = 0)]
        [TestCase(0, 1, Result = -1)]
        [TestCase(1, 1, Result = 4)]
        [TestCase(2, 1, Result = 1)]
        [TestCase(3, 1, Result = 0)]
        [TestCase(0, 2, Result = -1)]
        [TestCase(1, 2, Result = -1)]
        [TestCase(2, 2, Result = 3)]
        [TestCase(3, 2, Result = 1)]
        [TestCase(0, 3, Result = 3)]
        [TestCase(1, 3, Result = -1)]
        [TestCase(2, 3, Result = 3)]
        [TestCase(3, 3, Result = -1)]
        public Int32 ShouldHasTheCorrectResultAtThePositionWhenUsingTheSecondGame(Int32 x, Int32 y)
        {
            this.CreateSecondGame();
            return _minesweeper.GetValue(x, y);
        }

        [TestCase(0, 0, Result = -1)]
        [TestCase(1, 0, Result = 4)]
        [TestCase(2, 0, Result = -1)]
        [TestCase(3, 0, Result = -1)]
        [TestCase(4, 0, Result = -1)]
        [TestCase(5, 0, Result = 2)]
        [TestCase(0, 1, Result = -1)]
        [TestCase(1, 1, Result = 5)]
        [TestCase(2, 1, Result = -1)]
        [TestCase(3, 1, Result = 8)]
        [TestCase(4, 1, Result = -1)]
        [TestCase(5, 1, Result = 3)]
        [TestCase(0, 2, Result = 1)]
        [TestCase(1, 2, Result = 3)]
        [TestCase(2, 2, Result = -1)]
        [TestCase(3, 2, Result = -1)]
        [TestCase(4, 2, Result = -1)]
        [TestCase(5, 2, Result = 3)]
        [TestCase(0, 3, Result = 1)]
        [TestCase(1, 3, Result = 2)]
        [TestCase(2, 3, Result = 3)]
        [TestCase(3, 3, Result = 4)]
        [TestCase(4, 3, Result = 4)]
        [TestCase(5, 3, Result = -1)]
        [TestCase(0, 4, Result = -1)]
        [TestCase(1, 4, Result = 2)]
        [TestCase(2, 4, Result = 2)]
        [TestCase(3, 4, Result = -1)]
        [TestCase(4, 4, Result = 2)]
        [TestCase(5, 4, Result = 1)]
        [TestCase(0, 5, Result = 2)]
        [TestCase(1, 5, Result = -1)]
        [TestCase(2, 5, Result = 2)]
        [TestCase(3, 5, Result = 1)]
        [TestCase(4, 5, Result = 1)]
        [TestCase(5, 5, Result = 0)]
        public Int32 ShouldHasTheCorrectResultAtThePositionWhenUsingTheThirdGame(Int32 x, Int32 y)
        {            
            this.CreateThirdGame();
            return _minesweeper.GetValue(x, y);
        }

        private void CreateFirstGame()
        {
            _minesweeper.AddBomb(1, 1);
            _minesweeper.AddBomb(3, 1);
            _minesweeper.AddBomb(1, 2);
            _minesweeper.AddBomb(2, 3);
            _minesweeper.AddBomb(3, 3);
        }

        private void CreateSecondGame()
        {
            _minesweeper.AddBomb(0, 0);
            _minesweeper.AddBomb(0, 1);
            _minesweeper.AddBomb(0, 2);
            _minesweeper.AddBomb(1, 2);
            _minesweeper.AddBomb(1, 3);
            _minesweeper.AddBomb(3, 3);
        }

        private void CreateThirdGame()
        {
            _minesweeper = new Minesweeper(6);

            _minesweeper.AddBomb(0, 0);
            _minesweeper.AddBomb(2, 0);
            _minesweeper.AddBomb(3, 0);
            _minesweeper.AddBomb(4, 0);
            _minesweeper.AddBomb(0, 1);
            _minesweeper.AddBomb(2, 1);
            _minesweeper.AddBomb(4, 1);
            _minesweeper.AddBomb(2, 2);
            _minesweeper.AddBomb(3, 2);
            _minesweeper.AddBomb(4, 2);
            _minesweeper.AddBomb(5, 3);
            _minesweeper.AddBomb(0, 4);
            _minesweeper.AddBomb(3, 4);
            _minesweeper.AddBomb(1, 5);
        }

    }
}
