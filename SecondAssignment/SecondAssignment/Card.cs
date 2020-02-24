using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondAssignment
{
    abstract class Card
    {
        public String Owner { get; set; }
        public double Turnover { get; set; }
        public double InitialDiscount { get; set; }

        public Card() { }
        
        public abstract double CalculateDiscount();
        
            
    }
}
