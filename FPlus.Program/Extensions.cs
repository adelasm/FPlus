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

        public static bool IsPlusValues(this ICard card, ICard cardToCompare, Position position)
        {
            int? east = card.east + cardToCompare.east;
            int? west = card.west + cardToCompare.west;
            int? north = card.north + cardToCompare.north;
            int? south = card.south + cardToCompare.south;
            bool eastIsSouth = east == south;
            bool westIsSouth = west == south;
            bool eastIsNorth = east == north;
            bool westIsNorth = west == north;
            bool northIsSouth = north == south;
            bool southIsNorth = south == north;
            bool eastIsWest = east == west;
            switch (position)
            {
                // Formatted to NWES
                case Position.NorthWest:
                    return eastIsSouth;
                case Position.North:
                    return eastIsSouth && westIsSouth || eastIsSouth || westIsSouth || eastIsWest;
                case Position.NorthEast:
                    return westIsSouth;
                case Position.East:
                    return westIsSouth && southIsNorth || westIsSouth || westIsNorth || northIsSouth;
                case Position.Middle:
                    return eastIsSouth && southIsNorth && westIsNorth || westIsNorth && westIsSouth || eastIsNorth && eastIsSouth || eastIsNorth || eastIsSouth || westIsNorth || westIsSouth || northIsSouth || eastIsWest;
                case Position.West:
                    return westIsSouth && southIsNorth || westIsSouth || westIsNorth || southIsNorth;
                case Position.SouthWest:
                    return eastIsNorth;
                case Position.South:
                    return eastIsNorth && westIsNorth || eastIsNorth|| westIsNorth || eastIsWest;
                case Position.SouthEast:
                    return westIsNorth;
            }
            return false;
        }
    }
}