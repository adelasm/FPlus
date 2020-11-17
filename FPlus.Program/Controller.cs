using System;
using System.Collections.Generic;
using CardCalculator;
using Extensions;
using WriterExtensions;

namespace FPlus.Program
{
    public class Controller
    {
        public static Board board {get; set;}
        public Deck deck {get; set;}
        public Library library {get; set;}

        public Controller()
        {
            board = new Board();
            deck = new Deck();
            library = new Library();
            board.deck = deck;
            board.library = library;
        }

        public void initInputLoop()
        {
            List<string> suggestions = new List<string>();
            while (true)
            {
                board.PrintBoard();
                foreach (var item in suggestions)
                {
                    System.Console.WriteLine(item);
                }
                System.Console.WriteLine("Play a card.");
                System.Console.WriteLine("Format (with spaces):");
                System.Console.WriteLine("CardName Position");
                string[] input = Console.ReadLine().Split(" ");
                board.Insert(board.library.ClosestCard(input[0]), input[1].GetPosition());
                suggestions = board.CalculatePlus();
            }
        }


        public void initDeck(string deckName)
        {
            deck.fileName = deckName;
            deck.ReadFromJson();
        }

        public void saveDeck()
        {
            deck.ReadFromJson();
        }
    }
}