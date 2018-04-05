namespace TTAnalytics.Model
{
    public class State
    {
        public int Id { get; set; }
        public virtual Country Country { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
    }
}
