using System.IO;
using System.Text.Json;

namespace FPlus.Program
{
    public class Deck
    {
        public Card[] cards {get; set;}

        public void WriteDeckToFile()
        {
            string deckFile = JsonSerializer.Serialize(cards);
            File.WriteAllText("Deck/Deck.json",deckFile);
        }

        public void ReadDeckFromFile()
        {
            string deckFile = File.ReadAllText("Deck/Deck.json");
            cards = JsonSerializer.Deserialize<Card[]>(deckFile);
        }
    }
}