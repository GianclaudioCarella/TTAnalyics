using System;

namespace TTAnalytics.Model
{
    public class Player
    {
        public int Id { get; private set; }
        public string FullName { get; set; }
        public virtual Country Country { get; set; }
        public DateTime DateOfBirth { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Club Club { get; set; }
        public virtual Handedness Handedness { get; set; }
        public virtual PlayingStyle PlayingStyle { get; set; }
        public virtual Grip Grip { get; set; }
    }
}
