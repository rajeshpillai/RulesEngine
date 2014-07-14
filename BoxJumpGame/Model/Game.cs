using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BoxJumpGame.Model
{
    public class Game
    {
        public ConsoleColor BackgroundColor { get; set; }
        
        // A Game is composed of a s (other games may have many sprites)
        Sprite actor = null;
        GroundSprite groundSprite = new GroundSprite();

        int width = 120;
        int height = 50;

        bool isJumping = false;
        bool isFalling = false;
        
        const int JUMP_HEIGHT = 5;
        int jumpY = 1;

        int[] obstacles = new[] { 0, 0, 0, 0, 1, 1 };

        List<Sprite> Obstacles = new List<Sprite>();

        public Game()
        {
            BackgroundColor = ConsoleColor.Green;
            Console.BufferWidth = 120;
            Console.BufferHeight = 50;
            Console.SetWindowSize(width,height);
        }

        /// <summary>
        /// Initiates the game by painting the background
        /// and initiating the hero
        /// </summary>
        public void InitGame()
        {
            ClearBackground();
            actor = new Sprite { X = 10, Y = 38 };

            CreateObstacles();
            DrawObstacles();
        }

        private void CreateObstacles()
        {
            int start = 40;

            Sprite o;
            for (var i = 0; i < obstacles.Length; i++)
            {
                o = new Sprite();
                o.X = start;
                o.Y = actor.Y;

                if (obstacles[i] == 0)
                {
                    o.IsActive = false;
                }

                Obstacles.Add(o);
                start++;
            }
        }
        private void TimerCallback(Object o)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("TIME: " + DateTime.Now);

            // Force a garbage collection to occur for this demo.
            GC.Collect();

            Update();
            Draw();
        }

        // The Game loop
        public void Loop()
        {
            Timer t = new Timer(TimerCallback, null, 0, 90);

            ConsoleKeyInfo keyInfo;
            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Spacebar:
                        isJumping = true;
                        break;
                }
            }
        }

        private void Update()
        {
            actor.MoveRight(1);

            if (isJumping)
            {
                if (jumpY <= 5)
                {
                    actor.Clear(this);
                    actor.MoveUp(1);
                    jumpY++;
                }
                else
                {
                    isFalling = true;
                    isJumping = false;
                }
            }
            if (isFalling && jumpY >1 )
            {
                actor.Clear(this);
                actor.MoveDown(1);
                jumpY--;
            }
            else
            {
                isFalling = false;
            }
        }


        public void Draw()
        {
            actor.Clear(this); // Clear the actor
            actor.Draw();  // Draw the actor at the new location
            groundSprite.Draw();
        }

        private void DrawObstacles()
        {
            foreach (var o in Obstacles)
            {
                Console.SetCursorPosition(o.X, o.Y);
                if (o.IsActive)
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.Write(" ");
                }
            }

            Console.ResetColor();
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
