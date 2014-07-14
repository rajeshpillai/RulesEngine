using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoxJumpGame.Model;

namespace BoxJumpGame
{
    class Program
    {

        static void Main(string[] args)
        {
            Game game = new Game();

            game.InitGame();
            game.Loop();
        }
    }
}
