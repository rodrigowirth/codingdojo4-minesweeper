﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CodingDojo4_Minesweeper;

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
			Assert.AreEqual("...." + 
			                "...." + 
			                "...." + 
			                "....", _minesweeper.ToString());
        }

        [Test]
        public void GivenAnFieldWithOneBombShouldReturnOneStar()
        {
            _minesweeper.AddBombToFieldAt(0, 0);
			Assert.AreEqual("*..." + 
			                "...." + 
			                "...." + 
			                "....", _minesweeper.ToString());
        }

        [Test]
        public void GivenAnFieldWithOneBombInPosition3ShouldReturnOneStar()
        {
            _minesweeper.AddBombToFieldAt(0, 3);
			Assert.AreEqual("...*" + 
			                "...." + 
			                "...." + 
			                "....", _minesweeper.ToString());
        }

		//
		// RESULT SOLVE
		//

        [Test]
        public void GivenAnEmptyBoard_SolutionWillBeAllZeroes()
        {
			Assert.AreEqual("0000" + 
			                "0000" + 
			                "0000" + 
			                "0000", _minesweeper.Solve());
        }

		[Test]
		public void GivenAnBombAtFirstPosition_SolutionWillBeThreeFieldsAroundItWith1PointEachOne()
		{
			_minesweeper.AddBombToFieldAt(0, 0);
			Assert.AreEqual("*100" + 
			                "1100" + 
			                "0000" + 
			                "0000", _minesweeper.Solve());
		}
    }
}
