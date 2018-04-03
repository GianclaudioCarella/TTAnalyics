namespace TTAnalytics.Model
{
    // O que é essa classe?
    public class Equipament
    {
        public int Id { get; set; }
        public string Paddle { get; set; }
        public string FrontRubber { get; set; }
        public string BackRubber { get; set; }
        
        // Equipament in use
        public bool Activity { get; private set; }
    }
}
