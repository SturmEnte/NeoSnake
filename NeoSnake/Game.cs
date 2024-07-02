﻿using System.Windows.Forms;

namespace NeoSnake
{
    internal class Game
    {
        bool running = true;

        Random random;

        PictureBox[,] gameField;

        Position head;
        List<Position> body;
        Position apple;

        Direction direction = Direction.RIGHT;

        int fieldsX, fieldsY;
        int fieldWidth, fieldHeight;
        int startingBodyElements;

        System.Windows.Forms.Timer gameTimer;

        public Game(int fieldsX, int fieldsY, int fieldWidth, int fieldHeight, int tickDuration, int startingBodyElements) 
        {
            this.fieldsX = fieldsX;
            this.fieldsY = fieldsY;
            this.fieldWidth = fieldWidth;
            this.fieldHeight = fieldHeight;
            this.startingBodyElements = startingBodyElements;

            this.random = new Random();

            this.head = new Position((int)Math.Round(fieldsX / (float)2), (int)Math.Round(fieldsY / (float)2));
            this.body = new List<Position>();
            this.gameField = new PictureBox[fieldsX, fieldsY];
            // Initialize apple to prevent the warning
            // This position will be overwritten when initializing the form
            this.apple = new Position(0, 0);
            
            // Initialize game field array
            for (int y = 0; y < fieldsY; y++)
            {
                for (int x = 0; x < fieldsX; x++)
                {
                    PictureBox gameTile = new PictureBox();
                    gameTile.BorderStyle = BorderStyle.FixedSingle;
                    gameTile.SetBounds(x * fieldWidth, y * fieldHeight, fieldWidth, fieldHeight);
                    gameField[x, y] = gameTile;
                    Controls.Add(gameTile);
                }
            }

            // Set window size to game field size
            this.ClientSize = new Size(fieldsX * fieldWidth, fieldsY * fieldHeight);

            // Add initial snake body elements
            for (int i = 0; i < startingBodyElements; i++)
            {
                body.Add(new Position(head.x - (i + 1), head.y));
            }

            // Render game for the first time
            render();

            // Create and start the timer
            gameTimer = new System.Windows.Forms.Timer();
            gameTimer.Interval = tickDuration;
            gameTimer.Tick += tick;
            gameTimer.Enabled = true;
            gameTimer.Start();
        }

        private void tick(object? sender, EventArgs e)
        {
            update();
            render();
        }

        private void update()
        {

        }

        private void render(bool renderApple = false)
        {
            // Clear game field
            for (int x = 0; x < fieldsX; x++)
            {
                for (int y = 0; y < fieldsY; y++)
                {
                    gameField[x, y].BackColor = Color.White;
                }
            }

            // Render head
            gameField[head.x, head.y].BackColor = Color.DarkGreen;

            // Render body
            for (int i = 0; i < body.Count; i++)
            {
                gameField[body[i].x, body[i].y].BackColor = Color.Green;
            }

            // Render apple
            if (renderApple) gameField[apple.x, apple.y].BackColor = Color.DarkRed;
        }

        private void spawnApple()
        {
            // Spawn a new apple at a random position
            // If the new apple is spawned inside the player, then spawn a new one until one is spawned outside the player
            while (true)
            {
                apple = new Position(random.Next(0, fieldsX), random.Next(0, fieldsY));

                if (head.x == apple.x && head.y == apple.y)
                {
                    continue;
                }

                bool shouldBreak = true;

                for (int i = 0; i < body.Count; i++)
                {
                    if (body[i].x == apple.x && body[i].y == apple.y)
                    {
                        shouldBreak = false;
                        break;
                    }
                }

                if (shouldBreak)
                {
                    break;
                }
            }

        }

        private bool isGameOver()
        {
            // Check if snake is outside of the game field
            if (head.x < 0 || head.x >= fieldsX || head.y < 0 || head.y >= fieldsY)
            {
                return true;
            }

            // Check if the snake is inside its self
            for (int i = 0; i < body.Count; i++)
            {
                if (body[i].x == head.x && body[i].y == head.y) return true;
            }

            // Check if won
            if (hasWon())
            {
                return true;
            }

            return false;
        }

        private bool hasWon()
        {
            if (body.Count == fieldsX * fieldsY - 1)
            {
                return true;
            }
            return false;
        }
    }
}
