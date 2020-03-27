using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp2
{
    public partial class Customer_Login : Form
    {
        SqlConnection sqlCon;
        public Customer_Login()
        {
            try
            {

                DBconnection obj = new DBconnection();
                sqlCon = obj.GetConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting" + ex, "Customer Form", MessageBoxButtons.OK,
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            try
            {

                bool valid = true;
                if (string.IsNullOrEmpty(txtPhoneNo.Text) || string.IsNullOrEmpty(txtName.Text))
                {
                    MessageBox.Show("Need to fill all the values ", "Register", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    valid = false;
                }
                if (valid)
                {
                    String UserType = null;
                    SqlCommand cmd = new SqlCommand
                    ("Select UserType from  UserInfo2 where PhoneNo ='" + txtPhoneNo.Text + "' and Name ='" + txtName.Text + "' ", sqlCon);
                    SqlDataReader dr = cmd.ExecuteReader();
                    Boolean records = dr.HasRows;
                    if (records)
                    {
                        while (dr.Read())
                        {
                            UserType = dr[0].ToString();
                        }
                        if (UserType.Equals("Customer"))
                        {
                            Form1 obj = new Form1();
                            obj.Show();
                            this.Hide();
                        }
                        
                        
                    }
                    else
                    {
                        MessageBox.Show("Invalid login Credentials", "Login Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting data" + ex, "Login Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customer_Home obj = new Customer_Home();
            obj.Show();
            this.Hide();
        }
    }
}
