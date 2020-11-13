using System;

namespace FPlus.Program
{
    class Board
    {
        private ICard[][] board;

        public Board(ICard[] cards)
        {
            board = new ICard[3][];
            board[0] = new ICard[3]{cards[0], cards[1], cards[2]};
            board[1] = new ICard[3]{cards[3], cards[4], cards[5]};
            board[2] = new ICard[3]{cards[6], cards[7], cards[8]};
        }


        public void PrintBoard()
        {
            foreach (ICard[] row in board)
            {
                PrintRow(row);
            }
        }

        public void PrintRow(ICard[] row)
        {
            string[][] rows = PopulateRows(row);
            
            // Top row of square
            System.Console.Write(rows[0][0]);      
            System.Console.Write(rows[0][1]);
            System.Console.WriteLine(rows[0][2]);

            // Middle row of square
            System.Console.Write(rows[1][0]);
            System.Console.Write(rows[2][0]);     
            System.Console.Write(rows[1][1]);
            System.Console.Write(rows[2][1]);
            System.Console.Write(rows[1][2]);
            System.Console.WriteLine(rows[2][2]);

            // Bottom row of square
            System.Console.Write(rows[3][0]);      
            System.Console.Write(rows[3][1]);
            System.Console.WriteLine(rows[3][2]);

            System.Console.WriteLine("--------------------------------------");
        }

        public void WriteMiddleValues(ICard[] row, int east, int west)
        {
            System.Console.Write(row[east]);
            System.Console.Write(row[west]);
        }

        public string[][] PopulateRows(ICard[] row)
        {
            string[][] rows = new string[4][];
            rows[0] = PopulateRow(row, Direction.North);
            rows[1] = PopulateRow(row, Direction.East);
            rows[2] = PopulateRow(row, Direction.West);
            rows[3] = PopulateRow(row, Direction.South);
            return rows;
        }

        public string[] PopulateRow(ICard[] cards, Direction direction)
        {
            return new string[] {
                FormatRow(cards[0],direction),
                FormatRow(cards[1],direction),
                FormatRow(cards[2],direction),
            };
        }

        public string FormatRow(ICard card, Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    return $"| {"",3}[{card.north}]{"|",5}";
                case Direction.East:
                    return $"| [{card.east}]";
                case Direction.West:
                    return $"{"",3}[{card.west}]{"|",2}";
                case Direction.South:
                    return $"| {"",3}[{card.south}]{"|",5}";
                default:
                    return "Error";
            }
        }
    }
}