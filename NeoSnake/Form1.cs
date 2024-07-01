namespace NeoSnake
{
    public partial class Form1 : Form
    {
        const int FIELD_COUNT_X = 20;
        const int FIELD_COUNT_Y = 20;

        const int FIELD_WIDTH = 20;
        const int FIELD_HEIGHT = 20;

        PictureBox[,] gameField;

        int headX = 0;
        int headY = 0;

        Direction direction = Direction.RIGHT;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gameField = new PictureBox[FIELD_COUNT_X, FIELD_COUNT_Y];

            for (int y = 0; y < FIELD_COUNT_Y; y++) 
            { 
                for(int x = 0; x < FIELD_COUNT_X; x++)
                {
                    PictureBox gameTile = new PictureBox();
                    gameTile.BorderStyle = BorderStyle.FixedSingle;
                    gameTile.SetBounds(x * FIELD_WIDTH, y * FIELD_HEIGHT, FIELD_WIDTH, FIELD_HEIGHT);
                    gameField[x, y] = gameTile;
                    Controls.Add(gameTile);
                }
            }

            game_timer.Enabled = true;
            game_timer.Start();
        }

        private void game_timer_Tick(object sender, EventArgs e)
        {
           
            
            render();
        }

        private void render() 
        {
            for (int x = 0; x < FIELD_COUNT_X; x++) 
            {
                for (int y = 0; y < FIELD_COUNT_Y; y++)
                {
                    if (headX == x && headY == y)
                    {
                        gameField[x, y].BackColor = Color.DarkGreen;
                        continue;
                    }


                    gameField[x,y].BackColor = Color.White;
                }
            }
        }
    }

    enum Direction
    {
        LEFT, RIGHT, UP, DOWN
    }
}
