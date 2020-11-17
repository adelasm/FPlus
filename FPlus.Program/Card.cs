using System;

namespace FPlus.Program
{
    [Serializable()]
    public class Card : ICard
    {
        public Card() { }
        public Card(int? n, int? w, int? e, int? s, string na = null)
        {
            north = n;
            west = w;
            east = e;
            south = s;
            values = new int?[] { n, w, e, s };
            name = na;
        }
        private int?[] _values = new int?[4];
        public int?[] values { get { return _values; } set { _values = value; } }
        private int? _north { get; set; }
        public int? north
        {
            get
            {
                return _north;
            }
            set
            {
                _north = value;
                if (_north != values[0])
                {
                    values[0] = _north;
                }
            }
        }
        private int? _west { get; set; }
        public int? west
        {
            get
            {
                return _west;
            }
            set
            {
                _west = value;
                if (_west != values[1])
                {
                    values[1] = _west;
                }
            }
        }
        private int? _east { get; set; }
        public int? east
        {
            get
            {
                return _east;
            }
            set
            {
                _east = value;
                if (_east != values[2])
                {
                    values[2] = _east;
                }
            }
        }
        private int? _south { get; set; }
        public int? south
        {
            get
            {
                return _south;
            }
            set
            {
                _south = value;
                if (_south != values[3])
                {
                    values[3] = _south;
                }
            }
        }
        public string name { get; set; }

        public override string ToString()
        {
            return $"{name} ({north},{west},{east},{south})";
        }
    }
}