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
    public partial class Staff_Login : Form
    {
        SqlConnection sqlCon;
        public Staff_Login()
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

        private void Staff_Login_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

                bool valid = true;
                if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("Need to fill all the values ", "Register", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    valid = false;
                }
                if (valid)
                {
                    String UserType = null;
                    SqlCommand cmd = new SqlCommand
                    ("Select UserType from  StaffInfo where Username ='" + txtUsername.Text + "' and Password ='" + txtPassword.Text + "' ", sqlCon);
                    SqlDataReader dr = cmd.ExecuteReader();
                    Boolean records = dr.HasRows;
                    if (records)
                    {
                        while (dr.Read())
                        {
                            UserType = dr[0].ToString();
                        }
                        if (UserType.Equals("Admin"))
                        {
                            Admin_Dashboard obj = new Admin_Dashboard();
                            obj.Show();
                            this.Hide();
                        }
                        else if (UserType.Equals("Cashier"))
                        {
                            Cashier_Dashboard obj = new Cashier_Dashboard();
                            obj.Show();
                            this.Hide();
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Invalid login Credentials/Staff Account Does Not Exist", "Login Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting data" + ex, "Login Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home_Dashboard obj = new Home_Dashboard();
            obj.Show();
            this.Hide();

        }
    }
}
