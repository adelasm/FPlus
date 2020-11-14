using System;

namespace FPlus.Program
{
    public interface ICard
    {
        int north {get;}
        int west {get;}
        int east {get;}
        int south {get;}
        int[] values {get;}
    }
}