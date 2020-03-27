using System.Windows.Forms;


namespace WindowsFormsApp2
{
    
    class Ticket
    {
        private string fn, lastn, phoneNo, paymentmethod;
        private static double priceFull = 17.00;
        private static double food = 20.00;
        private static double beverage = 10.00;
        public static double zero = 0;
        private static double serviceFee = 1.75;
        public static int say;
        public string Fn
        {
            get { return fn; }
            set { fn = value; }
        }
        public string Lastn
        {
            get { return lastn; }
            set { lastn = value; }
        }
        public string PhoneNo
        {
            get { return phoneNo; }
            set { phoneNo = value; }
        }
        public string PaymentMethod
        {
            get { return paymentmethod; }
            set { paymentmethod = value; }
        }
        public double PriceFull
        {
            get
            {
                return priceFull;
            }
            private set
            {

            }
        }
        public double Zero
        {
            get
            {
                return zero;
            }
            private set
            {

            }
        }
        public double Food
        {
            get
            {
                return food;
            }
            private set
            {

            }
        }
        public double Beverage
        {
            get
            {
                return beverage;
            }
            private set
            {

            }
        }
        public double ServiceFee
        {
            get
            {
                return serviceFee;
            }
            private set
            {

            }
        }
        public void PrintInformation(string code,ListBox x)
        {
            say = x.Items.Count;
            DiscountTicket ib = new DiscountTicket();

            string seatNo = "";
            for (int i = 0; i < x.Items.Count; i++)
            {
                seatNo += x.Items[i];
                if (x.Items.Count - 1 != i)
                    seatNo += ", ";
            }
            string[] veri = { fn, lastn, paymentmethod, phoneNo, seatNo, ib.AmountofDiscount(code).ToString("F2"), serviceFee.ToString(), food.ToString(), beverage.ToString(),(ib.AmountofDiscount(code)
            + serviceFee).ToString("F2") };
            Form4 fm4 = new Form4();
            fm4.Data(veri);
            fm4.ShowDialog();
            x.Items.Clear();
            

        }
        
    }
}
