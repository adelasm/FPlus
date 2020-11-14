using System.IO;
using System.Text.Json;
using FPlus.Program;

namespace WriterExtensions
{
    public static class WriterExtensions
    {
        public static void WriteToJson(this Deck deck)
        {
            string deckString = JsonSerializer.Serialize(deck);
            File.WriteAllText("Deck/Deck.json",deckString);
        }

        public static void ReadFromJson(this Deck deck)
        {
            string deckFile = File.ReadAllText("Deck/Deck.json");
            Deck deckList = JsonSerializer.Deserialize<Deck>(deckFile);
            deck.cards = deckList.cards;
        }
    }
}