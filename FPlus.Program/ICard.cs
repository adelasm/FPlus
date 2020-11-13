using System;

namespace FPlus.Program
{
    interface ICard
    {
        int north {get;}
        int east {get;}
        int west {get;}
        int south {get;}
        int[] values {get;}
    }
}