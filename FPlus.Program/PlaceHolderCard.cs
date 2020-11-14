

namespace FPlus.Program
{
    public class PlaceHolderCard : ICard
    {

        public PlaceHolderCard()
        {
            north = 0;
            west = 0;
            east = 0;
            south = 0;
        }

        public int north {get;}

        public int west {get;}

        public int east {get;}

        public int south {get;}

        public int[] values => throw new System.NotImplementedException();
    }
}