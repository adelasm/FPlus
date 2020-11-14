using FPlus.Program;

namespace Extensions
{
    public static class Extensions
    {
        public static bool IsPlaceHolder(this ICard card)
        {
            if (card.north == 0 & card.east == 0 & card.west == 0 & card.south == 0)
            {
                return true;
            }
            return false;
        }
    }
}