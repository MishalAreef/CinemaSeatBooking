using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp2
{
    public partial class Customer_View_Upcomig_Movies_Trailers : Form
    {
        SqlConnection sqlCon;
        SqlDataAdapter sda;
        DataTable dt;
        public Customer_View_Upcomig_Movies_Trailers()
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

        string _ytUrl;

        public string VideoId
        {
            get
            {
                var ytMatch = new Regex(@"youtu(?:\.be|be\.com)/(?:.*v(?:/|=)|(?:.*/)?)([a-zA-Z0-9-_]+)").Match(_ytUrl);
                return ytMatch.Success ? ytMatch.Groups[1].Value : string.Empty;
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            

            string message = "Upon Clicking Okay you are agreeing to our Terms and Conditions for Viewing Trailers";
            string title = "Warning";
            MessageBox.Show(message, title);
            _ytUrl = txtURL.Text;
            //webBrowser.Navigate($"http://youtube.com/v/{VideoId}?version=3");
            System.Diagnostics.Process.Start("http://www.Youtube.com/watch?v=" + txtURL.Text);


        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }

        private void Customer_View_Upcomig_Movies_Trailers_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = MISHAL\\MISHSQL; Initial Catalog = BigError; Integrated Security = True");
            sda = new SqlDataAdapter("select MovieID,MovieName,ReleaseDate,Director,Genre,Trailer from  MovieInfo", con);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
