namespace TTAnalytics.Model
{
    public class TournamentCategories
    {
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
