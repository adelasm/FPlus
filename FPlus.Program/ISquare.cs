namespace FPlus.Program
{
    interface ISquare
    {
        ICard card {get; set;}
        (int,int)? position {get; set;}
    }
}