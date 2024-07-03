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

            Looks defaultLooks = new Looks(defaultGameTile, defaultHead, defaultBody, defaultApple);
            looks.Add("Default", defaultLooks);
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
