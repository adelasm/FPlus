using System;
using System.IO;
using System.Text.Json;
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
            deck.ReadFromJson();
            System.Console.WriteLine("The deck:");
            foreach (var card in deck.cards)
            {
                System.Console.WriteLine($"{card.name} ({card.north},{card.west},{card.east},{card.south})");
            }
            Board board = new Board();
            board.deck = deck;
            while (true)
            {
                board.PrintBoard();
                System.Console.WriteLine("Play a card.");
                System.Console.WriteLine("Format (with spaces):");
                System.Console.WriteLine("CardName Position");
                string[] input = Console.ReadLine().Split(" ");
                board.Insert(board.deck.ClosestCard(input[0]), input[1].GetPosition());
                board.CalculatePlus();
            }
        }
    }
}
