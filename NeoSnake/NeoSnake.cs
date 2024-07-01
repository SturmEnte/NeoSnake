using System;
using System.Collections;

namespace NeoSnake
{
    public partial class SnakeForm : Form
    {
        const int FIELD_COUNT_X = 20;
        const int FIELD_COUNT_Y = 20;

        const int FIELD_WIDTH = 20;
        const int FIELD_HEIGHT = 20;

        const int START_BODY_ELEMENTS = 3;

        int tick = 0;

        bool running = true;

        Random random = new Random();

        PictureBox[,] gameField;

        Position head = new Position((int)Math.Round(FIELD_COUNT_X / (float)2), (int)Math.Round(FIELD_COUNT_Y / (float)2));
        List<Position> body = new List<Position>();
        Position apple;

        Direction direction = Direction.RIGHT;

        public SnakeForm()
        {
            InitializeComponent();
        }

        private void SnakeForm_Load(object sender, EventArgs e)
        {
            // Initialize game field array
            gameField = new PictureBox[FIELD_COUNT_X, FIELD_COUNT_Y];

            for (int y = 0; y < FIELD_COUNT_Y; y++)
            {
                for (int x = 0; x < FIELD_COUNT_X; x++)
                {
                    PictureBox gameTile = new PictureBox();
                    gameTile.BorderStyle = BorderStyle.FixedSingle;
                    gameTile.SetBounds(x * FIELD_WIDTH, y * FIELD_HEIGHT, FIELD_WIDTH, FIELD_HEIGHT);
                    gameField[x, y] = gameTile;
                    Controls.Add(gameTile);
                }
            }

            // Set window size to game field size
            // TBD

            // Add initial snake body elements
            for (int i = 0; i < START_BODY_ELEMENTS; i++) 
            {
                body.Add(new Position(head.x - (i + 1), head.y));    
            }

            // Spawn apple for the first time
            spawnApple();

            // Render game for the first time
            render();

            // Start game timer
            game_timer.Enabled = true;
            game_timer.Start();
        }

        private void game_timer_Tick(object sender, EventArgs e)
        {
            Position buttPosition = new Position(body[body.Count - 1].x, body[body.Count - 1].y);

            // Move snake body
            List<Position> newBody = new List<Position>();

            for(int i = 0; i < body.Count; i++)
            {
                if (i == 0)
                {
                    newBody.Add(new Position(head.x, head.y));
                    continue; // If you change this to break the snake will look like its cut in half at the start
                }
                newBody.Add(new Position(body[i - 1].x, body[i - 1].y));
            }

            body.Clear();
            for(int i = 0; i < newBody.Count; i++)
            {
                body.Add(newBody[i]);
            }

            // Move snake head
            switch (direction)
            {
                case Direction.LEFT:
                    head.x--;
                    break;
                case Direction.UP:
                    head.y--;
                    break;
                case Direction.RIGHT:
                    head.x++;
                    break;
                case Direction.DOWN:
                    head.y++;
                    break;
            }

            // Check if the head is inside/ontop/below the apple (eating mechanic)
            if(head.x == apple.x && head.y == apple.y)
            { 
                body.Add(buttPosition);

                // Spawn a new apple
                spawnApple();
            }

            // Check if game is over
            if(isGameOver())
            {
                game_timer.Stop();
                running = false;
            }

            // Render game fields
            if(running) render();
        }

        private void render()
        {
            // Clear game field
            for (int x = 0; x < FIELD_COUNT_X; x++)
            {
                for (int y = 0; y < FIELD_COUNT_Y; y++)
                {
                    gameField[x, y].BackColor = Color.White;
                }
            }

            // Render head
            gameField[head.x, head.y].BackColor = Color.DarkGreen;

            // Render body
            for(int i = 0; i < body.Count; i++)
            {
                gameField[body[i].x, body[i].y].BackColor = Color.Green;
            }

            // Render apple
            gameField[apple.x, apple.y].BackColor = Color.DarkRed;
        }

        private void spawnApple()
        {
            apple = new Position(random.Next(0, FIELD_COUNT_X), random.Next(0, FIELD_COUNT_Y));
        }

        private bool isGameOver()
        {
            // Check if snake is outside of the game field
            if (head.x < 0 || head.x >= FIELD_COUNT_X || head.y < 0 || head.y >= FIELD_COUNT_Y)
            {
                return true;
            }

            // Check if the snake is inside its self
            for (int i = 0; i < body.Count; i++)
            {
                if (body[i].x == head.x && body[i].y == head.y) return true;
            }

            // Check if won
            // TBD

            return false;
        }

        private void SnakeForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Left:
                    direction = Direction.LEFT;
                    break;
                case Keys.Up:
                    direction = Direction.UP; 
                    break;
                case Keys.Right:
                    direction = Direction.RIGHT;
                    break;
                case Keys.Down:
                    direction = Direction.DOWN;
                    break;
                default:
                    break;
            }
        }
    }

    enum Direction
    {
        LEFT, RIGHT, UP, DOWN
    }

    class Position
    {
        public int x, y;
        public Position(int x, int y) {
            this.x = x;
            this.y = y;
        }
    }
}