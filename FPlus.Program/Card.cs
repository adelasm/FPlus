using System;

namespace FPlus.Program
{
    [Serializable()]
    public class Card : ICard
    {
        public Card(){}
        public Card(int? n, int? w, int? e, int? s,string na = null)
        {
            north = n;
            west = w;
            east = e;
            south = s;
            values = new int?[]{n,w,e,s};
            name = na;
        }
        public int? north { get; set; }
        public int? west { get; set;}
        public int? east { get; set; }
        public int? south { get; set; }
        public int?[] values { get; set; }
        public string name {get; set;}
    }
}