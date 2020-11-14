using FPlus.Program;

namespace SquareCalculator
{
    public static class SquareCalculator
    {
        // Corners: NW[0,0], NE[0,2], SW[2,0], SE[2,2],
        // Middle: MID[1,1]
        // Sides: N[0,1], W[1,0], E[1,2], S[2,1],
        public static Position AssignPosition(this (int x, int y)? coords)
        {
            switch (coords)
            {
                case (1,1):
                    return Position.Middle;
                case (0,0):
                    return Position.NorthWest;
                case (0,1):
                    return Position.North;
                case (0,2):
                    return Position.NorthEast;
                case (1,0):
                    return Position.West;
                case (1,2):
                    return Position.East;
                case (2,0):
                    return Position.SouthWest;
                case (2,1):
                    return Position.South;
                case (2,2):
                    return Position.SouthEast;
                default:
                    return Position.Middle;
            }
        }


        public static bool IsEligibleCoords(this (int x, int y)? coords)
        {
            int x = coords.Value.x;
            int y = coords.Value.y;
            return (x > 4 && x > -1) && (y > 4 && y > -1);
        }

    }
}