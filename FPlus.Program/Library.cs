using System;
using System.Collections.Generic;
using System.Linq;
using Extensions;
using Gma.DataStructures.StringSearch;
using HtmlAgilityPack;

namespace FPlus.Program
{
    public class Library : ILibrary
    {
        public Card[] cards { get; set; }
        public string fileName { get; set; }

        public Library()
        {
            fileName = "Library";
            var web = new HtmlWeb();
            var htmlDoc = web.Load(@"https://ffxiv.consolegameswiki.com/wiki/Triple_Triad_Cards");

            var htmlBody = htmlDoc.GetElementbyId("mw-content-text").ChildNodes.ElementAt(2).ChildNodes;
            List<Card> cardList = new List<Card>();
            int?[] moldableCardInfo = new int?[] { null, null, null, null };
            for (int i = 0; i < htmlBody.Count; i++)
            {
                var test = htmlBody[i].ChildNodes;
                for (int j = 0; j < test.Count; j++)
                {
                    string value = test[j].InnerHtml.Trim();
                    switch (j)
                    {
                        case 9:
                            if (int.TryParse(value, out _) || value.Trim().Equals("A"))
                            {
                                System.Console.WriteLine($"Setting {value} to north on card {i}");
                                if (value == "A")
                                {
                                    value = "10";
                                }
                                moldableCardInfo[0] = Int32.Parse(value);
                                break;
                            }
                            moldableCardInfo[0] = 0;
                            break;
                        case 11:
                            if (int.TryParse(value, out _) || value.Trim().Equals("A"))
                            {
                                System.Console.WriteLine($"Setting {value} to east on card {i}");
                                if (value == "A")
                                {
                                    value = "10";
                                }
                                moldableCardInfo[2] = Int32.Parse(value);
                                break;
                            }
                            moldableCardInfo[2] = 0;
                            break;
                        case 13:
                            if (int.TryParse(value, out _) || value.Trim().Equals("A"))
                            {
                                System.Console.WriteLine($"Setting {value} to south on card {i}");
                                if (value == "A")
                                {
                                    value = "10";
                                }
                                moldableCardInfo[3] = Int32.Parse(value);
                                break;
                            }
                            moldableCardInfo[3] = 0;
                            break;
                        case 15:
                            if (int.TryParse(value, out _) || value.Equals("A"))
                            {
                                System.Console.WriteLine($"Setting {value} to west on card {i} with {test[1].ChildNodes[0].InnerHtml.Split(" Card")[0]} name");
                                if (value == "A")
                                {
                                    value = "10";
                                }
                                moldableCardInfo[1] = Int32.Parse(value);
                                Card cardToAdd = new Card(moldableCardInfo[0], moldableCardInfo[1], moldableCardInfo[2], moldableCardInfo[3], test[1].ChildNodes[0].InnerHtml.Split(" Card")[0].ToLower());
                                cardToAdd.values = new int?[4] { moldableCardInfo[0], moldableCardInfo[1], moldableCardInfo[2], moldableCardInfo[3] };
                                cardList.Add(cardToAdd);
                                break;
                            }
                            moldableCardInfo[1] = 0;
                            break;
                    }
                }
            }
            cards = cardList.ToArray();
        }

        public Card ClosestCard(string input)
        {
            var trie = new Trie<int>();
            for (int i = 0; i < cards.Length; i++)
            {
                trie.Add(cards[i].name, i);
            }

            return cards[trie.Retrieve(input).First()];
        }
    }
}