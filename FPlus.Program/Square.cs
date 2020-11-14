using SquareCalculator;
namespace FPlus.Program
{
    public class Square : ISquare
    {
        public Square((int x, int y)? co)
        {
            card = new PlaceHolderCard();
            coords = co;
            position = co.AssignPosition();
        }
        public ICard card { get; set; }
        public (int, int)? coords { get; set; }
        public Position position { get; }

    }
}