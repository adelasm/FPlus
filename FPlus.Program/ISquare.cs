namespace FPlus.Program
{
    public interface ISquare
    {
        ICard card {get; set;}
        (int,int)? coords {get; set;}
        Position position { get; } 
    }
}