

namespace FPlus.Program
{
    public class PlaceHolderCard : ICard
    {

        public PlaceHolderCard()
        {
            north = null;
            west = null;
            east = null;
            south = null;
        }

        public int? north {get;}

        public int? west {get;}

        public int? east {get;}

        public int? south {get;}

        public int?[] values => throw new System.NotImplementedException();
    }
}