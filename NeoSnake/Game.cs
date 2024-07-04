using System.Runtime.CompilerServices;
using System.Windows.Forms;

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

        Looks looks;

        Delegate returnToMenuFunc;

        System.Windows.Forms.Timer gameTimer;
        SnakeForm snakeForm;

        Button endScreenButton;
        Label endScreenLabel;

        public Game(int fieldsX, int fieldsY, int fieldWidth, int fieldHeight, int tickDuration, int startingBodyElements, Looks looks, Func<bool> returnToMenuFunc, SnakeForm snakeForm) 
        {
            this.fieldsX = fieldsX;
            this.fieldsY = fieldsY;
            this.fieldWidth = fieldWidth;
            this.fieldHeight = fieldHeight;
            this.startingBodyElements = startingBodyElements;
            this.looks = looks;
            this.returnToMenuFunc = returnToMenuFunc;
            this.snakeForm = snakeForm;

            this.random = new Random();

            // This is only to prevent the program from spiting warnings and errors
            this.endScreenButton = new Button();
            this.endScreenLabel = new Label();

            this.head = new Position((int)Math.Round(fieldsX / (float)2), (int)Math.Round(fieldsY / (float)2));
            this.body = new List<Position>();
            this.gameField = new PictureBox[fieldsX, fieldsY];
            // Initialize apple to prevent the warning
            // This position will be overwritten when initializing the form
            this.apple = new Position(0, 0);
            SpawnApple();

            PictureBox looksTile = looks.GetTile();

            // Initialize game field array
            for (int y = 0; y < fieldsY; y++)
            {
                for (int x = 0; x < fieldsX; x++)
                {
                    PictureBox gameTile = new PictureBox();

                    gameTile.BorderStyle = looksTile.BorderStyle;
                    gameTile.BackColor = looksTile.BackColor;

                    gameTile.SetBounds(x * fieldWidth, y * fieldHeight, fieldWidth, fieldHeight);
                    gameField[x, y] = gameTile;
                    snakeForm.Controls.Add(gameTile);
                }
            }

            // Set window size to game field size
            snakeForm.ClientSize = new Size(fieldsX * fieldWidth, fieldsY * fieldHeight);
            snakeForm.Center();

            // Add initial snake body elements
            for (int i = 0; i < startingBodyElements; i++)
            {
                body.Add(new Position(head.x - (i + 1), head.y));
            }

            // Register key down hander
            snakeForm.KeyDown += KeyDownHandler;

            // Render game for the first time
            Render();

            // Create the timer
            gameTimer = new System.Windows.Forms.Timer();
            gameTimer.Interval = tickDuration;
            gameTimer.Tick += Tick;
        }

        public void Start()
        {
            gameTimer.Start();
            gameTimer.Enabled = true;
        }

        private void Tick(object? sender, EventArgs e)
        {
            Update();
            // render(); //TBD: Move render call to tick method from update method
        }

        private void Update()
        {
            Position buttPosition = new Position(body[body.Count - 1].x, body[body.Count - 1].y);

            // Move snake body
            List<Position> newBody = new List<Position>();

            for (int i = 0; i < body.Count; i++)
            {
                if (i == 0)
                {
                    newBody.Add(new Position(head.x, head.y));
                    continue; // If you change this to break the snake will look like its cut in half at the start
                }
                newBody.Add(new Position(body[i - 1].x, body[i - 1].y));
            }

            body.Clear();
            for (int i = 0; i < newBody.Count; i++)
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

            bool spawnNewApple = false;

            // Check if the head is inside/ontop/below the apple (eating mechanic)
            if (head.x == apple.x && head.y == apple.y)
            {
                spawnNewApple = true;
                body.Add(buttPosition);
            }

            // Check if game is over
            if (IsGameOver())
            {
                gameTimer.Stop();
                running = false;
                spawnNewApple = false;

                Label resultLabel = new Label();

                if (HasWon())
                {
                    resultLabel.Text = "You've won!";
                    Render(false);
                }
                else
                {
                    resultLabel.Text = "You've lost!";
                }

                resultLabel.Font = new Font("Consolas", 20);
                resultLabel.AutoSize = true;
                resultLabel.BackColor = Color.Transparent; // TBD: Fix this. This does not work for some reason
                // TBD: Fix centering
                /*resultLabel.TextAlign = ContentAlignment.MiddleCenter;
                resultLabel.Dock = DockStyle.None;
                resultLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right; // Anchor to all sides
                /*int xPosition = (this.ClientSize.Width - resultLabel.Width) / 2;
                int yPosition = (this.ClientSize.Height - resultLabel.Height) / 2;
                resultLabel.Top = yPosition;
                resultLabel.Left = xPosition;*/
                //resultLabel.SetBounds(xPosition, yPosition, resultLabel.Width, resultLabel.Height);
                //resultLabel.Anchor = (AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left);
                snakeForm.Controls.Add(resultLabel);
                resultLabel.BringToFront();

                Button returnToMenuButton = new Button();
                returnToMenuButton.Font = new Font("Consolas", 20);
                returnToMenuButton.AutoSize = true;
                returnToMenuButton.BackColor = Color.Transparent;
                returnToMenuButton.Text = "Return to menu";
                returnToMenuButton.Click += (sender, args) =>
                    {
                        returnToMenuFunc.DynamicInvoke();
                    };
                snakeForm.Controls.Add(returnToMenuButton);
                returnToMenuButton.BringToFront();

                this.endScreenButton = returnToMenuButton;
                this.endScreenLabel = resultLabel;
                 
            }

            if (spawnNewApple)
            {
                // Spawn a new apple
                SpawnApple();
            }

            // Render game fields
            if (running) Render();
        }

        private void Render(bool renderApple = true)
        {
            PictureBox looksTile = looks.GetTile();
            PictureBox looksHead = looks.GetHead();
            PictureBox looksBody = looks.GetBody();
            PictureBox looksApple = looks.GetApple();

            // Clear game field
            for (int x = 0; x < fieldsX; x++)
            {
                for (int y = 0; y < fieldsY; y++)
                {
                    gameField[x, y].BorderStyle = looksTile.BorderStyle;
                    gameField[x, y].BackColor = looksTile.BackColor;
                    gameField[x, y].Image = null;
                }
            }

            // Render head
            gameField[head.x, head.y].BorderStyle = looksHead.BorderStyle;
            gameField[head.x, head.y].BackColor = looksHead.BackColor;

            // Render body
            for (int i = 0; i < body.Count; i++)
            {
                gameField[body[i].x, body[i].y].BorderStyle = looksBody.BorderStyle;
                gameField[body[i].x, body[i].y].BackColor = looksBody.BackColor;
            }

            // Render apple
            if (renderApple)
            {
                gameField[apple.x, apple.y].BorderStyle = looksApple.BorderStyle;
                gameField[apple.x, apple.y].BackColor = looksApple.BackColor;
                gameField[apple.x, apple.y].Image = looksApple.Image;
                gameField[apple.x, apple.y].SizeMode = looksApple.SizeMode;
            }
        }
        
        private void KeyDownHandler(object sender, KeyEventArgs e)
        {
            // Set moving direction of the snake based on the inputs
            // Also preventing that the snake just "reverses" 
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (direction == Direction.UP || direction == Direction.DOWN)
                    {
                        direction = Direction.LEFT;
                    }
                    break;
                case Keys.Up:
                    if (direction == Direction.LEFT || direction == Direction.RIGHT)
                    {
                        direction = Direction.UP;
                    }
                    break;
                case Keys.Right:
                    if (direction == Direction.UP || direction == Direction.DOWN)
                    {
                        direction = Direction.RIGHT;
                    }
                    break;
                case Keys.Down:
                    if (direction == Direction.LEFT || direction == Direction.RIGHT)
                    {
                        direction = Direction.DOWN;
                    }
                    break;
                default:
                    break;
            }
        }

        private void SpawnApple()
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

        private bool IsGameOver()
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
            if (HasWon())
            {
                return true;
            }

            return false;
        }

        private bool HasWon()
        {
            // If the amount of body parts is 1 less than the total amount of game fields (because the head does not to the body)
            // Then the game is won
            if (body.Count == fieldsX * fieldsY - 1)
            {
                return true;
            }
            return false;
        }

        public void Delete()
        {
            foreach (var field in gameField)
            {
                field.Dispose();
            }

            this.endScreenLabel.Dispose();
            this.endScreenButton.Dispose();
            this.gameTimer.Dispose();
        }
    }
}
