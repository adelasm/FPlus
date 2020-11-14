using System;
using Xunit;
using FPlus.Program;
using CardCalculator;

namespace FPlus.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Middle_NorthAndSouth()
        {
            Board board = new Board();
            ICard card = new Card(1,1,1,1);
            board.Insert(card, 1, 1); // Middle
            board.Insert(card, 0, 1); // North
            board.Insert(card, 2, 1); // South

            Assert.Equal("Plus opportunity found at [1,1]",board.CalculatePlus());
        }

        [Fact]
        public void Corner_NorthWest()
        {
            Board board = new Board();
            ICard card = new Card(1,1,1,1);
            board.Insert(card, 0, 0); // Middle
            board.Insert(card, 1, 0); // North
            board.Insert(card, 0, 1); // South

            Assert.Equal("Plus opportunity found at [0,0]",board.CalculatePlus());
        }
    }
}
