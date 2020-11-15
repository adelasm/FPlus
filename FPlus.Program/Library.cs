using System;
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

        public void PopulateLibrary()
        {
            fileName = "Library";
            var web = new HtmlWeb();
            var htmlDoc = web.Load(@"https://ffxiv.consolegameswiki.com/wiki/Triple_Triad_Cards");

            var htmlBody = htmlDoc.GetElementbyId("mw-content-text").ChildNodes.ElementAt(2).ChildNodes;
            cards = new Card[htmlBody.Count];
            int?[] moldableCardInfo = new int?[] { null, null, null, null };
            for (int i = 0; i < htmlBody.Count; i++)
            {
                var test = htmlBody[i].ChildNodes;
                for (int j = 0; j < test.Count; j++)
                {
                    switch (j)
                    {
                        case 9:
                            if (!int.TryParse(test[j].InnerHtml, out _))
                            {
                                moldableCardInfo[0] = 0;
                                break;
                            }
                            System.Console.WriteLine($"Setting {test[j].InnerHtml} to north on card {i}");
                            moldableCardInfo[0] = Int32.Parse(test[j].InnerHtml);
                            break;
                        case 11:
                            if (!int.TryParse(test[j].InnerHtml, out _))
                            {
                                moldableCardInfo[2] = 0;
                                break;
                            }
                            System.Console.WriteLine($"Setting {test[j].InnerHtml} to east on card {i}");
                            moldableCardInfo[2] = Int32.Parse(test[j].InnerHtml);
                            break;
                        case 13:
                            if (!int.TryParse(test[j].InnerHtml, out _))
                            {
                                moldableCardInfo[3] = 0;
                                break;
                            }
                            System.Console.WriteLine($"Setting {test[j].InnerHtml} to south on card {i}");
                            moldableCardInfo[3] = Int32.Parse(test[j].InnerHtml);
                            break;
                        case 15:
                            if (!int.TryParse(test[j].InnerHtml, out _))
                            {
                                moldableCardInfo[1] = 0;
                                
                                break;
                            }
                            System.Console.WriteLine($"Setting {test[j].InnerHtml} to west on card {i} with {test[1].ChildNodes[0].InnerHtml.Split(" Card")[0]} name");
                            moldableCardInfo[1] = Int32.Parse(test[j].InnerHtml);
                            cards[i] = new Card(moldableCardInfo[0],moldableCardInfo[1],moldableCardInfo[2],moldableCardInfo[3],test[6].InnerHtml);
                            break;
                    }
                }
            }

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