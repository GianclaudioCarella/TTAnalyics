namespace TTAnalytics.Model
{
    public class Match
    {
        public int Id { get; set; }
        public Tournament Tournament { get; set; }
        public Category Category { get; set; }
        public Round Round { get; set; }
        public int BestOf { get; set; }
    }
}
