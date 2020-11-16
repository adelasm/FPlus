using System;
using CardCalculator;
using WriterExtensions;
using Extensions;

namespace FPlus.Program
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Welcome to FPlus.");
            System.Console.WriteLine("We hate the Plus Rule in Triple Triad, so we're here to help.");
            Deck deck = new Deck();
            deck.fileName = "Deck";
            System.Console.WriteLine($"Enter deck file name (default is {deck.fileName} if empty)");
            // string deckName = Console.ReadLine();
            // if (deckName != "")
            // {
            //     deck.fileName = deckName;
            // }
            deck.ReadFromJson();
            System.Console.WriteLine("The deck:");
            foreach (var card in deck.cards)
            {
                System.Console.WriteLine($"{card.name} ({card.north},{card.west},{card.east},{card.south})");
            }
            Library lib = new Library();
            lib.PopulateLibrary();
            lib.WriteToJson();
            Board board = new Board();
            board.deck = deck;
            board.library = lib;
            while (true)
            {
                board.PrintBoard();
                System.Console.WriteLine("Play a card.");
                System.Console.WriteLine("Format (with spaces):");
                System.Console.WriteLine("CardName Position");
                string[] input = Console.ReadLine().Split(" ");
                board.Insert(board.library.ClosestCard(input[0]), input[1].GetPosition());
                board.CalculatePlus();
            }
        }
    }
}
