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
            var minesweeper = new Minesweeper();
            var board = minesweeper.DrawBoard();

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
            var minesweeper = new Minesweeper(
                new MinePlace(row: 1, col: 1),
                new MinePlace(row: 2, col: 4)
            );

            var board = minesweeper.DrawBoard();
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
            var minesweeper = new Minesweeper(
                new MinePlace(row: 1, col: 1)
            );

            var board = minesweeper.GetResult();
            Assert.That(board, Is.EqualTo(
                "*100" +
                "1100" +
                "0000" +
                "0000"
            ));
        }

        [Test]
        public void ShouldShowCorretResultGivenMultipeBombs()
        {
            var minesweeper = new Minesweeper(
                new MinePlace(row: 1, col: 1),
                new MinePlace(row: 3, col: 3)
            );

            var board = minesweeper.GetResult();
            Assert.That(board, Is.EqualTo(
                "*100" +
                "1211" +
                "01*1" +
                "0111"
            ));
        }
    }
}
