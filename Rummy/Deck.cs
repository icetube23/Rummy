using System;
using System.Collections.Generic;
using System.Linq;

namespace Rummy
{
    internal class Deck
    {
        private readonly List<Token> _deck;

        public int Count => _deck.Count;

        public bool Empty => !_deck.Any();

        public Deck(bool shuffle = true)
        {
            _deck = new List<Token>(from _ in Enumerable.Range(0, 2)
                from color in Enumerable.Range(0, 4)
                from value in Enumerable.Range(1, 13)
                select new Token(value, (Color)color)) { new Joker(Color.Black), new Joker(Color.Red) };

            if (!shuffle) return;
            var random = new Random();
            _deck = _deck.OrderBy(_ => random.Next()).ToList();
        }

        public Token Draw()
        {
            if (!_deck.Any()) throw new InvalidOperationException("Can not draw from empty deck.");
            var last = _deck[^1];
            _deck.RemoveAt(_deck.Count - 1);
            return last;
        }

        public IEnumerable<Token> DrawMany(int amount)
        {
            if (_deck.Count < amount) throw new InvalidOperationException("Not enough tokens to draw from deck.");
            var lasts = _deck.GetRange(_deck.Count - amount, amount);
            lasts.Reverse();
            _deck.RemoveRange(_deck.Count - amount, amount);
            return lasts;
        }
    }
}
