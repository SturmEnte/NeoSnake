namespace NeoSnake
{
    public partial class SnakeForm : Form
    {
        Game game;
        LookManager lookManager;    

        // This warning can be ignored
        public SnakeForm()
        {
            InitializeComponent();
            lookManager = new LookManager();
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
            Looks looks = lookManager.GetLooksByName(cbox_looks.Text);

            panel_menu.Hide();
            game = new Game((int)num_fields_x.Value, (int)num_fields_y.Value, (int)num_size_x.Value, (int)num_size_y.Value, (int)num_tick_duration.Value, (int)num_start_body_elements.Value, looks, this);
            game.Start();
        }
    }
}
