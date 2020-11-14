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
        public int? north { get; }
        public int? west { get; }
        public int? east { get; }
        public int? south { get; }
        public int?[] values { get; }
        public string name {get; set;}
    }
}