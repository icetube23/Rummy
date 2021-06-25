using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Rummy
{
    internal class Program
    {
        private static void Main()
        {
            var rummy = new Rummy(2);

            // while (rummy.MakeTurn()) { }

            var r1 = new List<Token> { new(2, Color.Black), new(3, Color.Black), new(4, Color.Black)};
            var r2 = new List<Token> {new(2, Color.Red), new(3, Color.Red), new(4, Color.Red)};
            var r3 = new List<Token> {new(2, Color.Yellow), new(3, Color.Yellow), new(4, Color.Yellow)};
            var r4 = new List<Token> {new(2, Color.Blue), new(3, Color.Blue), new(4, Color.Blue)};
            var r5 = new List<Token>
                {new(13, Color.Black), new(13, Color.Red), new(13, Color.Yellow), new(13, Color.Blue)};
            var r6 = new List<Token>
                {new(13, Color.Black), new(13, Color.Red), new(13, Color.Yellow), new(13, Color.Black)};
            var r7 = new List<Token> {new(2, Color.Black), new(3, Color.Black), new(5, Color.Black)};
            var r8 = new List<Token>
                {new(2, Color.Black), new(3, Color.Black), new Joker(Color.Red), new(5, Color.Black)};
            var r9 = new List<Token>
            {
                new(2, Color.Black), new(3, Color.Black), new Joker(Color.Red), new Joker(Color.Red),
                new(6, Color.Black)
            };
            var r10 = new List<Token>
            {
                new(7, Color.Blue), new(8, Color.Blue), new(9, Color.Blue), new(10, Color.Blue), new Joker(Color.Red),
                new(12, Color.Blue), new(13, Color.Blue), new(1, Color.Blue), new(2, Color.Blue), new(3, Color.Blue),
                new(4, Color.Blue), new Joker(Color.Black), new(6, Color.Blue)
            };
            var r11 = new List<Token> {new(10, Color.Yellow), new Joker(Color.Red), new(13, Color.Yellow)};
            var r12 = new List<Token>
                {new(8, Color.Red), new(8, Color.Yellow), new Joker(Color.Red), new Joker(Color.Black)};

            Debug.Assert(GameState.IsValidRow(r1) is true);
            Debug.Assert(GameState.IsValidRow(r2) is true);
            Debug.Assert(GameState.IsValidRow(r3) is true);
            Debug.Assert(GameState.IsValidRow(r4) is true);
            Debug.Assert(GameState.IsValidRow(r5) is true);
            Debug.Assert(GameState.IsValidRow(r6) is false);
            Debug.Assert(GameState.IsValidRow(r7) is false);
            Debug.Assert(GameState.IsValidRow(r8) is true);
            Debug.Assert(GameState.IsValidRow(r9) is false);
            Debug.Assert(GameState.IsValidRow(r10) is true);
            Debug.Assert(GameState.IsValidRow(r11) is false);
            Debug.Assert(GameState.IsValidRow(r12) is false);
        }
    }
}
