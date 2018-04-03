using System;

namespace TTAnalytics.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid Token { get; set; }
    }
}
