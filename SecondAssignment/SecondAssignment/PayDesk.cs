using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondAssignment
{
    class PayDesk
    {
        public PayDesk() { }

        public static void ShowInformations(Card c, int currentPurchase)
        {
            String typeName = c.GetType().Name;

            Console.WriteLine("Card: " + typeName);
            Console.WriteLine("Mock data: turnover $" + c.Turnover + ", purchase value $" + currentPurchase);
            Console.WriteLine("Discount rate: " + c.CalculateDiscount() * 100 + "%");
            Console.WriteLine("Discount: $" + c.CalculateDiscount() * currentPurchase);
            Console.WriteLine("Total purchase: $" + (currentPurchase - (c.CalculateDiscount() * currentPurchase)));
            Console.WriteLine();

        }
        
    }
}
