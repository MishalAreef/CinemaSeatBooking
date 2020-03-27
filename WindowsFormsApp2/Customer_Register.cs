﻿using System;
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
    public partial class Customer_Register : Form
    {
        SqlConnection sqlCon;
        public Customer_Register()
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

        private void button2_Click(object sender, EventArgs e)
        {
            Customer_Home obj = new Customer_Home();
            obj.Show();
            this.Hide();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                bool valid = true;
                if (string.IsNullOrEmpty(txtPhoneNo.Text) || string.IsNullOrEmpty(txtConfirmName.Text) || string.IsNullOrEmpty(cmbUserType.Text))
                {
                    MessageBox.Show("Please fill all the information! ", "Register", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    valid = false;
                }
                else if (!txtName.Text.Equals(txtConfirmName.Text))
                {
                    MessageBox.Show("Customer Name and confirmed Name must match ", "Register", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    valid = false;
                }
                if (valid)
                {
                    SqlCommand cmd = new SqlCommand("insert into UserInfo2 values('" + txtPhoneNo.Text + "', '" + txtName.Text + "','" + cmbUserType.Text + "');", sqlCon);


                    int temp = cmd.ExecuteNonQuery();

                    if (temp > 0)
                    {
                        MessageBox.Show("User Successfully Registered!", "Register Form", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to Register User!PLEASE TRY AGAIN! ", "Register Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to Register User! USER ALREADY EXISTS! " + ex, "Register", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Customer_Register_Load(object sender, EventArgs e)
        {
            try
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
            catch (Exception e1)
            {
                MessageBox.Show("error" + e1, "Register Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
