namespace NeoSnake
{
    // This class contains all looks that are available in the game
    // The looks are hard coded into the game
    internal class LookManager
    {
        private const string defaultLooksName = "Default";
        private Dictionary<string, Looks> looks;

        public LookManager() 
        {
            looks = new Dictionary<string, Looks>();

            // Default looks
            PictureBox defaultGameTile = new PictureBox();
            defaultGameTile.BorderStyle = BorderStyle.FixedSingle;
            defaultGameTile.BackColor = Color.White;

            PictureBox defaultHead = new PictureBox();
            defaultHead.BorderStyle = BorderStyle.FixedSingle;
            defaultHead.BackColor = Color.DarkGreen;

            PictureBox defaultBody = new PictureBox();
            defaultBody.BorderStyle = BorderStyle.FixedSingle;
            defaultBody.BackColor = Color.Green;

            PictureBox defaultApple = new PictureBox();
            defaultApple.BorderStyle = BorderStyle.FixedSingle;
            defaultApple.BackColor = Color.DarkRed;

            Looks defaultLook = new Looks(defaultGameTile, defaultHead, defaultBody, defaultApple);
            looks.Add("Clear_code Assets", defaultLook);

            // Clean_code Assets
            PictureBox ccTile = new PictureBox();
            ccTile.BorderStyle = BorderStyle.None;
            ccTile.BackColor = Color.Green;

            PictureBox ccHead = new PictureBox();
            defaultHead.BorderStyle = BorderStyle.FixedSingle;
            defaultHead.BackColor = Color.DarkGreen;

            PictureBox ccBody = new PictureBox();
            defaultBody.BorderStyle = BorderStyle.FixedSingle;
            defaultBody.BackColor = Color.Green;

            PictureBox ccApple = new PictureBox();
            ccApple.BorderStyle = BorderStyle.None;
            ccApple.Image = Image.FromFile("apple.png");
            ccApple.SizeMode = PictureBoxSizeMode.StretchImage;

            Looks ccLook = new Looks(ccTile, ccHead, ccBody, ccApple);
            looks.Add("Clear_code Assets", ccLook);
        }

        public string GetDefaultLooksName()
        {
            return defaultLooksName;
        }

        public Looks GetLooksByName(string name)
        {
            return looks[name];
        }
    }
}
