

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
            values = new int?[] {north,west,east,south};
        }

        public int? north {get; set;}

        public int? west {get; set;}

        public int? east {get; set;}

        public int? south {get; set;}

        public int?[] values {get; set;}
    }
}