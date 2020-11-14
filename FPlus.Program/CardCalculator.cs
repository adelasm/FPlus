using Extensions;
using FPlus.Program;

namespace CardCalculator
{
    public static class CardCalculator
    {
        // Corners: NW[0,0], NE[0,2], SW[2,0], SE[2,2],
        // Middle: MID[1,1]
        // Sides: N[0,1], W[1,0], E[1,2], S[2,1],

        public static string CalculatePlus(this Board board)
        {
            int coord1 = 0;
            int coord2 = 0;
            int? card1Value = null;
            int? card2Value = null;
            int? card3Value = null;
            int? card4Value = null;
            foreach (ISquare[] row in board.BoardState())
            {
                foreach (ISquare square in row)
                {
                    if (square.card.IsPlaceHolder())
                    {
                        continue;
                    }
                    Position pos = square.position;
                    if (pos.IsMiddle())
                    {
                        card1Value = board.GetCard(0, 1).south;
                        card2Value = board.GetCard(2, 1).north;
                        if (square.IsPlus(square.card.north, card1Value, square.card.south, card2Value))
                        {
                            coord1 = square.coords.Value.Item1;
                            coord2 = square.coords.Value.Item2;
                            return $"Plus opportunity found at [{coord1},{coord2}]";
                        }
                    }
                    else if (pos.IsCorner())
                    {
                        switch (square.position)
                        {
                            case Position.NorthWest:
                                card1Value = board.GetCard(Position.North).west;
                                card2Value = board.GetCard(Position.East).north;
                                if (square.IsPlus(square.card.east, card1Value, square.card.south, card2Value))
                                {
                                    coord1 = square.coords.Value.Item1;
                                    coord2 = square.coords.Value.Item2;
                                    return $"Plus opportunity found at [{coord1},{coord2}]";
                                }
                                break;

                            case Position.NorthEast:
                                card1Value = board.GetCard(Position.North).east;
                                card2Value = board.GetCard(Position.West).north;
                                if (square.IsPlus(square.card.west, card1Value, square.card.south, card2Value))
                                {
                                    coord1 = square.coords.Value.Item1;
                                    coord2 = square.coords.Value.Item2;
                                    return $"Plus opportunity found at [{coord1},{coord2}]";
                                }
                                break;

                            case Position.SouthWest:
                                card1Value = board.GetCard(Position.West).south;
                                card2Value = board.GetCard(Position.South).west;
                                if (square.IsPlus(square.card.north, card1Value, square.card.east, card2Value))
                                {
                                    coord1 = square.coords.Value.Item1;
                                    coord2 = square.coords.Value.Item2;
                                    return $"Plus opportunity found at [{coord1},{coord2}]";
                                };
                                break;

                            case Position.SouthEast:
                                card1Value = board.GetCard(Position.East).south;
                                card2Value = board.GetCard(Position.South).east;
                                if (square.IsPlus(square.card.north, card1Value, square.card.west, card2Value))
                                {
                                    coord1 = square.coords.Value.Item1;
                                    coord2 = square.coords.Value.Item2;
                                    return $"Plus opportunity found at [{coord1},{coord2}]";
                                };
                                break;
                        }
                    }
                    else if (pos.IsSide())
                    {
                        switch (square.position)
                        {
                            case Position.North:
                                card1Value = board.GetCard(Position.North).west;
                                card2Value = board.GetCard(Position.East).north;
                                square.IsPlus(square.card.east, card1Value, square.card.south, card2Value);
                                break;
                        }
                    }
                }
            }


            return "hi";
        }

        public static bool IsPlus(this ISquare square, int? toCheck1, int? x, int? toCheck2, int? y)
        {
            return (toCheck1 + x) == (toCheck2 + y);
        }

        public static bool IsMiddle(this Position position)
        {
            if (position == Position.Middle)
            {
                return true;
            }
            return false;
        }
        public static bool IsCorner(this Position position)
        {
            if (position == Position.NorthWest || position == Position.NorthEast || position == Position.SouthWest || position == Position.SouthEast)
            {
                return true;
            }
            return false;
        }

        public static bool IsSide(this Position position)
        {
            if (position == Position.North || position == Position.West || position == Position.East || position == Position.South)
            {
                return true;
            }
            return false;
        }


    }
}