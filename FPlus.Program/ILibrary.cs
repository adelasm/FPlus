namespace FPlus.Program
{
    public interface ILibrary
    {
        string fileName {get; set;}
        Card[] cards {get; set;}
        Card ClosestCard(string input);
    }
}