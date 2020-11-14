using System;

namespace FPlus.Program
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Welcome to FPlus.");
            System.Console.WriteLine("We hate the Plus Rule in Triple Triad, so we're here to help.");
            ICard phcard = new PlaceHolderCard();
            ICard[] phcards = new ICard[9] {phcard,phcard,phcard,phcard,phcard,phcard,phcard,phcard,phcard};
            Board board = new Board(phcards);
            while (true)
            {
                board.PrintBoard();
                System.Console.WriteLine("Play a card.");
                System.Console.WriteLine("Format(nospaces):");
                System.Console.WriteLine("N E W S X Y");
                int[] input = Array.ConvertAll(Console.ReadLine().Split(" "),Int32.Parse);
                board.Insert(new Card(input[0],input[1],input[2],input[3]),input[4],input[5]);
            }
        }
    }
}
