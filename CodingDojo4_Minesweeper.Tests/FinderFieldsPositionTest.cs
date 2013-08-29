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
	public class FinderFieldsPositionTest
	{
		private char[,] _fields;
		private FinderFieldsPosition _aroundFields;

		[SetUp]
		public void Setup ()
		{
			_fields = new char[4, 4] {
				{'A', 'B', 'C', '.'},
				{'H', '.', 'D', '.'},
				{'G', 'F', 'E', '.'},
				{'.', '.', '.', '.'}
			};

			_aroundFields = new FinderFieldsPosition (4, 4);
			_aroundFields.At (1, 1);
		}

		[Test]
		public void GivenAnMinesweeperShouldReturnsTheTopLefField ()
		{
			Assert.AreEqual ('A',GetField(_aroundFields.TopLeft ()));
		}

		[Test]
		public void GivenAnMinesweeperShouldReturnsTheTopField ()
		{
			Assert.AreEqual ('B',GetField(_aroundFields.Top ()));
		}

		[Test]
		public void GivenAnMinesweeperShouldReturnsTheTopRightField ()
		{
			Assert.AreEqual ('C',GetField(_aroundFields.TopRight ()));
		}

		[Test]
		public void GivenAnMinesweeperShouldReturnsTheLefField ()
		{
			Assert.AreEqual ('H',GetField(_aroundFields.Left ()));
		}

		[Test]
		public void GivenAnMinesweeperShouldReturnsTheRightField ()
		{
			Assert.AreEqual ('D',GetField(_aroundFields.Right ()));
		}

		[Test]
		public void GivenAnMinesweeperShouldReturnsTheBottomLefField ()
		{
			Assert.AreEqual ('G',GetField(_aroundFields.BottomLeft ()));
		}

		[Test]
		public void GivenAnMinesweeperShouldReturnsTheBottomField ()
		{
			Assert.AreEqual ('F',GetField(_aroundFields.Bottom ()));
		}

		[Test]
		public void GivenAnMinesweeperShouldReturnsTheBottomRightField ()
		{
			Assert.AreEqual ('E', GetField(_aroundFields.BottomRight ()));
		}

		// Helper
		private char GetField(int [] position)
		{
			return _fields [position [0], position [1]];
		}
	}
}
