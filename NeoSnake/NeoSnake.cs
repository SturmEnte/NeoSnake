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
