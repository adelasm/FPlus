using FPlus.Program;

namespace Extensions
{
    public static class Extensions
    {
        public static bool IsPlaceHolder(this ICard card)
        {
            if (card.north == null & card.east == null & card.west == null & card.south == null)
            {
                return true;
            }
            return false;
        }
    }
}