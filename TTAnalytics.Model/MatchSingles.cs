namespace TTAnalytics.Model
{
    public class MatchSingles
    {
        public int Id { get; set; }
        public Match MatchId { get; set; }
        public Player PlayerA { get; set; }
        public Player PlayerB { get; set; }
        public Player PlayerWinner { get; set; }

        public int PlayerAGame1Score { get; set; }
        public int PlayerAGame2Score { get; set; }
        public int PlayerAGame3Score { get; set; }
        public int PlayerAGame4Score { get; set; }
        public int PlayerAGame5Score { get; set; }
        public int PlayerAGame6Score { get; set; }
        public int PlayerAGame7Score { get; set; }

        public int PlayerBGame1Score { get; set; }
        public int PlayerBGame2Score { get; set; }
        public int PlayerBGame3Score { get; set; }
        public int PlayerBGame4Score { get; set; }
        public int PlayerBGame5Score { get; set; }
        public int PlayerBGame6Score { get; set; }
        public int PlayerBGame7Score { get; set; }
    }
}
