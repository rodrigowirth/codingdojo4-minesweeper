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
		}

        [Test]
        public void GivenAnMinesweeperShouldReturnsTheLeftTopField()
        {
			_aroundFields.At(1, 1);
			Assert.AreEqual('A', _aroundFields.TopLeft());
        }

       
    }
}
