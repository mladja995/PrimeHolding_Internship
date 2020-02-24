using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondAssignment
{
    class GoldCard : Card
    {
        private double maxDiscount = 10;

        public GoldCard(String o, double to, double id)
        {
            this.Owner = o;
            this.Turnover = to;
            this.InitialDiscount = id;
        }

        public override double CalculateDiscount()
        {
            if (this.Turnover < 100)
                return this.InitialDiscount / 100;

            double check = Math.Round(this.Turnover / 100);
          
            if ((this.InitialDiscount + check) > maxDiscount)
                return this.maxDiscount / 100;
            else
                return (this.InitialDiscount + check) / 100;

        }
    }
}
