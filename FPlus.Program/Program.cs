using System;

namespace FPlus.Program
{
    class Program
    {
        static void Main(string[] args)
        {
            ICard card = new Card(4,2,3,1);
            ICard[] cards = new ICard[9] {card,card,card,card,card,card,card,card,card};
            Board board = new Board(cards);
            board.PrintBoard();
        }
    }
}
