using System;

namespace Models
{
    public class Bet
    {
        public int Id { get; set; }        
        public Person Person { get; set; }
        public Event Event { get; set; }
        public int Coefficient { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public Team Team { get; set; }
    }
}
