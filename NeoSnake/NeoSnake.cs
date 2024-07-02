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
    }
}
