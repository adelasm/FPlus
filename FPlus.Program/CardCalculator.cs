using Extensions;
using FPlus.Program;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CardCalculator
{
    public static class CardCalculator
    {
        // Corners: NW[0,0], NE[0,2], SW[2,0], SE[2,2],
        // Middle: MID[1,1]
        // Sides: N[0,1], W[1,0], E[1,2], S[2,1],

        public static List<string> CalculatePlus(this Board board)
        {
            List<string> names = new List<string>();
            foreach (ISquare[] row in board.BoardState())
            {
                foreach (ISquare square in row)
                {
                    Position pos = square.position;
                    //If it's an actually inserted card, we don't want to check its neighbors.
                    if (square.card.IsNotPlaceHolder())
                    {
                        continue;
                    }
                    ICard neighborCard = board.GetNeighborValues(pos);
                    System.Console.WriteLine(pos);
                    System.Console.WriteLine("Inserting");
                    ICard card = neighborCard.MatchingFromLibrary(board.deck);
                    board.Insert(card, pos);
                    names.Add(card.name);
                }
            }
            return names;
        }

        public static ICard FindPlusables(this ICard card)
        {
            int?[] values = new int?[4] {card.north,card.west,card.east,card.south};
            int? max = values.Max() + 1;
            card.north = max - card.north;
            card.west = max - card.west;
            card.east = max - card.east;
            card.south = max - card.south;

            return card;
        }

        public static ICard FindEquals(this ICard card)
        {
            int?[] values = new int?[4] {card.north,card.west,card.east,card.south};
            int? max = values.Max() + 1;
            card.north = max - card.north;
            card.west = max - card.west;
            card.east = max - card.east;
            card.south = max - card.south;

            return card;
        }

        public static ICard MatchingFromLibrary(this ICard card, ILibrary library)
        {
            card = card.FindPlusables();
            ICard match = new Card();
            foreach (ICard libCard in library.cards)
            {
                match = new Card(libCard.north.Value, libCard.west.Value, libCard.east.Value, libCard.south.Value, libCard.name);
                match.values = libCard.values;
                if (card.north.IsNull())
                {
                    match.north = null;
                    match.values[0] = null;
                }
                if (card.east.IsNull())
                {
                    match.east = null;
                    match.values[2] = null;
                }
                if (card.west.IsNull())
                {
                    match.west = null;
                    match.values[1] = null;
                }
                if (card.south.IsNull())
                {
                    match.south = null;
                    match.values[3] = null;
                }
                match = match.FindPlusables();

                if (match.IsPlaceHolder())
                {
                    match = new Card();
                    continue;
                }
                if (match.north == card.north && match.west == card.west && match.east == card.east && match.south == card.south)
                {
                    System.Console.WriteLine("help");
                    System.Console.WriteLine(libCard.name);
                    match = new Card(libCard.north.Value, libCard.west.Value, libCard.east.Value, libCard.south.Value, libCard.name);
                    match.values = libCard.values;
                    if (card.north.IsNull())
                    {
                        match.north = null;
                    }
                    if (card.east.IsNull())
                    {
                        match.east = null;
                    }
                    if (card.west.IsNull())
                    {
                        match.west = null;
                    }
                    if (card.south.IsNull())
                    {
                        match.south = null;
                    }
                    break;
                }
            }
            if (match.IsNotPlaceHolder())
            {
                return new PlaceHolderCard();
            }
            return match;
        }
    }
}