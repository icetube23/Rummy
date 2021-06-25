using System.Collections.Generic;

namespace Rummy
{
    internal abstract class Player
    {
        public int Id { get; init; }

        public void MakeMove(GameState gameState)
        {
            if (WantsDraw(gameState))
                gameState.Draw(this);

            if (!gameState.IsOut(this))
                PlayFirst(gameState);

            if (gameState.IsOut(this))
                Play(gameState);
        }

        protected abstract bool WantsDraw(GameState gameState);

        protected abstract void PlayFirst(GameState gameState);

        protected abstract void Play(GameState gameState);
    }
}
