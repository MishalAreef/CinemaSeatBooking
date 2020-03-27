using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    class Seat
    {
        #region KoltukNumaraları
        // Starwars Seat
        public ArrayList StarwarsRiseoftheSkywalkerSession1 = new ArrayList();
        public ArrayList StarwarsRiseoftheSkywalkerSession2 = new ArrayList();
        public ArrayList StarwarsRiseoftheSkywalkerSession3 = new ArrayList();
        public ArrayList StarwarsRiseoftheSkywalkerSession4 = new ArrayList();
        public ArrayList StarwarsRiseoftheSkywalkerSession5 = new ArrayList();
        // Mulan Seat
        public ArrayList MuLanSession1 = new ArrayList();
        public ArrayList MuLanSession2 = new ArrayList();
        public ArrayList MuLanSession3 = new ArrayList();
        public ArrayList MuLanSession4 = new ArrayList();
        public ArrayList MuLanSession5 = new ArrayList();
        // Deli Aşk
        public ArrayList TheDictatorSession1 = new ArrayList();
        public ArrayList TheDictatorSession2 = new ArrayList();
        public ArrayList TheDictatorSession3 = new ArrayList();
        public ArrayList TheDictatorSession4 = new ArrayList();
        public ArrayList TheDictatorSession5 = new ArrayList();
        public ArrayList TheDictatorSession6 = new ArrayList();
        #endregion
        public void Reservation(string movieName, int sessionIndex, ListBox x)
        {
            if (movieName == "Starwars Rise of the Skywalker")
            {
                switch (sessionIndex)
                {
                    case 0:
                        for (int i = 0; i < x.Items.Count; i++) StarwarsRiseoftheSkywalkerSession1.Add(x.Items[i]);
                        break;
                    case 1:
                        for (int i = 0; i < x.Items.Count; i++) StarwarsRiseoftheSkywalkerSession2.Add(x.Items[i]);
                        break;
                    case 2:
                        for (int i = 0; i < x.Items.Count; i++) StarwarsRiseoftheSkywalkerSession3.Add(x.Items[i]);
                        break;
                    case 3:
                        for (int i = 0; i < x.Items.Count; i++) StarwarsRiseoftheSkywalkerSession4.Add(x.Items[i]);
                        break;
                    case 4:
                        for (int i = 0; i < x.Items.Count; i++) StarwarsRiseoftheSkywalkerSession5.Add(x.Items[i]);
                        break;
                }
            }
            else if (movieName == "MuLan")
            {
                switch (sessionIndex)
                {
                    case 0:
                        for (int i = 0; i < x.Items.Count; i++) MuLanSession1.Add(x.Items[i]);
                        break;
                    case 1:
                        for (int i = 0; i < x.Items.Count; i++) MuLanSession1.Add(x.Items[i]);
                        break;
                    case 2:
                        for (int i = 0; i < x.Items.Count; i++) MuLanSession1.Add(x.Items[i]);
                        break;
                    case 3:
                        for (int i = 0; i < x.Items.Count; i++) MuLanSession1.Add(x.Items[i]);
                        break;
                    case 4:
                        for (int i = 0; i < x.Items.Count; i++) MuLanSession1.Add(x.Items[i]);
                        break;
                }
            }
            else if (movieName == "The Dictator")
            {
                switch (sessionIndex)
                {
                    case 0:
                        for (int i = 0; i < x.Items.Count; i++) TheDictatorSession1.Add(x.Items[i]);
                        break;
                    case 1:
                        for (int i = 0; i < x.Items.Count; i++) TheDictatorSession2.Add(x.Items[i]);
                        break;
                    case 2:
                        for (int i = 0; i < x.Items.Count; i++) TheDictatorSession3.Add(x.Items[i]);
                        break;
                    case 3:
                        for (int i = 0; i < x.Items.Count; i++) TheDictatorSession4.Add(x.Items[i]);
                        break;
                    case 4:
                        for (int i = 0; i < x.Items.Count; i++) TheDictatorSession5.Add(x.Items[i]);
                        break;
                    case 5:
                        for (int i = 0; i < x.Items.Count; i++) TheDictatorSession6.Add(x.Items[i]);
                        break;
                }
            }
        }
        public void Filling(int sessionIndex, TextBox textBox1, List<Control> checks)
        {
            if (textBox1.Text == "Starwars Rise of the Skywalker")
            {
                switch (sessionIndex)
                {
                    case 0:
                        for (int i = 0; i < this.StarwarsRiseoftheSkywalkerSession1.Count; i++)
                            foreach (Control c in checks)
                                if (((CheckBox)c).Name.ToString().Substring(2) == this.StarwarsRiseoftheSkywalkerSession1[i].ToString())
                                {
                                    ((CheckBox)c).BackColor = Color.Red;
                                    ((CheckBox)c).Enabled = false;
                                }
                        break;
                    case 1:
                        for (int i = 0; i < this.StarwarsRiseoftheSkywalkerSession2.Count; i++)
                            foreach (Control c in checks)
                                if (((CheckBox)c).Name.ToString().Substring(2) == this.StarwarsRiseoftheSkywalkerSession2[i].ToString())
                                {
                                    ((CheckBox)c).BackColor = Color.Red;
                                    ((CheckBox)c).Enabled = false;
                                }
                        break;
                    case 2:
                        for (int i = 0; i < this.StarwarsRiseoftheSkywalkerSession3.Count; i++)
                            foreach (Control c in checks)
                                if (((CheckBox)c).Name.ToString().Substring(2) == this.StarwarsRiseoftheSkywalkerSession3[i].ToString())
                                {
                                    ((CheckBox)c).BackColor = Color.Red;
                                    ((CheckBox)c).Enabled = false;
                                }
                        break;
                    case 3:
                        for (int i = 0; i < this.StarwarsRiseoftheSkywalkerSession4.Count; i++)
                            foreach (Control c in checks)
                                if (((CheckBox)c).Name.ToString().Substring(2) == this.StarwarsRiseoftheSkywalkerSession4[i].ToString())
                                {
                                    ((CheckBox)c).BackColor = Color.Red;
                                    ((CheckBox)c).Enabled = false;
                                }
                        break;
                    case 4:
                        for (int i = 0; i < this.StarwarsRiseoftheSkywalkerSession5.Count; i++)
                            foreach (Control c in checks)
                                if (((CheckBox)c).Name.ToString().Substring(2) == this.StarwarsRiseoftheSkywalkerSession5[i].ToString())
                                {
                                    ((CheckBox)c).BackColor = Color.Red;
                                    ((CheckBox)c).Enabled = false;
                                }
                        break;
                }
            }
            else if (textBox1.Text == "MuLan")
            {
                switch (sessionIndex)
                {
                    case 0:
                        for (int i = 0; i < this.MuLanSession1.Count; i++)
                            foreach (Control c in checks)
                                if (((CheckBox)c).Name.ToString().Substring(2) == this.MuLanSession1[i].ToString())
                                {
                                    ((CheckBox)c).BackColor = Color.Red;
                                    ((CheckBox)c).Enabled = false;
                                }
                        break;
                    case 1:
                        for (int i = 0; i < this.MuLanSession2.Count; i++)
                            foreach (Control c in checks)
                                if (((CheckBox)c).Name.ToString().Substring(2) == this.MuLanSession2[i].ToString())
                                {
                                    ((CheckBox)c).BackColor = Color.Red;
                                    ((CheckBox)c).Enabled = false;
                                }
                        break;
                    case 2:
                        for (int i = 0; i < this.MuLanSession3.Count; i++)
                            foreach (Control c in checks)
                                if (((CheckBox)c).Name.ToString().Substring(2) == this.MuLanSession3[i].ToString())
                                {
                                    ((CheckBox)c).BackColor = Color.Red;
                                    ((CheckBox)c).Enabled = false;
                                }
                        break;
                    case 3:
                        for (int i = 0; i < this.MuLanSession4.Count; i++)
                            foreach (Control c in checks)
                                if (((CheckBox)c).Name.ToString().Substring(2) == this.MuLanSession4[i].ToString())
                                {
                                    ((CheckBox)c).BackColor = Color.Red;
                                    ((CheckBox)c).Enabled = false;
                                }
                        break;
                    case 4:
                        for (int i = 0; i < this.MuLanSession5.Count; i++)
                            foreach (Control c in checks)
                                if (((CheckBox)c).Name.ToString().Substring(2) == this.MuLanSession5[i].ToString())
                                {
                                    ((CheckBox)c).BackColor = Color.Red;
                                    ((CheckBox)c).Enabled = false;
                                }
                        break;
                }
            }
            else if (textBox1.Text == "The Dictator")
            {
                switch (sessionIndex)
                {
                    case 0:
                        for (int i = 0; i < this.TheDictatorSession1.Count; i++)
                            foreach (Control c in checks)
                                if (((CheckBox)c).Name.ToString().Substring(2) == this.TheDictatorSession1[i].ToString())
                                {
                                    ((CheckBox)c).BackColor = Color.Red;
                                    ((CheckBox)c).Enabled = false;
                                }
                        break;
                    case 1:
                        for (int i = 0; i < this.TheDictatorSession2.Count; i++)
                            foreach (Control c in checks)
                                if (((CheckBox)c).Name.ToString().Substring(2) == this.TheDictatorSession2[i].ToString())
                                {
                                    ((CheckBox)c).BackColor = Color.Red;
                                    ((CheckBox)c).Enabled = false;
                                }
                        break;
                    case 2:
                        for (int i = 0; i < this.TheDictatorSession3.Count; i++)
                            foreach (Control c in checks)
                                if (((CheckBox)c).Name.ToString().Substring(2) == this.TheDictatorSession3[i].ToString())
                                {
                                    ((CheckBox)c).BackColor = Color.Red;
                                    ((CheckBox)c).Enabled = false;
                                }
                        break;
                    case 3:
                        for (int i = 0; i < this.TheDictatorSession4.Count; i++)
                            foreach (Control c in checks)
                                if (((CheckBox)c).Name.ToString().Substring(2) == this.TheDictatorSession4[i].ToString())
                                {
                                    ((CheckBox)c).BackColor = Color.Red;
                                    ((CheckBox)c).Enabled = false;
                                }
                        break;
                    case 4:
                        for (int i = 0; i < this.TheDictatorSession5.Count; i++)
                            foreach (Control c in checks)
                                if (((CheckBox)c).Name.ToString().Substring(2) == this.TheDictatorSession5[i].ToString())
                                {
                                    ((CheckBox)c).BackColor = Color.Red;
                                    ((CheckBox)c).Enabled = false;
                                }
                        break;
                    case 5:
                        for (int i = 0; i < this.TheDictatorSession6.Count; i++)
                            foreach (Control c in checks)
                                if (((CheckBox)c).Name.ToString().Substring(2) == this.TheDictatorSession6[i].ToString())
                                {
                                    ((CheckBox)c).BackColor = Color.Red;
                                    ((CheckBox)c).Enabled = false;
                                }
                        break;
                }
            }
        }
    }
}

  