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
    public partial class Cashier_Customer_Settings : Form
    {
        public static string passingText;
        public Cashier_Customer_Settings()
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

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDisable_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cashier_Dashboard obj = new Cashier_Dashboard();
            obj.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are You Sure You want to Add This Message Today?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                passingText = txtOne.Text;
                MessageBox.Show("Message Added Successfully");
            }
            else if (dialog == DialogResult.No)
            {

            }
            

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
