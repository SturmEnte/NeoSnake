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

        PictureBox[,] gameField;

        Position head = new Position((int)Math.Round(FIELD_COUNT_X / (float)2), (int)Math.Round(FIELD_COUNT_Y / (float)2));

        ArrayList body = new ArrayList();

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

            // Add initial snake body elements
            // TBD

            // Start game timer
            game_timer.Enabled = true;
            game_timer.Start();
        }

        private void game_timer_Tick(object sender, EventArgs e)
        {
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

            render();
        }

        private void render()
        {
            for (int x = 0; x < FIELD_COUNT_X; x++)
            {
                for (int y = 0; y < FIELD_COUNT_Y; y++)
                {
                    if (head.x == x && head.y == y)
                    {
                        gameField[x, y].BackColor = Color.DarkGreen;
                        continue;
                    }


                    gameField[x, y].BackColor = Color.White;
                }
            }
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
