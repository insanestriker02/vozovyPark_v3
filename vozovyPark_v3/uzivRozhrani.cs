using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace vozovyPark_v3
{
    public partial class uzivRozhrani : Form
    {
        public uzivRozhrani(string jmeno, string prijmeni, string lastlog)
        {
            InitializeComponent();
            this.Size = new Size(960, 500);
            defbx.Location = new Point(226, 13);
            newRezBx.Hide();
            zrusRezBx.Hide();
            myRez.Hide();
            passChange.Hide();
            label1.Text = "Poslední přihlášení:";
            label2.Text = lastlog;
            label19.Text = jmeno;
            label20.Text = prijmeni;
            label19.Hide();
            label20.Hide();
            this.Text = "přihlášen jako: " + jmeno + " " + prijmeni;

        }
        #region vyber akci
        private void newRez_Click(object sender, EventArgs e)
        {
            if (zrusRezBx.Visible == true || myRez.Visible == true || passChange.Visible == true)
            {
                zrusRezBx.Hide();
                myRez.Hide();
                passChange.Hide();
            }
            defbx.Hide();
            newRezBx.Location = new Point(226, 13);
            newRezBx.Show();
        }

        private void zrusRez_Click(object sender, EventArgs e)
        {
            if (newRez.Visible == true || myRez.Visible == true || passChange.Visible == true)
            {
                newRezBx.Hide();
                myRez.Hide();
                passChange.Hide();
            }
            defbx.Hide();
            zrusRezBx.Location = new Point(226, 13);
            zrusRezBx.Show();
        }
        private void mojeRez_Click(object sender, EventArgs e)
        {
            allRezAkSez();
            if (newRez.Visible == true || zrusRezBx.Visible == true || passChange.Visible == true)
            {
                newRezBx.Hide();
                zrusRezBx.Hide();
                passChange.Hide();
            }
            defbx.Hide();
            myRez.Location = new Point(226, 13);
            myRez.Show();
        }

        private void zmenaHesla_Click(object sender, EventArgs e)
        {
            if (newRez.Visible == true || myRez.Visible == true || zrusRezBx.Visible == true)
            {
                newRezBx.Hide();
                myRez.Hide();
                zrusRezBx.Hide();
            }
            defbx.Hide();
            passChange.Location = new Point(226, 13);
            passChange.Show();
        }


        #endregion

        #region conf & back btns
        private void newRezConf_Click(object sender, EventArgs e)
        {
            string zavCislo = "";
            using (StreamReader sr0 = new StreamReader(Environment.CurrentDirectory + "\\Data\\cislaRezervaci.txt"))
            {
                string cisRez = sr0.ReadLine();
                double cisloRez = Convert.ToDouble(cisRez);
                
                sr0.Close();
                File.Delete(Environment.CurrentDirectory + "\\Data\\cislaRezervaci.txt");
                using (StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + "\\Data\\tempCisla.txt"))
                {
                    if (cisloRez < 10)
                    {
                        zavCislo = ("000000000000000" + (cisloRez + 1));
                    }
                    else if (cisloRez >= 10 && cisloRez <100)
                    {
                        zavCislo = ("00000000000000" + (cisloRez + 1));
                    }
                    else if (cisloRez >= 100 && cisloRez <1000)
                    {
                        zavCislo = ("0000000000000" + (cisloRez + 1));
                    }
                    else if (cisloRez >= 1000 && cisloRez < 10000)
                    {
                        zavCislo = ("000000000000" + (cisloRez + 1));
                    }
                    else if (cisloRez >= 10000 && cisloRez < 100000)
                    {
                        zavCislo = ("00000000000" + (cisloRez + 1));
                    }
                    else if (cisloRez >= 100000 && cisloRez < 1000000)
                    {
                        zavCislo = ("0000000000" + (cisloRez + 1));
                    }
                    else if (cisloRez >= 1000000 && cisloRez < 10000000)
                    {
                        zavCislo = ("000000000" + (cisloRez + 1));
                    }
                    else if (cisloRez >= 10000000 && cisloRez < 100000000)
                    {
                        zavCislo = ("00000000" + (cisloRez + 1));
                    }
                    else if (cisloRez >= 100000000 && cisloRez < 1000000000)
                    {
                        zavCislo = ("0000000" + (cisloRez + 1));
                    }
                    else if (cisloRez >= 1000000000 && cisloRez < 10000000000)
                    {
                        zavCislo = ("000000" + (cisloRez + 1));
                    }
                    else if (cisloRez >= 1000000000 && cisloRez < 100000000000)
                    {
                        zavCislo = ("00000" + (cisloRez + 1));
                    }
                    else if (cisloRez >= 100000000000 && cisloRez < 1000000000000)
                    {
                        zavCislo = ("0000" + (cisloRez + 1));
                    }
                    else if (cisloRez >= 1000000000 && cisloRez < 10000000000)
                    {
                        zavCislo = ("000" + (cisloRez + 1));
                    }
                    else if (cisloRez >= 10000000000 && cisloRez < 100000000000000)
                    {
                        zavCislo = ("00" + (cisloRez + 1));
                    }
                    else if (cisloRez >= 100000000000000 && cisloRez < 1000000000000000)
                    {
                        zavCislo = ("0" + (cisloRez + 1));
                    }
                    else if (cisloRez <= 1000000000000000)
                    {
                        zavCislo = ("" + cisloRez + 1);
                    }

                    label22.Text = zavCislo;
                    sw.WriteLine(zavCislo);
                    sw.Close();
                }
                File.Move(Environment.CurrentDirectory + "\\Data\\tempCisla.txt", Environment.CurrentDirectory + "\\Data\\cislaRezervaci.txt");
                label21.Text = Convert.ToString(cisloRez);
                
            }
            zapisRezer(label19.Text, label20.Text, zavCislo, vyberAuto.SelectedItem.ToString());

        }

        private void newRezBack_Click(object sender, EventArgs e)
        {
            newRezBx.Hide();
            defbx.Show();
        }

        private void zrusRezConf_Click(object sender, EventArgs e)
        {
            
        }

        private void zrusRezBack_Click(object sender, EventArgs e)
        {
            zrusRezBx.Hide();
            defbx.Show();
        }

        private void myRezBack_Click(object sender, EventArgs e)
        {
            myRez.Hide();
            defbx.Show();
        }

        private void newPassConfBtn_Click(object sender, EventArgs e)
        {

        }

        private void newPassBack_Click(object sender, EventArgs e)
        {
            passChange.Hide();
            defbx.Show();
        }

        private void myRezList_SelectedValueChanged(object sender, EventArgs e)
        {
            rezInfoList.Items.Clear();
            string selectedRezervace = myRezList.SelectedItem.ToString();
            string path = Environment.CurrentDirectory + "\\Data\\Rezervace";
            string path2 = Environment.CurrentDirectory + "\\Data\\Auta";
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] Files = dir.GetFiles();
            

            using (StreamReader sr = new StreamReader(path + "\\" + selectedRezervace + ".txt"))
            {
                string line;
                string[] auta = new string[2];
                for (int i = 0; i < auta.Length; i++)
                {
                    auta[i] = sr.ReadLine();
                }
                
                using (StreamReader sr2 = new StreamReader(path2 + "\\" + auta[1] + ".txt"))
                {
                    //string line2;
                    while ((line = sr2.ReadLine()) != null)
                    {
                        rezInfoList.Items.Add(sr2.ReadLine());
                    }
                    sr2.Close();
                }
                sr.Close();
                //string line;
                //while ((line = sr.ReadLine()) != null)
                //{
                //    rezInfoList.Items.Add(sr.ReadLine());
                //}
                //sr.Close();
            }
        }

        public void allRezAkSez()
        {
            myRezList.Items.Clear();
            string path = Environment.CurrentDirectory + "\\Data\\Rezervace";
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] Files = dir.GetFiles();
            foreach (FileInfo fi in Files)
            {
                using (StreamReader sr = new StreamReader(path + "\\" + fi.Name))
                {
                    if (sr.ReadLine() == (label19.Text + "_" + label20.Text))
                    {
                        myRezList.Items.Add(fi.Name.Replace(".txt",""));
                    }
                    sr.Close();
                }
            }

            //for (int i = 0; i < Files.Length; i++)
            //{
            //    myRezList.Items.Add((Files[i].Name.Replace(".txt", "")).Replace("_", " "));
            //}
        }
        #endregion


        public void zapisRezer(string jmeno, string prijmeni, string cisloRezervace, string cisloAuta)
        {
            string path = Environment.CurrentDirectory + "\\Data\\Rezervace\\" + cisloRezervace + ".txt";
            using (StreamWriter sw1 = new StreamWriter(path))
            {
                sw1.WriteLine(jmeno + "_" + prijmeni);
                sw1.WriteLine(cisloAuta);
                sw1.WriteLine("nazev: " + nazevRez);
            }
        }
        
    }
}
