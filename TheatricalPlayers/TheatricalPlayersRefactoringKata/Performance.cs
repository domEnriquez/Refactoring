namespace TheatricalPlayersRefactoringKata
{
    public class Performance
    {
        private string playId;
        private int audience;

        public string PlayID { get => playId; set => playId = value; }
        public int Audience { get => audience; set => audience = value; }

        public Performance(string playId, int audience)
        {
            this.playId = playId;
            this.audience = audience;
        }
    }
}
