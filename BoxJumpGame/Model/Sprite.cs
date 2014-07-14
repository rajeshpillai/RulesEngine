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
    public class Sprite
    {
        public int X { get; set; } //Left
        public int Y { get; set; } //Top

        public bool IsActive { get; set; }

        public ConsoleColor Color { get; set; }

        public Sprite()
        {
            Color = ConsoleColor.DarkBlue;
            Console.CursorVisible = false;
            IsActive = true;
        }

        /// <summary>
        /// Draws the actor at the specified location
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
            this.X = x;
            this.Y = y;
            Console.SetCursorPosition(this.X, this.Y);
        }

        public void MoveRight(int x)
        {
            this.X = this.X + x;
            Console.SetCursorPosition(this.X, this.Y);
        }

        public void MoveUp(int y)
        {
            this.Y = this.Y - y;
            Console.SetCursorPosition(this.X, this.Y);
        }
        public void MoveDown(int y)
        {
            this.Y = this.Y + y;
            Console.SetCursorPosition(this.X, this.Y);
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
