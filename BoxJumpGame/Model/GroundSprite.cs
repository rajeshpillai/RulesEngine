using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxJumpGame.Model
{
    /// <summary>
    /// Represents a map coordinate
    /// </summary>
    public class GroundSprite : Sprite
    {

        public GroundSprite()
        {
            Color = ConsoleColor.DarkBlue;
        }

        /// <summary>
        /// Draws the actor at the specified location
        /// </summary>
        public void Draw()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Black;

            for (var i = 10; i < 110; i++)
            {
                Console.SetCursorPosition(i, 40);
                Console.Write("-");
            }
            Console.ResetColor();
        }

        /// <summary>
        /// Overpaint the old hero
        /// </summary>
        public void Clear(Game game)
        {
            Console.BackgroundColor = game.BackgroundColor;
            Console.SetCursorPosition(this.X, this.Y);
            Console.Write(" ");
        }

    }
}
