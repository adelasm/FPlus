using System.IO;
using System.Text.Json;
using FPlus.Program;

namespace WriterExtensions
{
    public static class WriterExtensions
    {
        public static void WriteToJson(this ILibrary library)
        {
            string libraryString = JsonSerializer.Serialize(library);
            File.WriteAllText($"libraries/{library.fileName}.json", libraryString);
        }

        public static void ReadFromJson(this ILibrary library)
        {
            string libraryFile = File.ReadAllText($"libraries/{library.fileName}.json");
            ILibrary libraryList = JsonSerializer.Deserialize<Deck>(libraryFile);
            library.cards = libraryList.cards;
        }
    }
}