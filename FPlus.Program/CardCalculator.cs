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
                    ICard card = neighborCard.MatchingFromLibrary(board.deck, pos);
                    board.Insert(card, pos);
                    if (card.name != null)
                    {
                        names.Add(pos + " " + card.name);
                    }
                }
            }
            return names;
        }

        public static ICard FindPlusables(this ICard card)
        {
            int?[] values = new int?[4] { card.north, card.west, card.east, card.south };
            int? max = values.Max() + 1;
            card.north = max - card.north;
            card.west = max - card.west;
            card.east = max - card.east;
            card.south = max - card.south;

            return card;
        }

        public static ICard FindEquals(this ICard card)
        {
            ICard plusables = new Card(card.north, card.west, card.east, card.south);
            plusables.values = card.values;
            int? max = plusables.values.Max() + 1;
            plusables.north = max - card.north;
            plusables.west = max - card.west;
            plusables.east = max - card.east;
            plusables.south = max - card.south;

            return plusables;
        }

        public static ICard MatchingFromLibrary(this ICard neighborValues, ILibrary library, Position position)
        {
            ICard cardToReturn = new Card();
            foreach (ICard libCard in library.cards)
            {
                switch (position)
                {
                    // Formatted to NWES
                    case Position.NorthWest:
                        if (neighborValues.CompareCardDirections(libCard, new int[]{2, 3}))
                        {
                            cardToReturn = new Card(libCard.north,libCard.west,libCard.east,libCard.south,libCard.name);
                        }
                        break;
                    case Position.North:
                        if (neighborValues.CompareCardDirections(libCard, new int[]{1, 2, 3}))
                        {
                            cardToReturn = new Card(libCard.north,libCard.west,libCard.east,libCard.south,libCard.name);
                        }
                        break;
                    case Position.NorthEast:
                    if (neighborValues.CompareCardDirections(libCard, new int[]{1, 3}))
                        {
                            cardToReturn = new Card(libCard.north,libCard.west,libCard.east,libCard.south,libCard.name);
                        }
                        break;
                    case Position.East:
                    if (neighborValues.CompareCardDirections(libCard, new int[]{0, 1, 3}))
                        {
                            cardToReturn = new Card(libCard.north,libCard.west,libCard.east,libCard.south,libCard.name);
                        }
                        break;
                    case Position.Middle:
                    if (neighborValues.CompareCardDirections(libCard, new int[]{0, 1, 2, 3}))
                        {
                            cardToReturn = new Card(libCard.north,libCard.west,libCard.east,libCard.south,libCard.name);
                        }
                        break;
                    case Position.West:
                    if (neighborValues.CompareCardDirections(libCard, new int[]{0, 2, 3}))
                        {
                            cardToReturn = new Card(libCard.north,libCard.west,libCard.east,libCard.south,libCard.name);
                        }
                        break;
                    case Position.SouthWest:
                    if (neighborValues.CompareCardDirections(libCard, new int[]{0, 2}))
                        {
                            cardToReturn = new Card(libCard.north,libCard.west,libCard.east,libCard.south,libCard.name);
                        }
                        break;
                    case Position.South:
                    if (neighborValues.CompareCardDirections(libCard, new int[]{0, 1, 2}))
                        {
                            cardToReturn = new Card(libCard.north,libCard.west,libCard.east,libCard.south,libCard.name);
                        }
                        break;
                    case Position.SouthEast:
                    if (neighborValues.CompareCardDirections(libCard, new int[]{0, 1}))
                        {
                            cardToReturn = new Card(libCard.north,libCard.west,libCard.east,libCard.south,libCard.name);
                        }
                        break;
                }
            }
            cardToReturn.CheckAndAssignNull(neighborValues);
            return cardToReturn;
        }
    }
}