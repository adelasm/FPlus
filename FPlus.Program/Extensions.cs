using System;
using System.Collections.Generic;
using System.Linq;
using FPlus.Program;
using HtmlAgilityPack;

namespace Extensions
{
    public static class Extensions
    {
        public static HtmlNodeCollection FindChild(this HtmlNodeCollection parent, string attribute, string value)
        {
            for (int i = 0; i < parent.Count; i++)
            {
                if (parent[i].Attributes[attribute].Value == value && parent[i].IsHtmlElement())
                {
                    System.Console.WriteLine(parent[i].Name);
                    return parent[i].ChildNodes;

                }
            }
            throw new NotImplementedException("pain");
        }

        public static bool IsNumeric(this string text) => double.TryParse(text, out _);

        public static bool IsHtmlElement(this HtmlNode node)
        {
            return node.NodeType == HtmlNodeType.Element;
        }
        public static bool IsNotPlaceHolder(this ICard card)
        {
            return card.north.IsNotNull() & card.east.IsNotNull() & card.west.IsNotNull() & card.south.IsNotNull();
        }
        public static int DistanceBetween(this string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            // Step 1
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }

            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
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
    }
}