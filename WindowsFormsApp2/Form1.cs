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
    public partial class Form1 : Form
    {
        SqlConnection sqlCon;
        SqlDataAdapter sda;
        DataTable dt;
        public Form1()
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
            timer1.Start();
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

        Form3 ozil = new Form3();
        Form2 reznov = new Form2();
        Gosta gos = new Gosta();

        #region FilmÖzetButonEvents
        private void btnOzet1_Click(object sender, EventArgs e)
        {
            ozil.Text = gos.hallMovieName[1];
            ozil.VideoUrl("8Qn_spdM5Zg");
            ozil.Director("J.J. Abrams");
            ozil.Actors(" Daisy Ridley", " John Boyega", "Oscar Isaac", "Mark Hamill", "Adam Driver");
            ozil.Time("2h 22m");
            ozil.Genre("Fantasy/Sci-fi");
            ozil.Ozil(gos.starwarsRiseoftheSkywalker);
            ozil.ShowDialog();
        }

        private void btnOzet2_Click(object sender, EventArgs e)
        {
            ozil.Text = gos.hallMovieName[2];
            ozil.VideoUrl("KK8FHdFluOQ");
            ozil.Director("Niki Caro");
            ozil.Actors("Donnie Yen", "Jet Li", "Gong Li");
            ozil.Time("2 hours");
            ozil.Genre("Drama/Fantasy");
            ozil.Ozil(gos.mulan);
            ozil.ShowDialog();
        }

        private void btnOzet4_Click(object sender, EventArgs e)
        {
            ozil.Text = gos.hallMovieName[3];
            ozil.VideoUrl("cYplvwBvGA4");
            ozil.Director("Larry Charles");
            ozil.Actors("Sacha Baron Cohen", "Anna Faris", "Ben Kingsley", "Jason Mantzoukas", "Megan Fox");
            ozil.Time("1h 39m");
            ozil.Genre("Comedy");
            ozil.Ozil(gos.theDictator);
            ozil.ShowDialog();
        }
        #endregion

        #region TicketFormPass
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            reznov.MovieDetail(gos.hallMovieName[1], gos.starwarsHallNo, gos.starwarsSession);
            reznov.ShowDialog();
            reznov.cbClean();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            reznov.MovieDetail(gos.hallMovieName[2], gos.mulanHallNo, gos.mulanSession);
            reznov.ShowDialog();
            reznov.cbClean();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            reznov.MovieDetail(gos.hallMovieName[3], gos.dictatorHallNo, gos.dictatorSession);
            reznov.ShowDialog();
            reznov.cbClean();
            this.Show();
        }
        #endregion


        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = MISHAL\\MISHSQL; Initial Catalog = BigError; Integrated Security = True");
            sda = new SqlDataAdapter("select MovieID,MovieName,ReleaseDate,Director,Genre,Trailer from  MovieInfo", con);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            timer2.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customer_Home obj = new Customer_Home();
            obj.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Customer_View_Upcomig_Movies_Trailers obj = new Customer_View_Upcomig_Movies_Trailers();
            obj.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Customer_Home obj = new Customer_Home();
            obj.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Customer_View_Products obj = new Customer_View_Products();
            obj.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            this.lblTime.Text = dateTime.ToString();
        }

        private void timer2_Tick(object sender, EventArgs e)
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
                pictureBox5.Visible = true;
            }
            else if (pictureBox5.Visible == true)
            {
                pictureBox5.Visible = false;
                pictureBox6.Visible = true;
            }
            else if (pictureBox6.Visible == true)
            {
                pictureBox6.Visible = false;
                pictureBox7.Visible = true;
            }
            else if (pictureBox7.Visible == true)
            {
                pictureBox7.Visible = false;
                pictureBox8.Visible = true;
            }
            else if (pictureBox8.Visible == true)
            {
                pictureBox8.Visible = false;
                pictureBox1.Visible = true;
            }
        }
    }
}
