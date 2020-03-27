using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace WindowsFormsApp2
{
    public partial class Home_Dashboard : Form
    {
        Thread th;
        Thread thh;
        Thread thhh;
        public Home_Dashboard()
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

        private void opennewForm(object obj)
        {
            Application.Run(new Customer_Home());
        }
        private void opennewForm2(object obj)
        {
            Application.Run(new Staff_Login());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are You Sure You want to Exit the System?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                this.Close();
            }
            else if (dialog == DialogResult.No)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(opennewForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(opennewForm2);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
