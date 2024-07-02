namespace NeoSnake
{
    public partial class SnakeForm : Form
    {
        const int FIELD_COUNT_X = 8;
        const int FIELD_COUNT_Y = 8;

        const int FIELD_WIDTH = 50;
        const int FIELD_HEIGHT = 50;

        const int START_BODY_ELEMENTS = 3; // TBD: If less than 1, it will crash

        public SnakeForm()
        {
            InitializeComponent();
        }

        private void SnakeForm_Load(object sender, EventArgs e)
        {
            
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

            bool spawnNewApple = false;

            // Check if the head is inside/ontop/below the apple (eating mechanic)
            if(head.x == apple.x && head.y == apple.y)
            {
                spawnNewApple = true;
                body.Add(buttPosition);
            }

            // Check if game is over
            if(isGameOver())
            {
                game_timer.Stop();
                running = false;
                spawnNewApple = false;

                Label resultLabel = new Label();

                if (hasWon())
                {
                    resultLabel.Text = "You've won!";
                    render(false);
                } else
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
                Controls.Add(resultLabel);
                resultLabel.BringToFront();
            }

            if(spawnNewApple)
            {
                // Spawn a new apple
                spawnApple();
            }

            // Render game fields
            if(running) render();
        }

        private void SnakeForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Set moving direction of the snake based on the inputs
            // Also preventing that the snake just "reverses" 
            switch(e.KeyCode)
            {
                case Keys.Left:
                    if(direction == Direction.UP || direction == Direction.DOWN)
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
    }
}
