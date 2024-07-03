namespace NeoSnake
{
    internal class Looks
    {
        private PictureBox tile;
        private PictureBox head;
        private PictureBox body;
        private PictureBox apple;

        Looks(PictureBox tile, PictureBox head, PictureBox body, PictureBox apple)
        {
            this.tile = tile;
            this.head = head;
            this.body = body;
            this.apple = apple;
        }

        public PictureBox GetTile()
        {
            return tile;
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
