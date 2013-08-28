using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodingDojo4_Minesweeper.Tests
{
    [TestFixture]
    public class MinesweeperTests
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void ShouldDrawBoardWithEmptySpaces()
        {
            var _minesweeper = new Minesweeper();
            var board = _minesweeper.DrawBoard();

            Assert.That(board, Is.EqualTo(
                "----" +
                "----" +
                "----" +
                "----"
            ));
        }

        [Test]
        public void ShouldDrawBoardWithMinesPreConfigured()
        {
            var _minesweeper = new Minesweeper(
                new MinePlace(row: 1, col: 1),
                new MinePlace(row: 2, col: 4)
            );

            var board = _minesweeper.DrawBoard();
            Assert.That(board, Is.EqualTo(
                "*---" +
                "---*" +
                "----" +
                "----"
            ));
        }

        [Test]
        public void ShouldShowCorretResultGivenSingleBomb()
        {
            var _minesweeper = new Minesweeper(
                new MinePlace(row: 1, col: 1)
            );

            var board = _minesweeper.GetResult();
            Assert.That(board, Is.EqualTo(
                "*1--" +
                "11--" +
                "----" +
                "----"
            ));
        }

        [Test]
        public void ShouldShowCorretResultGivenMultipeBombs()
        {
            var _minesweeper = new Minesweeper(
                new MinePlace(row: 1, col: 1),
                new MinePlace(row: 3, col: 3)
            );

            var board = _minesweeper.GetResult();
            Assert.That(board, Is.EqualTo(
                "*1--" +
                "1111" +
                "-1*1" +
                "-111"
            ));
        }
    }
}
