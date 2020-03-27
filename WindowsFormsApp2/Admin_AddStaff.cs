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
    public partial class Admin_AddStaff : Form
    {
        SqlConnection sqlCon;
        public Admin_AddStaff()
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
                if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtConfirmPassword.Text) || string.IsNullOrEmpty(cmbUserType.Text))
                {
                    MessageBox.Show("Please fill all the information! ", "Register", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    valid = false;
                }
                else if (!txtPassword.Text.Equals(txtConfirmPassword.Text))
                {
                    MessageBox.Show("Password and confirmed Password should match ", "Register", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    valid = false;
                }
                if (valid)
                {
                    SqlCommand cmd = new SqlCommand("insert into StaffInfo values('" + txtUsername.Text + "', '" + txtPassword.Text + "','" + cmbUserType.Text + "');", sqlCon);


                    int temp = cmd.ExecuteNonQuery();

                    if (temp > 0)
                    {
                        MessageBox.Show("Staff Account Successfully Registered!", "Register Form", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to Register Staff Account!PLEASE TRY AGAIN! ", "Register Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to Register Staff Account! User Already Exist in the System" + ex, "Register", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Admin_AddStaff_Load(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select Username from  StaffInfo", sqlCon);
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
                        txtUsername.Text = "U00" + CTR;
                    }
                    else if (CTR >= 9 && CTR < 99)
                    {
                        CTR = CTR + 1;
                        txtUsername.Text = "U0" + CTR;
                    }
                    else if (CTR > 99)
                    {
                        CTR = CTR + 1;
                        txtUsername.Text = "U" + CTR;
                    }

                }

                else
                {
                    txtUsername.Text = "U001";
                }
                dr.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show("error" + e1, "Register Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin_AddUsers obj = new Admin_AddUsers();
            obj.Show();
            this.Hide();
        }
    }
}
