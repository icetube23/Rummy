using System;

namespace Rummy
{
    internal class Token
    {
        private readonly int _value;

        public int Value
        {
            get => _value;
            init
            {
                if (value is >= 1 and <= 13)
                    _value = value;
                else
                    throw new ArgumentException("Value must be between 1 and 13.");
            }
        }

        public Color Color { get; init; }

        public bool IsJoker { get; init; }

        public Token(int value, Color color)
        {
            Value = value;
            Color = color;
            IsJoker = false;
        }

        protected Token(int value, Color color, bool isJoker)
        {
            if (isJoker && color != Color.Black && color != Color.Red)
                throw new ArgumentException("Joker has to be of color black or red.");

            _value = value;
            Color = color;
            IsJoker = isJoker;
        }

        public override string ToString() => $"({Color}, {Value})";
    }

    internal class Joker : Token
    {
        public Joker(Color color) : base(25, color, true) { }

        public override string ToString() => $"Joker ({Color})";
    }

    internal enum Color
    {
        Black,
        Red,
        Yellow,
        Blue
    }
}
