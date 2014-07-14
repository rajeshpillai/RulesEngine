using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame.Model
{
    /// <summary>
    /// Represents a map coordinate
    /// </summary>
    public class Sprite
    {
        public int X { get; set; } //Left
        public int Y { get; set; } //Top

        public ConsoleColor Color { get; set; }
        public bool IsActive { get; set; }

        public Sprite()
        {
            Color = ConsoleColor.DarkBlue;
            IsActive = true;
        }

        /// <summary>
        /// Draws the sprite at the specified location
        /// </summary>
        public void Draw()
        {
            Console.BackgroundColor = this.Color;
            Console.Write(" ");
        }

        /// <summary>
        /// Move to specified location
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Move(int x, int y)
        {
            X = this.X + x;
            Y = this.Y + y;
            Console.SetCursorPosition(X, Y);
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
