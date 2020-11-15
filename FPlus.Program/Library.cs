using System;
using System.Linq;
using Extensions;
using Gma.DataStructures.StringSearch;

namespace FPlus.Program
{
    public class Library : ILibrary
    {
        public Card[] cards {get; set;}
        public string fileName { get; set; }

        public Card ClosestCard(string input)
        {
            var trie = new Trie<int>();
            for (int i = 0; i < cards.Length; i++)
            {
                trie.Add(cards[i].name,i);
            }

            return cards[trie.Retrieve(input).First()];
        }
    }
}