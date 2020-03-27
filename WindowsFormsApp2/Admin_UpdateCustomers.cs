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
    public partial class Admin_UpdateCustomers : Form
    {
        SqlConnection sqlCon;
        SqlDataAdapter sda;
        DataTable dt;
        public Admin_UpdateCustomers()
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

        private void button1_Click(object sender, EventArgs e)
        {
            Admin_UpdateUsers obj = new Admin_UpdateUsers();
            obj.Show();
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Update UserInfo2 set Name = '" + txtName.Text + "', UserType='" + cmbUserType.Text + "'from UserInfo2 where PhoneNo='" + txtPhoneNo.Text + "'", sqlCon);

                int numberOfRecords = cmd.ExecuteNonQuery();
                if (numberOfRecords > 0)
                {
                    MessageBox.Show("CUSTOMER ACCOUNT RECORDS SUCCESSFULLY UPDATED!", "SUCCESSFUL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR UPDATING CUSTOMER DATA" + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
