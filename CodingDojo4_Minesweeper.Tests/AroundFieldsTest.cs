using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CodingDojo4_Minesweeper;

namespace CodingDojo4_Minesweeper.Tests
{
    [TestFixture]
    public class AroundFieldsTest
    {
		private AroundFields _aroundFields;

		[SetUp]
		public void Setup()
		{
			var fields = new char[4, 4] {
				{'A', 'B', 'C', '.'},
				{'H', '.', 'D', '.'},
				{'G', 'F', 'E', '.'},
				{'.', '.', '.', '.'}
			};

			_aroundFields = new AroundFields (fields);
			_aroundFields.At(1, 1);
		}

        [Test]
        public void GivenAnMinesweeperShouldReturnsTheTopLefField()
        {
			Assert.AreEqual('A', _aroundFields.TopLeft());
        }

		[Test]
		public void GivenAnMinesweeperShouldReturnsTheTopField()
		{
			Assert.AreEqual('B', _aroundFields.Top());
		}

		[Test]
		public void GivenAnMinesweeperShouldReturnsTheTopRightField()
		{
			Assert.AreEqual('C', _aroundFields.TopRight());
		}

		[Test]
		public void GivenAnMinesweeperShouldReturnsTheLefField()
		{
			Assert.AreEqual('H', _aroundFields.Left());
		}

		[Test]
		public void GivenAnMinesweeperShouldReturnsTheRightField()
		{
			Assert.AreEqual('D', _aroundFields.Right());
		}

		[Test]
		public void GivenAnMinesweeperShouldReturnsTheBottomLefField()
		{
			Assert.AreEqual('G', _aroundFields.BottomLeft());
		}

		[Test]
		public void GivenAnMinesweeperShouldReturnsTheBottomField()
		{
			Assert.AreEqual('F', _aroundFields.Bottom());
		}

		[Test]
		public void GivenAnMinesweeperShouldReturnsTheBottomRightField()
		{
			Assert.AreEqual('E', _aroundFields.BottomRight());
		}
       
    }
}
