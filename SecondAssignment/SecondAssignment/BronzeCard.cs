using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondAssignment
{
    class BronzeCard : Card
    {
        public BronzeCard(String o, double to, double id)
        {
            this.Owner = o;
            this.Turnover = to;
            this.InitialDiscount = id;
        }
        public override double CalculateDiscount()
        {
            if (this.Turnover < 100)
                return 0;
            if (this.Turnover >= 100 && this.Turnover <= 300)
                return 1 / 100;
            else
                return 2.5 / 100;
        }
    }
}
