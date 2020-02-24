using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondAssignment
{
    class SilverCard : Card
    {
        public SilverCard(String o, double to, double id)
        {
            this.Owner = o;
            this.Turnover = to;
            this.InitialDiscount = id;
        }
        public override double CalculateDiscount()
        {
            if (this.Turnover > 300)
                return 3.5 / 100;
            else
                return InitialDiscount / 100;
               
        }
    }
}
