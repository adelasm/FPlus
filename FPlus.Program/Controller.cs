using System;
using System.Collections.Generic;
using CardCalculator;
using Extensions;
using WriterExtensions;

namespace FPlus.Program
{
    public class Controller
    {
        public static Board board { get; set; }
        public Deck deck { get; set; }
        public Library library { get; set; }

        public Controller()
        {
            board = new Board();
            deck = new Deck();
            library = new Library();
            board.deck = deck;
            board.library = library;
        }
        public void initDeckLoop()
        {
            System.Console.WriteLine("Welcome to FPlus.");
            System.Console.WriteLine("We hate the Plus Rule in Triple Triad, so we're here to help.");
            initDeck("Deck");
            System.Console.WriteLine($"Enter deck file name (default is {deck.fileName} if empty)");
            initDeck(Console.ReadLine());
            while (true)
            {//TODO: Make collection of commands
            System.Console.WriteLine("Enter command:");
                switch (Console.ReadLine())
                {
                    
                    case "create":
                    createDeckFromLibrary();
                    break;

                    case "load":
                    loadDeck();
                    break;

                    case "play":
                    initGameLoop();
                    break;

                    case "exit":
                    Environment.Exit(0);
                    break;
                }
            }
        }

        public void initGameLoop()
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

        public void loadDeck()
        {
            System.Console.WriteLine("Enter deck name:");

            deck.fileName = Console.ReadLine();
            deck.ReadFromJson();
        }



        public void createDeckFromLibrary()
        {
            try
            {
                for (int i = 0; i < deck.cards.Length; i++)
                {
                    System.Console.WriteLine($"Card {i+1}:");
                    deck.cards[i] = library.ClosestCard(Console.ReadLine());
                    System.Console.WriteLine(deck.cards[i].ToString() + " added!");
                }

                System.Console.WriteLine("Completed deck:");

                for (int i = 0; i < deck.cards.Length; i++)
                {
                    System.Console.WriteLine(deck.cards[i].ToString());
                }

                System.Console.WriteLine("Save? (Y/N)");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "Y":
                        System.Console.WriteLine("Deck name?");
                        deck.fileName = Console.ReadLine();
                        deck.WriteToJson();
                        System.Console.WriteLine($"{deck.fileName}.json saved!");
                        break;
                    case "N":
                    break;
                }
            }
            catch (InvalidOperationException)
            {
                System.Console.WriteLine("Invalid card.");
                createDeckFromLibrary();
            }
        }
    }
}