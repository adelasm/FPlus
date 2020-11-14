using System;

namespace FPlus.Program
{
    public class Card : ICard
    {
        public Card(int n, int w, int e, int s)
        {
            north = n;
            west = w;
            east = e;
            south = s;
            values = new int[]{n,w,e,s};
        }
        public int north { get; }
        public int west { get; }
        public int east { get; }
        public int south { get; }
        public int[] values { get; }
    }
}