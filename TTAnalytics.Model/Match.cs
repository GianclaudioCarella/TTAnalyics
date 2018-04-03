namespace TTAnalytics.Model
{
    public class Match
    {
        public int Id { get; set; }
        public Tournament Tournament { get; set; }

        public Player PlayerA { get; set; }
        public Player PlayerB { get; set; }

        public Player Winner { get; set; }

        public Round Round { get; set; }
    }
}
