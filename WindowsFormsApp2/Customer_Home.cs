using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Customer_Home : Form
    {
        public Customer_Home()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams parms = base.CreateParams;
                parms.ClassStyle |= 0x200;
                return parms;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Customer_Register obj = new Customer_Register();
            obj.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customer_Login obj = new Customer_Login();
            obj.Show();
            this.Hide();
        }

        private void Customer_Home_Load(object sender, EventArgs e)
        {
            textBox1.Text = Cashier_Customer_Settings.passingText;
        }
    }
}
