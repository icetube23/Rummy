using System;
using System.Diagnostics;
using System.Linq;

namespace Rummy
{
    internal class Rummy
    {
        private readonly Player[] _players;
        private readonly GameState _gameState;
        private int _turn;

        public Rummy(int players, int ais = 0)
        {
            if (players is > 4 or < 2)
                throw new ArgumentException("Game can only be played by 2-4 players.");

            if (ais > players)
                throw new ArgumentException("Can not have more AIs than players.");

            _players = Enumerable.Range(0, players).Select(id => id < players - ais ? new Human { Id = id } : new AI { Id = id } as Player).ToArray();
            _gameState = new GameState(players);
            _turn = 1;
        }

        public bool MakeTurn()
        {
            Console.WriteLine($"Playing turn {_turn}:\n");

            foreach (var player in _players)
            {
                Console.WriteLine($"Player {player.Id}'s turn:\n");
                player.MakeMove(_gameState);
            }

            _turn++;

            return true;
        }
    }
}
