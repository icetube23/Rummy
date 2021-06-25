using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;

namespace Rummy
{
    internal class GameState
    {
        private readonly List<List<Token>> _state;
        private readonly List<Token>[] _hands;
        private readonly Deck _deck;
        private readonly bool[] _out;

        public GameState(int players)
        {
            _state = new List<List<Token>>();
            _deck = new Deck();
            _hands = Enumerable.Range(0, players).Select(_ => _deck.DrawMany(15).ToList()).ToArray();
            _out = new bool[players];
        }

        public IReadOnlyList<IReadOnlyList<Token>> ViewState() => _state.Select(row => row.AsReadOnly()).ToList().AsReadOnly();

        public IReadOnlyList<Token> ViewHand(Player player) => _hands[player.Id].AsReadOnly();

        public bool IsOut(Player player) => _out[player.Id];

        public void Draw(Player player) => _hands[player.Id].Add(_deck.Draw());

        public void Play(Player player, List<Token> row)
        {
            if (row.Any(token => !_hands[player.Id].Contains(token)))
                throw new ArgumentException("Can not play tokens that are not in player hand.");

            if (!_out[player.Id])
                throw new InvalidOperationException("Player needs to be out to first.");

            foreach (var token in row)
            {
                _hands[player.Id].Remove(token);
            }

            _state.Add(row);
        }

        public void PlayFirst(Player player, List<List<Token>> rows)
        {
            if (_out[player.Id])
                throw new InvalidOperationException("Player is already out.");

            if (!rows.All(IsValidRow))
                throw new ArgumentException("Invalid row.");

            if (rows.Select(row => row.Sum(token => token.Value)).Sum() < 51)
                throw new InvalidOperationException("Player needs to play tokens of value atleast 51 to get out.");

            _out[player.Id] = true;

            foreach (var row in rows)
            {
                Play(player, row);
            }
        }

        public void Take(Player player, int index)
        {
            _hands[player.Id].AddRange(_state[index]);
            _state.RemoveAt(index);
        }

        public static bool IsValidRow(List<Token> row)
        {
            if (row.Count < 3)
                return false;

            var firstNonJoker = row.First(token => token is not Joker);
            if (row.All(token => token.Color == firstNonJoker.Color || token is Joker))
            {
                for (var i = 0; i < row.Count - 1; i++)
                {
                    if ((row[i].Value + 1) % 13 != row[i + 1].Value % 13 && !(row[i] is Joker ^ row[i + 1] is Joker))
                        return false;

                    if (i > 0 && i < row.Count - 1 && row[i] is Joker &&
                        (row[i - 1].Value + 2) % 13 != row[i + 1].Value % 13)
                        return false;
                }
            }
            else
            {
                if (!row.All(token => token.Value == firstNonJoker.Value || token is Joker))
                    return false;

                if (row.Count(token => token is Joker) > 1)
                    return false;

                var colors = new bool[4];
                foreach (var token in row.Where(token => token is not Joker))
                {
                    if (colors[(int)token.Color])
                        return false;
                    colors[(int)token.Color] = true;
                }
            }

            return true;
        }
    }
}
