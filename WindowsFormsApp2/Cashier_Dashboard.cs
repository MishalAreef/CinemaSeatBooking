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
    public partial class Cashier_Dashboard : Form
    {
        public Cashier_Dashboard()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cashier_ViewBills obj = new Cashier_ViewBills();
            obj.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Cashier_Customer_Settings obj = new Cashier_Customer_Settings();
            obj.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cashier_AddProducts obj = new Cashier_AddProducts();
            obj.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cashier_Set_Currently_Showing obj = new Cashier_Set_Currently_Showing();
            obj.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Staff_Login obj = new Staff_Login();
            obj.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            this.lblTime.Text = dateTime.ToString();
        }

        private void lblTime_Click(object sender, EventArgs e)
        {

        }
    }
}
