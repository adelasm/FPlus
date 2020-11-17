using System;

namespace FPlus.Program
{
    public interface ICard
    {
        string name {get; set;}
        int? north {get; set;}
        int? west {get; set;}
        int? east {get; set;}
        int? south {get; set;}
        int?[] values {get; set;}
    }
}