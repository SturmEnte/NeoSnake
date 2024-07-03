namespace NeoSnake
{
    internal class Looks
    {
        private PictureBox head;
        private PictureBox body;
        private PictureBox apple;

        Looks(PictureBox head, PictureBox body, PictureBox apple)
        {
            this.head = head;
            this.body = body;
            this.apple = apple;
        }

        public PictureBox GetHead()
        {
            return head;
        }

        public PictureBox GetBody()
        {
            return body;
        }

        public PictureBox GetApple()
        {
            return apple;
        }
    }
}
