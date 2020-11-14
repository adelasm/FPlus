using FPlus.Program;

namespace Extensions
{
    public static class Extensions
    {
        public static bool IsNotPlaceHolder(this ICard card)
        {
            return card.north.IsNotNull() & card.east.IsNotNull() & card.west.IsNotNull() & card.south.IsNotNull();
        }

        public static bool IsNull(this int? i)
        {
            return i == null;
        }
        public static bool IsNotNull(this int? i)
        {
            return i != null;
        }
    }
}