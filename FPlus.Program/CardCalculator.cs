using Extensions;
using FPlus.Program;
using System.Collections.Generic;
using System.Linq;

namespace CardCalculator
{
    public static class CardCalculator
    {
        // Corners: NW[0,0], NE[0,2], SW[2,0], SE[2,2],
        // Middle: MID[1,1]
        // Sides: N[0,1], W[1,0], E[1,2], S[2,1],

        public static void CalculatePlus(this Board board)
        {
            foreach (ISquare[] row in board.BoardState())
            {
                foreach (ISquare square in row)
                {
                    Position pos = square.position;
                    int x = square.coords.Value.Item1;
                    int y = square.coords.Value.Item2;
                    //If it's an actually inserted card, we don't want to check its neighbors.
                    if (square.card.IsNotPlaceHolder())
                    {
                        continue;
                    }
                    int?[] neighborValues = board.GetNeighborValues(pos);
                    board.Insert(neighborValues.FindPlusables(), x, y);
                }
            }
        }

        public static ICard FindPlusables(this int?[] neighborValues)
        {
            int? max = neighborValues.Max() + 1;
            PlaceHolderCard card = new PlaceHolderCard();
            card.north = max - neighborValues[0];
            card.west = max - neighborValues[1];
            card.east = max - neighborValues[2];
            card.south = max - neighborValues[3];
            return card;
        }
    }
}