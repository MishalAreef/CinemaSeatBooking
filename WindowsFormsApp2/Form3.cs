using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        //The part where I use the parameters from the summary btnClick events from Form1.
        public void VideoUrl(string incoming)
        {
            webBrowser1.Navigate("https://www.youtube.com/watch?v=" + incoming + "?version=3");
        }
        public void Ozil(string incoming)
        {
            richTextBox1.Text = incoming;
        }
        public void Director(string incoming) 
        {
            label5.Text = incoming;
        }
        public void Actors(params string[] incoming)
        {
            label6.Text = "";
            for (int i = 0; i < incoming.Length; i++)
            {
                label6.Text += incoming[i];
                if (i != (incoming.Length - 1))
                    label6.Text += ", ";
            }
        }
        public void Time(string incoming)
        {
            label7.Text = incoming;
        }
        public void Genre(string incoming)
        {
            label8.Text = incoming;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted_1(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
