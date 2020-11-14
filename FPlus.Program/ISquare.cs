namespace FPlus.Program
{
    public interface ISquare
    {
        ICard card {get; set;}
        (int,int)? position {get; set;}
    }
}