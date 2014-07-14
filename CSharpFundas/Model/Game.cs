using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleGame.Model
{
    public class Game
    {
        public ConsoleColor BackgroundColor { get; set; }
        
        // A Game is composed of a s (other games may have many sprites)
        Sprite sprite = null;

        public Game()
        {
            BackgroundColor = ConsoleColor.Green;
        }

        /// <summary>
        /// Initiates the game by painting the background
        /// and initiating the hero
        /// </summary>
        public void InitGame()
        {
            ClearBackground();

            sprite = new Sprite()
            {
                X = 0,
                Y = 0
            };
            MoveSprite(0, 0);
        }

        // The Game loop
        public void Loop()
        {
            Timer t = new Timer(TimerCallback, null, 0, 1000);

            ConsoleKeyInfo keyInfo;
            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        MoveSprite(0, -1);
                        break;

                    case ConsoleKey.RightArrow:
                        MoveSprite(1, 0);
                        break;

                    case ConsoleKey.DownArrow:
                        MoveSprite(0, 1);
                        break;

                    case ConsoleKey.LeftArrow:
                        MoveSprite(-1, 0);
                        break;
                }
            }
        }

        private static void TimerCallback(Object o)
        {
            // Display the date/time when this method got called.
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("In TimerCallback: " + DateTime.Now);

            // Force a garbage collection to occur for this demo.
            GC.Collect();
        }

        /// <summary>
        /// Move and Paint the new hero
        /// </summary>
        public void MoveSprite(int x, int y)
        {
            var newX = sprite.X + x;
            var newY = sprite.Y + y;

            if (CanMoveTo(newX, newY))
            {
                sprite.Clear(this);  // Clear the sprite i.e. the old position

                sprite.Move(x, y);
                sprite.Draw();  // Draw the sprite at the new location
            }
        }


        /// <summary>
        /// Make sure that the new coordinate is not placed outside the
        /// console window (since that will cause a runtime crash
        /// </summary>
        public bool CanMoveTo(int x, int y)
        {
            if (x < 0 || x >= Console.WindowWidth)
                return false;

            if (y < 0 || y >= Console.WindowHeight)
                return false;

            return true;
        }

      

        /// <summary>
        /// Paint a background color
        /// </summary>
        /// <remarks>
        /// It is very important that you run the Clear() method after
        /// changing the background color since this causes a repaint of the background
        /// </remarks>
        public void ClearBackground()
        {
            Console.BackgroundColor = this.BackgroundColor;
            Console.Clear(); //Important!
        }
    }
}
