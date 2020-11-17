using System;
using Extensions;
namespace FPlus.Program
{
    public class Board
    {
        private ISquare[][] board;
        public Deck deck {get; set;}
        public ILibrary library {get; set;}

        public Board()
        {
            board = new ISquare[3][];

            board[0] = new ISquare[3] { new Square((0, 0)), new Square((0, 1)), new Square((0, 2)) }; // Top row of squares
            board[1] = new ISquare[3] { new Square((1, 0)), new Square((1, 1)), new Square((1, 2)) }; // Middle row of squares
            board[2] = new ISquare[3] { new Square((2, 0)), new Square((2, 1)), new Square((2, 2)) }; // Bottom row of squares
        }

        public void Insert(ICard card, int x, int y)
        {
            board[x][y].card = card;
        }

        public void Insert(ICard card, Position position)
        {
            switch (position)
            {
                case Position.NorthWest:
                    Insert(card,0, 0);
                    break;
                case Position.North:
                    Insert(card,0, 1);
                    break;
                case Position.NorthEast:
                    Insert(card,0, 2);
                    break;
                case Position.West:
                    Insert(card,1, 0);
                    break;
                case Position.Middle:
                    Insert(card,1, 1);
                    break;
                case Position.East:
                    Insert(card,1, 2);
                    break;
                case Position.SouthWest:
                    Insert(card,2, 0);
                    break;
                case Position.South:
                    Insert(card,2, 1);
                    break;
                case Position.SouthEast:
                    Insert(card,2, 2);
                    break;
            }
        }

        public ISquare GetSquare(int x, int y)
        {
            return board[x][y];
        }

        public ICard GetCard(int x, int y)
        {
            return board[x][y].card;
        }

        public ICard GetCard(Position position)
        {
            switch (position)
            {
                case Position.NorthWest:
                    return GetCard(0, 0);
                case Position.North:
                    return GetCard(0, 1);
                case Position.NorthEast:
                    return GetCard(0, 2);
                case Position.West:
                    return GetCard(1, 0);
                case Position.Middle:
                    return GetCard(1, 1);
                case Position.East:
                    return GetCard(1, 2);
                case Position.SouthWest:
                    return GetCard(2, 0);
                case Position.South:
                    return GetCard(2, 1);
                case Position.SouthEast:
                    return GetCard(2, 2);
            }
            return new PlaceHolderCard();
        }

        public ICard GetNeighborValues(Position position)
        {
            switch (position)
            {
                // Formatted to NWES
                case Position.NorthWest:
                    return new Card(null, null, GetCard(Position.North).west, GetCard(Position.West).north);
                case Position.North:
                    return new Card(null, GetCard(Position.NorthWest).east, GetCard(Position.NorthEast).west, GetCard(Position.Middle).north );
                case Position.NorthEast:
                    return new Card(null, GetCard(Position.North).east, null, GetCard(Position.East).north );
                case Position.East:
                    return new Card(GetCard(Position.NorthEast).south, GetCard(Position.Middle).east, null, GetCard(Position.SouthEast).north );
                case Position.Middle:
                    return new Card(GetCard(Position.North).south, GetCard(Position.West).east, GetCard(Position.East).west, GetCard(Position.South).north );
                case Position.West:
                    return new Card(GetCard(Position.NorthWest).south, null, GetCard(Position.Middle).west, GetCard(Position.SouthWest).north );
                case Position.SouthWest:
                    return new Card(GetCard(Position.West).south, null, GetCard(Position.South).west, null );
                case Position.South:
                    return new Card(GetCard(Position.Middle).south, GetCard(Position.SouthWest).east, GetCard(Position.SouthEast).west, null );
                case Position.SouthEast:
                    return new Card(GetCard(Position.East).south, GetCard(Position.South).east, null, null );
            }
            return new PlaceHolderCard();
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
            rows[1] = PopulateSquareRow(row, Direction.West);
            rows[2] = PopulateSquareRow(row, Direction.East);
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
            switch (direction)
            {
                case Direction.North:
                    if (card.north.IsNull()) return $"| {"",3}   {"|",5}";

                    return $"| {"",3}[{card.north}]{"|",5}";
                case Direction.East:
                    if (card.east.IsNull())  return $"{"",3}   {"|",2}";
                    
                    return $"{"",3}[{card.east}]{"|",2}";
                case Direction.West:
                    if (card.west.IsNull()) return $"|    ";

                    return $"| [{card.west}]";
                case Direction.South:
                    if (card.south.IsNull()) return $"| {"",3}   {"|",5}";
                    return $"| {"",3}[{card.south}]{"|",5}";
                default:
                    return "Error";
            }
        }
    }
}