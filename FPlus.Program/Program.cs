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
            controller.initDeckLoop();
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
            controller.initGameLoop();
            
        }
    }
}
