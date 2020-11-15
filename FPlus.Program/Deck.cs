using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using Extensions;
using Gma.DataStructures.StringSearch;

namespace FPlus.Program
{
    public class Deck : ILibrary
    {
        public Card[] cards {get; set;}
        public string fileName { get; set; }

        public Card ClosestCard(string input)
        {
            var trie = new UkkonenTrie<int>();
            for (int i = 0; i < cards.Length; i++)
            {
                trie.Add(cards[i].name,i);
            }
            
            return cards[trie.Retrieve(input).First()];
        }
    }
}