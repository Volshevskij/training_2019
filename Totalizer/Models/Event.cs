using System;

namespace Models
{
    public class Event
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }
        public SportType SportType { get; set; }
        public string Status { get; set; }
    }
}
