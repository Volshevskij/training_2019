using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Bet
    {
        public int Id { get; set; }        
        public Person Person { get; set; }
        public Event Event { get; set; }
        public int Coefficient { get; set; }
        public string Result { get; set; }
        public DateTime Date { get; set; }
    }
}
