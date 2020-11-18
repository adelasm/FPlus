using System;
using System.Collections.Generic;
using System.Linq;
using FPlus.Program;
using HtmlAgilityPack;

namespace Extensions
{
    public static class Extensions
    {
        public static bool IsNotPlaceHolder(this ICard card)
        {
            return card.north.IsNotNull() & card.east.IsNotNull() & card.west.IsNotNull() & card.south.IsNotNull();
        }
        public static bool IsPlaceHolder(this ICard card)
        {
            return card.north.IsNull() & card.east.IsNull() & card.west.IsNull() & card.south.IsNull();
        }

        public static Position GetPosition(this string input)
        {
            switch (input)
            {
                case "nw":
                    return Position.NorthWest;
                case "n":
                    return Position.North;
                case "ne":
                    return Position.NorthEast;
                case "w":
                    return Position.West;
                case "m":
                    return Position.Middle;
                case "e":
                    return Position.East;
                case "sw":
                    return Position.SouthWest;
                case "s":
                    return Position.South;
                default:
                    return Position.SouthEast;
            }
        }

        public static bool IsNull(this int? i)
        {
            return i == null;
        }
        public static bool IsNotNull(this int? i)
        {
            return i != null;
        }

        public static bool IsMiddle(this Position pos)
        {
            return pos == Position.Middle;
        }

        public static bool IsSide(this Position pos)
        {
            return pos == Position.North || pos == Position.South || pos == Position.East || pos == Position.West;
        }

        public static bool IsCorner(this Position pos)
        {
            return pos == Position.NorthWest || pos == Position.NorthEast || pos == Position.SouthEast || pos == Position.SouthWest;
        }

        public static bool CompareValues(this int?[] neighborValues, int?[] libCardValues, int value1, int value2)
        {
            return neighborValues[value1] - libCardValues[value1] == libCardValues[value2] - neighborValues[value1];
        }


        public static bool CompareCardDirections(this ICard neighborValues, ICard libCard, int[] ids)
        {
            for (int i = 0; i < ids.Length; i++)
            {
                for (int j = 0; j < libCard.values.Length; j++)
                {
                    if (neighborValues.values[ids[i]].IsNull())
                    {
                        continue;
                    }
                    return (neighborValues.values[ids[i]] - libCard.values[j] == libCard.values[j] - neighborValues.values[i]);
                }
            }
            return false;
        }

        public static void CheckAndAssignNull(this ICard cardToReturn, ICard neighborValues)
        {
            if (neighborValues.values[0].IsNull())
            {
                cardToReturn.north = null;
            }
            if (neighborValues.values[1].IsNull())
            {
                cardToReturn.west = null;
            }
            if (neighborValues.values[2].IsNull())
            {
                cardToReturn.east = null;
            }
            if (neighborValues.values[3].IsNull())
            {
                cardToReturn.south = null;
            }
        }


    }
}