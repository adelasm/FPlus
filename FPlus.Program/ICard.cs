using System;

namespace FPlus.Program
{
    public interface ICard
    {
        int? north {get; set;}
        int? west {get; set;}
        int? east {get; set;}
        int? south {get; set;}
        int?[] values {get; set;}
    }
}