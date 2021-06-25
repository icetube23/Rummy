using System;
using System.Collections.Generic;
using System.Linq;

namespace Rummy
{
    internal class Human : Player
    {
        protected override bool WantsDraw(GameState gameState)
        {
            PrintState(gameState);
            Console.Write("Do you want to draw (y/n)? ");
            var input = Console.ReadLine();
            Console.WriteLine();
            return input == "y";
        }

        protected override void PlayFirst(GameState gameState)
        {
            string input;
            do
            {
                PrintState(gameState);
                Console.Write("What tokens do you want to play? ");
                input = Console.ReadLine();
                Console.WriteLine();
                try
                {
                    var indices = input?.Split(' ', ',').Select(s => Convert.ToInt32(s));
                    var hand = gameState.ViewHand(this);
                    gameState.Play(this, indices!.Select(index => hand[index]).ToList());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wrong format.");
                }
            } while (input != "q");
        }

        protected override void Play(GameState gameState)
        {
            PrintState(gameState);
        }

        private void PrintState(GameState gameState)
        {
            Console.WriteLine($"State:\n{string.Join("\n", gameState.ViewState().Select(row => string.Join(", ", row)))}");
            Console.WriteLine($"Player {Id} hand: {string.Join(", ", gameState.ViewHand(this).ToList())}\n");
        }
    }
}
