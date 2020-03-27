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
    public partial class Admin_AddCustomer : Form
    {
        SqlConnection sqlCon;
        public Admin_AddCustomer()
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

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                bool valid = true;
                if (string.IsNullOrEmpty(txtPhoneNo.Text) || string.IsNullOrEmpty(txtConfirmName.Text) || string.IsNullOrEmpty(cmbCustomerType.Text))
                {
                    MessageBox.Show("Please fill all the information! ", "Register", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    valid = false;
                }
                else if (!txtName.Text.Equals(txtConfirmName.Text))
                {
                    MessageBox.Show("Name and confirmed Name should match ", "Register", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    valid = false;
                }
                if (valid)
                {
                    SqlCommand cmd = new SqlCommand("insert into UserInfo2 values('" + txtPhoneNo.Text + "', '" + txtName.Text + "','" + cmbCustomerType.Text + "');", sqlCon);


                    int temp = cmd.ExecuteNonQuery();

                    if (temp > 0)
                    {
                        MessageBox.Show("Customer Account Successfully Registered!", "Register Form", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to Register Customer Account!User Already Exist in the System! ", "Register Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to Register Customer Account!User Already Exist in the System!" + ex, "Register", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Admin_AddCustomer_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select PhoneNo from  UserInfo2", sqlCon);
            SqlDataReader dr = cmd.ExecuteReader();
            string id = "";
            Boolean records = dr.HasRows;
            if (records)
            {
                while (dr.Read())
                {
                    id = dr[0].ToString();
                }
                string idString = id.Substring(1);
                int CTR = Int32.Parse(idString);
                if (CTR >= 1 && CTR < 9)
                {
                    CTR = CTR + 1;
                    txtPhoneNo.Text = "123" + CTR;
                }
                else if (CTR >= 9 && CTR < 99)
                {
                    CTR = CTR + 1;
                    txtPhoneNo.Text = "12" + CTR;
                }
                else if (CTR > 99)
                {
                    CTR = CTR + 1;
                    txtPhoneNo.Text = "1" + CTR;
                }

            }

            else
            {
                txtPhoneNo.Text = "1234";
            }
            dr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin_AddUsers obj = new Admin_AddUsers();
            obj.Show();
            this.Hide();
        }
    }
}


