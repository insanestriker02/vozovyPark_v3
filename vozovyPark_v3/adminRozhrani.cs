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
    public partial class adminRozhrani : Form
    {
        public adminRozhrani(string jmeno, string prijmeni, string lastlog)
        {
            #region inicializace
            InitializeComponent();
            zrUzBx.Hide();
            zalUzBx.Hide();
            zalAut.Hide();
            zruAut.Hide();
            zmeHes.Hide();
            allUsers.Hide();
            allAuta.Hide();
            allRezer.Hide();
            Point start = new Point(175, 13);
            defbx.Location = start;
            this.Size = new Size(860, 500);
            this.Text = "přihlášen jako: " + jmeno + "istrátor";
            label1.Text = "Poslední přihlášení:";
            label2.Text = lastlog;
            label27.Text = jmeno;
            label28.Text = prijmeni;
            #endregion

            #region other start stuff

            zrusUzAkSez();
            allUzAkSez();
            allAutAkSez();
            zrAutAkSez();
            #endregion
        }

        #region vyber akci
        private void zalUz_Click(object sender, EventArgs e)
        {
            if (zrUzBx.Visible = true || zalAut.Visible == true || zruAut.Visible == true || zmeHes.Visible == true || allRezer.Visible == true || allUsers.Visible == true || allAuta.Visible == true)
            {
                zrUzBx.Hide();
                zalAut.Hide();
                zruAut.Hide();
                zmeHes.Hide();
                allRezer.Hide();
                allUsers.Hide();
                allAuta.Hide();
            }
            defbx.Hide();
            zalUzBx.Location = new Point(175, 13);
            zalUzBx.Show();
            
        }

        private void ZruUz_Click(object sender, EventArgs e)
        {
            zrusUzAkSez();
            if (zalUzBx.Visible = true || zalAut.Visible == true || zruAut.Visible == true || zmeHes.Visible == true || allRezer.Visible == true || allUsers.Visible == true || allAuta.Visible == true)
            {
                zalUzBx.Hide();
                zalAut.Hide();
                zruAut.Hide();
                zmeHes.Hide();
                allRezer.Hide();
                allUsers.Hide();
                allAuta.Hide();
            }
            defbx.Hide();
            zrUzBx.Location = new Point(175, 13);
            zrUzBx.Show();
        }

        private void vlAut_Click(object sender, EventArgs e)
        {
            if (zrUzBx.Visible = true || zalUzBx.Visible == true || zruAut.Visible == true || zmeHes.Visible == true || allRezer.Visible == true || allUsers.Visible == true || allAuta.Visible == true)
            {
                zrUzBx.Hide();
                zalUzBx.Hide();
                zruAut.Hide();
                zmeHes.Hide();
                allRezer.Hide();
                allUsers.Hide();
                allAuta.Hide();
            }
            defbx.Hide();
            zalAut.Location = new Point(175, 13);
            zalAut.Show();
        }

        private void zrAut_Click(object sender, EventArgs e)
        {
            zrAutAkSez();
            if (zrUzBx.Visible = true || zalAut.Visible == true || zruAut.Visible == true || zmeHes.Visible == true || allRezer.Visible == true || allUsers.Visible == true || allAuta.Visible == true)
            {
                zrUzBx.Hide();
                zalAut.Hide();
                zruAut.Hide();
                zmeHes.Hide();
                allRezer.Hide();
                allUsers.Hide();
                allAuta.Hide();
            }
            defbx.Hide();
            zruAut.Location = new Point(175, 13);
            zruAut.Show();
        }

        private void vzh_Click(object sender, EventArgs e)
        {
            if (zrUzBx.Visible = true || zalAut.Visible == true || zruAut.Visible == true || allRezer.Visible == true || allUsers.Visible == true || allAuta.Visible == true)
            {
                zrUzBx.Hide();
                zalAut.Hide();
                zruAut.Hide();
                allRezer.Hide();
                allUsers.Hide();
                allAuta.Hide();
            }
            defbx.Hide();
            zmeHes.Location = new Point(175, 13);
            zmeHes.Show();
        }

        private void vsRez_Click(object sender, EventArgs e)
        {
            if (zrUzBx.Visible = true || zalAut.Visible == true || zruAut.Visible == true || zmeHes.Visible == true || allRezer.Visible == true || allUsers.Visible == true || allAuta.Visible == true)
            {
                zrUzBx.Hide();
                zalAut.Hide();
                zruAut.Hide();
                zmeHes.Hide();
                allRezer.Hide();
                allUsers.Hide();
                allAuta.Hide();
            }
            defbx.Hide();
            allRezer.Location = new Point(175, 13);
            allRezer.Show();
        }

        private void vsUz_Click(object sender, EventArgs e)
        {
            allUzAkSez();
            if (zrUzBx.Visible = true || zalAut.Visible == true || zruAut.Visible == true || zmeHes.Visible == true || allRezer.Visible == true || allUsers.Visible == true || allAuta.Visible == true)
            {
                zrUzBx.Hide();
                zalAut.Hide();
                zruAut.Hide();
                zmeHes.Hide();
                allRezer.Hide();
                allUsers.Hide();
                allAuta.Hide();
            }
            defbx.Hide();
            allUsers.Location = new Point(175, 13);
            allUsers.Show();
        }

        private void vsAut_Click(object sender, EventArgs e)
        {
            allAutAkSez();
            if (zrUzBx.Visible = true || zalAut.Visible == true || zruAut.Visible == true || zmeHes.Visible == true || allRezer.Visible == true || allUsers.Visible == true || allAuta.Visible == true)
            {
                zrUzBx.Hide();
                zalAut.Hide();
                zruAut.Hide();
                zmeHes.Hide();
                allRezer.Hide();
                allUsers.Hide();
                allAuta.Hide();
            }
            defbx.Hide();
            allAuta.Location = new Point(175, 13);
            allAuta.Show();
        }

        #endregion

        #region confirm & back Btns

        
        private void confirmUzZal_Click(object sender, EventArgs e)
        {
            SHA256 sha256 = SHA256.Create();
            string jmeno = jmenoTxtBx.Text;
            string prijmeni = prijmeniTxtBx.Text;
            string path = Environment.CurrentDirectory + "\\Data" + "\\Users";
            string userData = jmeno.ToLower() + "_" + prijmeni.ToLower();
            string userPath = path + "\\" + userData;
            byte[] hesloHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(hesloTxtBx.Text));

            if (Directory.Exists(userPath))
            {
                MessageBox.Show("Zadaný uživatel již existuje", "user exists");
                jmenoTxtBx.Text = "";
                prijmeniTxtBx.Text = "";
                hesloTxtBx.Text = "";
                jmenoTxtBx.Focus();
            }
            else
            {
                Directory.CreateDirectory(userPath);
                //File.Create(userPath + "\\" + userData + ".txt");
                using (StreamWriter sw = new StreamWriter(userPath + "\\" + userData + ".txt"))
                {
                    sw.WriteLine("jmeno: " + jmeno);
                    sw.WriteLine("prijmeni: " + prijmeni);
                    sw.WriteLine("heslo: " + BitConverter.ToString(hesloHash).ToLower().Replace("-", ""));
                    sw.WriteLine("lastlog: " + DateTime.Now);
                    sw.Close();
                }
                using (StreamWriter sw = new StreamWriter(userPath + "\\" + userData + "_auta" + ".txt"))
                {
                    sw.Close();
                }
                MessageBox.Show("Uživatel úspěšně přidán", "user add");
                
                zalUzBx.Hide();
                defbx.Show();
            }
        }

        private void backUzZal_Click(object sender, EventArgs e)
        {
            zalUzBx.Hide();
            defbx.Show();
        }

        private void confirmUzZr_Click(object sender, EventArgs e)
        {
            string deletePath = Environment.CurrentDirectory + "\\Data\\Users" + "\\" +listUzivateluZr.SelectedItem.ToString().Replace(" ","_");
            if (listUzivateluZr.SelectedItem.ToString() == "admin admin")
            {
                MessageBox.Show("Nemůžete vymazat administrátora!", "admin delete");
            }
            else
            {
                foreach (string s in Directory.GetFiles(deletePath))
                {
                    File.Delete(s);
                }
                
                Directory.Delete(deletePath);
                MessageBox.Show("Uživatel úspěšně odstraněn", "user delete");
                listUzivateluZr.Items.Remove(listUzivateluZr.SelectedItem);
                zrusUzAkSez();
            }
        }

        private void backUzZr_Click(object sender, EventArgs e)
        {
            zrUzBx.Hide();
            defbx.Show();
        }

        private void confirmAutZal_Click(object sender, EventArgs e)
        {
            string autoID = idTxtBx.Text;
            string autoZnacka = znackaTxtBx.Text;
            string autoModel = modelTxtBx.Text;
            string autoTyp = typVyber.SelectedItem.ToString();
            string autoSpotreba = spotrebaTxtBx.Text;
            string autoInfo = infoTxtBx.Text;
            string autoPath = Environment.CurrentDirectory + "\\Data\\Auta" + "\\" + autoID + ".txt";

            if (File.Exists(autoPath))
            {
                MessageBox.Show("Vozidlo s tímto ID již existuje! Zadejte jiné ID!", "ID error");
                idTxtBx.Text = "";
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(autoPath))
                {
                    sw.WriteLine("ID: " + autoID);
                    sw.WriteLine("znacka: " + autoZnacka);
                    sw.WriteLine("model: " + autoModel);
                    sw.WriteLine("typ: " + autoTyp);
                    sw.WriteLine("spotreba na 100km: " + autoSpotreba);
                    sw.WriteLine("dalsi info: " + autoInfo);

                    sw.Close();
                }
                MessageBox.Show("auto uspesne pridano", "car add");
                zalAut.Hide();
                defbx.Show();
            }
        }

        private void backAutZal_Click(object sender, EventArgs e)
        {
            zalAut.Hide();
            defbx.Show();
        }

        private void confimAutZr_Click(object sender, EventArgs e)
        {

        }

        private void backAutZr_Click(object sender, EventArgs e)
        {
            zruAut.Hide();
            defbx.Show();
        }

        private void confirmHesZm_Click(object sender, EventArgs e)
        {

        }

        private void backHesZr_Click(object sender, EventArgs e)
        {
            zmeHes.Hide();
            defbx.Show();
        }

        private void backAllRez_Click(object sender, EventArgs e)
        {
            allRezer.Hide();
            defbx.Show();
        }

        private void backAllUz_Click(object sender, EventArgs e)
        {
            allUsers.Hide();
            defbx.Show();
        }

        private void backAllAut_Click(object sender, EventArgs e)
        {
            allAuta.Hide();
            defbx.Show();
        }
        #endregion

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            
            login lgn = new login();
            lgn.Show();
            this.Close();
        }

        public void zrusUzAkSez()
        {
            listUzivateluZr.Items.Clear();
            string path = Environment.CurrentDirectory + "\\Data" + "\\Users";
            DirectoryInfo dir = new DirectoryInfo(path);
            DirectoryInfo[] Files = dir.GetDirectories();
            for (int i = 0; i < Files.Length; i++)
            {
                listUzivateluZr.Items.Add((Files[i].Name.Replace(".txt", "")).Replace("_", " "));
            }
        }
        public void allUzAkSez()
        {
            vsichniUzivatele.Items.Clear();
            string path = Environment.CurrentDirectory + "\\Data" + "\\Users";
            DirectoryInfo dir = new DirectoryInfo(path);
            DirectoryInfo[] Files = dir.GetDirectories();
            for (int i = 0; i < Files.Length; i++)
            {
                vsichniUzivatele.Items.Add((Files[i].Name.Replace(".txt", "")).Replace("_", " "));
            }
        }

        public void allAutAkSez()
        {
            allAutList.Items.Clear();
            string path = Environment.CurrentDirectory + "\\Data" + "\\Auta";
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] Files = dir.GetFiles();
            for (int i = 0; i < Files.Length; i++)
            {
                allAutList.Items.Add((Files[i].Name.Replace(".txt", "")).Replace("_", " "));
            }
        }

        public void zrAutAkSez()
        {
            listAutZr.Items.Clear();
            string path = Environment.CurrentDirectory + "\\Data" + "\\Auta";
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] Files = dir.GetFiles();
            for (int i = 0; i < Files.Length; i++)
            {
                listAutZr.Items.Add((Files[i].Name.Replace(".txt", "")).Replace("_", " "));
            }
        }

        private void vsichniUzivatele_SelectedValueChanged(object sender, EventArgs e)
        {
            allUzListInfo.Items.Clear();
            //string selectedRezervace = allUzListInfo.SelectedItem.ToString();
            string path = Environment.CurrentDirectory + "\\Data\\Users";
            string path2 = Environment.CurrentDirectory + "\\Data\\Auta";
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] Files = dir.GetFiles();


            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    allUzListInfo.Items.Add(sr.ReadLine());
                }
                
                
            }
        }
    }
}
