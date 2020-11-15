using System;
using System.IO;
using System.Text.Json;
using Extensions;

namespace FPlus.Program
{
    public class Deck
    {
        public Card[] cards {get; set;}

        public Card ClosestCard(string input)
        {
            int closestIndex = 0;
            int closestValue = Int32.MaxValue;
            for (int i = 0; i < cards.Length; i++)
            {
                int dist = input.DistanceBetween(cards[i].name);
                if (dist < closestValue)
                {
                    closestValue = dist;
                    closestIndex = i;
                }
            }

            return cards[closestIndex];
        }
    }
}