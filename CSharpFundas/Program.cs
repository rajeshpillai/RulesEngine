using System;
using ConsoleGame.Model;

namespace ConsoleGame
{
    class Program
    {
        static Game game = new Game();

        static void Main(string[] args)
        {
            game.InitGame();

            // Start the game
            game.Loop();
        }
    }
}