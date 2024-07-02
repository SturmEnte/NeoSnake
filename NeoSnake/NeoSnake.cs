namespace NeoSnake
{
    public partial class SnakeForm : Form
    {
        const int FIELD_COUNT_X = 4;
        const int FIELD_COUNT_Y = 4;

        const int FIELD_WIDTH = 50;
        const int FIELD_HEIGHT = 50;

        const int START_BODY_ELEMENTS = 1; // TBD: If less than 1, it will crash

        public SnakeForm()
        {
            InitializeComponent();
        }

        private void SnakeForm_Load(object sender, EventArgs e)
        {
            this.ClientSize = new Size(panel_menu.Width, panel_menu.Height);
            panel_menu.Left = 0;
            panel_menu.Top = 0;
            this.CenterToScreen();
            //Game game = new Game(FIELD_COUNT_X, FIELD_COUNT_Y, FIELD_WIDTH, FIELD_HEIGHT, 500, START_BODY_ELEMENTS, this);
            //game.start();
        }

        // Centers the window to the screen
        // This method is necisarily for the Game class to be able to center for some reason
        public void Center()
        {
            this.CenterToScreen();
        }
    }
}
