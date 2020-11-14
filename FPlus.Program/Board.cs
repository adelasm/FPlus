using System;
using Extensions;
namespace FPlus.Program
{
    class Board
    {
        private ISquare[][] board;

        public Board()
        {
            board = new ISquare[3][];
            board[0] = new ISquare[3] { new PlaceHolderSquare(), new PlaceHolderSquare(), new PlaceHolderSquare() }; // Top row of squares
            board[1] = new ISquare[3] { new PlaceHolderSquare(), new PlaceHolderSquare(), new PlaceHolderSquare() }; // Middle row of squares
            board[2] = new ISquare[3] { new PlaceHolderSquare(), new PlaceHolderSquare(), new PlaceHolderSquare() }; // Bottom row of squares
        }

        public void Insert(ICard card,int x,int y)
        {
            board[x][y].card = card;
        }

        public ISquare[][] BoardState()
        {
            return board;
        }


        public void PrintBoard()
        {
            System.Console.WriteLine("--------------------------------------");
            foreach (ISquare[] row in board)
            {
                PrintRow(row);
            }
        }

        public void PrintRow(ISquare[] row)
        {
            string[][] rows = PopulateSquareRows(row);

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

        public string[][] PopulateSquareRows(ISquare[] row)
        {
            string[][] rows = new string[4][];
            rows[0] = PopulateSquareRow(row, Direction.North);
            rows[1] = PopulateSquareRow(row, Direction.East);
            rows[2] = PopulateSquareRow(row, Direction.West);
            rows[3] = PopulateSquareRow(row, Direction.South);
            return rows;
        }

        public string[] PopulateSquareRow(ISquare[] squares, Direction direction)
        {
            return new string[] {
                FormatRow(squares[0].card,direction),
                FormatRow(squares[1].card,direction),
                FormatRow(squares[2].card,direction),
            };
        }

        public string FormatRow(ICard card, Direction direction)
        {
            if (card.IsPlaceHolder())
            {
                switch (direction)
                {
                    case Direction.North:
                        return $"| {"",3}   {"|",5}";
                    case Direction.East:
                        return $"|    ";
                    case Direction.West:
                        return $"{"",3}   {"|",2}";
                    case Direction.South:
                        return $"| {"",3}   {"|",5}";
                    default:
                        return "Error";
                }
            }
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