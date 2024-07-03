namespace NeoSnake
{
    public partial class SnakeForm : Form
    {
        Game game;
            
        // This warning can be ignored
        public SnakeForm()
        {
            InitializeComponent();
        }

        private void SnakeForm_Load(object sender, EventArgs e)
        {
            // Move start menu to the top left corner
            panel_menu.Left = 0;
            panel_menu.Top = 0;
            // Resize window to start menu size
            this.ClientSize = new Size(panel_menu.Width, panel_menu.Height);
            // Center the window aftert resizing it
            Center();
        }

        // Centers the window to the screen
        // This method is necisarily for the Game class to be able to center for some reason
        public void Center()
        {
            this.CenterToScreen();
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            PictureBox gameTile = new PictureBox();
            gameTile.BorderStyle = BorderStyle.FixedSingle;
            gameTile.BackColor = Color.White;

            PictureBox head = new PictureBox();
            head.BorderStyle = BorderStyle.FixedSingle;
            head.BackColor = Color.DarkGreen;

            PictureBox body = new PictureBox();
            body.BorderStyle = BorderStyle.FixedSingle;
            body.BackColor = Color.Green;

            PictureBox apple = new PictureBox();
            apple.BorderStyle = BorderStyle.FixedSingle;
            apple.BackColor = Color.DarkRed;

            Looks looks = new Looks(gameTile, head, body, apple);

            panel_menu.Hide();
            game = new Game((int)num_fields_x.Value, (int)num_fields_y.Value, (int)num_size_x.Value, (int)num_size_y.Value, (int)num_tick_duration.Value, (int)num_start_body_elements.Value, looks, this);
            game.Start();
        }
    }
}
