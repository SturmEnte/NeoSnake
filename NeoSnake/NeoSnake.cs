namespace NeoSnake
{
    public partial class SnakeForm : Form
    {
        const int FIELD_COUNT_X = 4;
        const int FIELD_COUNT_Y = 4;

        const int FIELD_WIDTH = 50;
        const int FIELD_HEIGHT = 50;

        const int START_BODY_ELEMENTS = 2;

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

                Label resultLabel = new Label();

                if (hasWon())
                {
                    resultLabel.Text = "You've won!";
                } else
                {
                    resultLabel.Text = "You've lost!";
                }

                resultLabel.Font = new Font("Consolas", 20);
                resultLabel.AutoSize = true;
                resultLabel.BackColor = Color.Transparent; // TBD: Fix this. This does not work for some reason
                resultLabel.SetBounds(this.Width / 2 - resultLabel.Width / 2, this.Height / 2 - resultLabel.Height / 2, resultLabel.Width, resultLabel.Height);
                Controls.Add(resultLabel);
                resultLabel.BringToFront();
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
            // Spawn a new apple at a random position
            // If the new apple is spawned inside the player, then spawn a new one until one is spawned outside the player
            while (true)
            {
                apple = new Position(random.Next(0, FIELD_COUNT_X), random.Next(0, FIELD_COUNT_Y));
                
                if(head.x == apple.x && head.y == apple.y)
                {
                    continue;
                }

                bool shouldBreak = true;

                for(int i = 0; i < body.Count; i++)
                {
                    if (body[i].x == apple.x && body[i].y == apple.y)
                    {
                        shouldBreak = false;
                        break;
                    }
                }

                if(shouldBreak)
                {
                    break;
                }
            }
            
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
            if(hasWon())
            {
                return true;
            }

            return false;
        }

        private bool hasWon()
        {
            if (body.Count == FIELD_COUNT_X * FIELD_COUNT_Y - 1)
            {
                return true;
            }
            return false;
        }

        private void SnakeForm_KeyDown(object sender, KeyEventArgs e)
        {
            // TBD: Only allow left or right move ments relative to the current direction
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
