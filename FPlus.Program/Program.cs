using System;
using CardCalculator;
using WriterExtensions;
using Extensions;
using System.Collections.Generic;

namespace FPlus.Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            System.Console.WriteLine("Welcome to FPlus.");
            System.Console.WriteLine("We hate the Plus Rule in Triple Triad, so we're here to help.");
            controller.initDeck("Deck");
            System.Console.WriteLine($"Enter deck file name (default is {controller.deck.fileName} if empty)");
            // string deckName = Console.ReadLine();
            // if (deckName != "")
            // {
            //     deck.fileName = deckName;
            // }
            System.Console.WriteLine("The deck:");
            foreach (var card in controller.deck.cards)
            {
                System.Console.WriteLine($"{card.name} ({card.north},{card.west},{card.east},{card.south})");
            }
            controller.initInputLoop();
            
        }
    }
}
