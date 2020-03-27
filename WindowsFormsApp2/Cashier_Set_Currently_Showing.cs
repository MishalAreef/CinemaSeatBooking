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
    public partial class Cashier_Set_Currently_Showing : Form
    {
        public Cashier_Set_Currently_Showing()
        {
            InitializeComponent();
        }
        //protected override CreateParams CreateParams
        //{
           // get
            //{                                             //This Form needs to have a feature to CLose
                //CreateParams parms = base.CreateParams;
                //parms.ClassStyle |= 0x200;
                //return parms;
           //}
        //}
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Visible == true)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;
            }
            else if (pictureBox2.Visible == true)
            {
                pictureBox2.Visible = false;
                pictureBox3.Visible = true;
            }
            else if (pictureBox3.Visible == true)
            {
                pictureBox3.Visible = false;
                pictureBox4.Visible = true;
            }
            else if (pictureBox4.Visible == true)
            {
                pictureBox4.Visible = false;
                pictureBox1.Visible = true;
            }
        }

        private void Cashier_Set_Currently_Showing_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
