using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class DiscountTicket:Ticket
    {
        private string[] discountCode = { "Scotch", "Jack", "Hennessy" };
        public string[] DiscountCode
        {
            get
            {
                return discountCode;
            }
            private set
            {

            }
        }
        public double AmountofDiscount(string code)
        {

            if (code == discountCode[1])
                return say * PriceFull * 0.85;
            else if (code == discountCode[2])
                return say * PriceFull * 0.80;
            else if (code == discountCode[0])
                return say * PriceFull * 0.95;
            else if (code == "")
                return say * PriceFull;
            else
                return -1;
        }
    }
}
