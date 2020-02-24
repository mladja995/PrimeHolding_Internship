using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondAssignment
{
    class Program
    {
       
        static void Main(string[] args)
        {
            BronzeCard bc = new BronzeCard("Jhon", 0, 0);
            SilverCard sc = new SilverCard("Ema", 600, 2);
            GoldCard gc = new GoldCard("Nick", 1500, 2);

            PayDesk.ShowInformations(bc, 150);
            PayDesk.ShowInformations(sc, 850);
            PayDesk.ShowInformations(gc, 1300);

        }
    }
}
