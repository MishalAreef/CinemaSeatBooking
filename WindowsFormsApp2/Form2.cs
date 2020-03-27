using System;
using System.Data;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        Seat kol = new Seat();
        Ticket bil = new Ticket();
        DiscountTicket ibil = new DiscountTicket();
        ErrorProvider provider = new ErrorProvider();
        SqlConnection sqlCon;
        SqlDataAdapter sda;
        DataTable dt;

        public Form2()
        {
            try
            {

                DBconnection obj = new DBconnection();
                sqlCon = obj.GetConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting" + ex, "Login", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
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
        #region MyMethod
        public void MovieDetail(string incoming, int hall, params string[] sessionHours)
        {
            comboBox3.Items.Clear();
            textBox1.Text = incoming;
            comboBox2.SelectedIndex = hall - 1;
            for (int i = 0; i < sessionHours.Length; i++)
                comboBox3.Items.Add(sessionHours[i]);
        }
        public void Filling(string movieName, int sessionIndex)
        {
            List<Control> a = new List<Control>();
            foreach (Control c in Controls.OfType<CheckBox>())
            {
                a.Add(c);
            }
            kol.Filling(sessionIndex, textBox1, a);
        }
        private bool ValidateTB5()
        {
            bool status = true;
            if (textBox5.Text == "")
            {
                provider.SetError(textBox5, "Please enter your name");
                status = false;
            }
            else
                provider.SetError(textBox5, "");
            return status;
        }
        private bool ValidateTB6()
        {
            bool status = true;
            if (textBox6.Text == "")
            {
                provider.SetError(textBox6, "Please enter your last name");
                status = false;
            }
            else
                provider.SetError(textBox6, "");
            return status;
        }
        private bool ValidateTB7()
        {
            bool status = true;
            if (textBox7.Text == "")
            {
                provider.SetError(textBox7, "Please enter your Phone Number");
                status = false;
            }
            else
                provider.SetError(textBox7, "");
            return status;
        }
        private bool ValidateCB1()
        {
            bool status = true;
            if (comboBox1.SelectedIndex == -1)
            {
                provider.SetError(comboBox1, "Please select a Payment Method");
                status = false;
            }
            else
                provider.SetError(comboBox1, "");
            return status;
        }
        
        public void cbPassive()
        {
            foreach (Control c in Controls.OfType<CheckBox>())
            {
                ((CheckBox)c).Enabled = false;
            }
        }
        public void cbClean()
        {
            foreach (Control c in Controls.OfType<CheckBox>())
            {
                ((CheckBox)c).Checked = false;
                ((CheckBox)c).Enabled = true;
                ((CheckBox)c).BackColor = Color.LightGreen;
            }
        }
        public void cbEvent(object sender, EventArgs e)
        {
            Control sesb = ((Control)sender);
            switch (sesb.BackColor.Name)
            {
                case "LightGreen":
                    sesb.BackColor = Color.DeepSkyBlue;
                    listBox1.Items.Add(sesb.Name.Substring(2, 1) + sesb.Name.Substring(3));
                    label17.Text = (Convert.ToDouble(label17.Text.Substring(0, label17.Text.Length-3)) + bil.PriceFull).ToString() + " MVR";
                    break;
                case "DeepSkyBlue":
                    sesb.BackColor = Color.LightGreen;
                    listBox1.Items.Remove(sesb.Name.Substring(2, 1) + sesb.Name.Substring(3));
                    label17.Text = (Convert.ToDouble(label17.Text.Substring(0, label17.Text.Length - 3)) - bil.PriceFull).ToString() + " MVR";
                    break;
                default:
                    sesb.BackColor = SystemColors.Control;
                    break;
            }
        }
        public void lbClean()
        {
            listBox1.Items.Clear();
        }
        public void EntryClean()
        {
            textBox2.Text = textBox5.Text = textBox6.Text = textBox7.Text = "";
            comboBox1.SelectedIndex = -1;
        }
        public void MoneyClean()
        {
            label17.Text = "0 MVR";
        }
        #endregion

        #region ControlEventleri
        private void button1_Click(object sender, EventArgs e)
        {
            bool statusTB5 = ValidateTB5();
            bool statusTB6 = ValidateTB6();
            bool statusTB7 = ValidateTB7();
            bool statusCB1 = ValidateCB1();
            bool statusTB2 = ValidateTB2();
            bool statusLB1 = ValidateLB1();
            bool statusRB1 = ValidateRB1();
            bool statusRB2 = ValidateRB2();
            if (statusTB5 && statusTB6 && statusTB7 && statusCB1 && statusTB2 && statusLB1  )// statusRB1 && statusRB2)
            {

                bil.Fn = textBox5.Text;
                bil.Lastn = textBox6.Text;
                bil.PhoneNo = textBox7.Text;
                bil.PaymentMethod = comboBox1.SelectedItem.ToString();
                
                kol.Reservation(textBox1.Text, comboBox3.SelectedIndex, listBox1);
                Filling(textBox1.Text, comboBox3.SelectedIndex);
                bil.PrintInformation(textBox2.Text, listBox1);
                EntryClean();
                MoneyClean();
            }
            else
            {
                if (!statusTB2)
                    MessageBox.Show("Discount Code Is Incorrect!");
                else if (!statusLB1)
                    MessageBox.Show("No Seat Selection Made!");
                else
                    MessageBox.Show("Please fill in the required (*) fields!");
            }
        }
        private void textBoxAlpha_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                        && !char.IsSeparator(e.KeyChar);
        }
        private void textBoxNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void listBox1_Click(object sender, EventArgs e)
        {
            button4.Enabled = true;
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
            button4.Enabled = false;
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            cbClean();
            lbClean();
            Filling(textBox1.Text, comboBox3.SelectedIndex);
            if (rbFood1.Checked)
            {
                rbFood1.Checked = false;
            }
        }
        private void FormSeat_FormClosing(object sender, FormClosingEventArgs e)
        {
            cbPassive();
        }

        private void FormSeat_Load(object sender, EventArgs e)
        {
            
            cbPassive();
            
        }
        private void textBox5_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateTB5();
        }
        private void textBox6_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateTB6();
        }
        private void textBox7_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateTB7();
        }
        private void comboBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateCB1();
        }
        private void textBox2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateTB2();
        }
        public bool ValidateTB2()
        {
            bool status = true;
            int i = 0;
            foreach (string kod in ibil.DiscountCode)
            {
                if (textBox2.Text == "")
                    i++;
                else if (textBox2.Text == kod)
                    i++;
            }
            if (i == 0)
                status = false;
            return status;
        }
        private void radioButton1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateRB1();
            
        }
        public bool ValidateRB1()
        {
            
            if ((rbFood1.Checked))
            {
                label17.Text = (Convert.ToDouble(label17.Text.Substring(0, label17.Text.Length - 3)) + bil.Food).ToString() +  " MVR";   //Add Food price if checked
                return false;
            }
            else 
            {
                label17.Text = (Convert.ToDouble(label17.Text.Substring(0, label17.Text.Length - 3)) + bil.Zero).ToString() + " MVR";   //Minus Food price if Unchecked
            }
            
            return true;
        }
        public bool ValidateRB2()
        {
            if ((rbBeverage1.Checked))
            {
                label17.Text = (Convert.ToDouble(label17.Text.Substring(0, label17.Text.Length - 3)) + bil.Beverage).ToString()  + " MVR";   //Add Beverage price if checked
                return false;
            }
            else
            {
                label17.Text = (Convert.ToDouble(label17.Text.Substring(0, label17.Text.Length - 3)) + bil.Zero).ToString() + " MVR";   //Minus Food price if Unchecked
            }
            return false;

        }
        private void listBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateLB1();
        }
        public bool ValidateLB1()
        {
            bool status = true;
            if (listBox1.Items.Count == 0)
                status = false;
            return status;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
                button2.Enabled = true;
            else
                button2.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
           

            if (textBox2.Text == ibil.DiscountCode[0])
                MessageBox.Show("You got 5% discount.\nAt the end of the transaction will be deducted from the ticket amount.");
            else if (textBox2.Text == ibil.DiscountCode[1])
                MessageBox.Show("You got 15% discount.\nAt the end of the transaction will be deducted from the ticket amount.");
            else if (textBox2.Text == ibil.DiscountCode[2])
                MessageBox.Show("You got 20% discount.\nAt the end of the transaction will be deducted from the ticket amount.");
            else
            {
                MessageBox.Show("Invalid discount code.");
                textBox2.Text = "";
                textBox2.Select();
            }
        }

        #endregion

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cbA1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void cbA3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        

        private void button5_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbFood_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbBeverage_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbG1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

