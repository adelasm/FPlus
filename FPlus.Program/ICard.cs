using System;

namespace FPlus.Program
{
    public interface ICard
    {
        int north {get;}
        int east {get;}
        int west {get;}
        int south {get;}
        int[] values {get;}
    }
}