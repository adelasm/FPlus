namespace FPlus.Program
{
    class PlaceHolderSquare : ISquare
    {
        public PlaceHolderSquare()
        {
            card = new PlaceHolderCard();
            position = null;
        }
        public ICard card { get; set; }
        public (int,int)? position { get; set; }
    }
}