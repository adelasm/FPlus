using System;

namespace FPlus.Program
{
    public class Card : ICard
    {
        public Card(int n, int e, int w, int s)
        {
            north = n;
            east = e;
            west = w;
            south = s;
            values = new int[]{n,e,w,s};
        }
        public int north { get; }
        public int east { get; }
        public int west { get; }
        public int south { get; }
        public int[] values { get; }
    }
}