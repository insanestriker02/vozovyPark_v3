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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            label5.Hide();
            
            

        }

        private void logBtn_Click(object sender, EventArgs e)
        {
            string jmeno = jmTxtBx.Text;
            string prijmeni = prijTxtBx.Text;
            string heslo = hesTxtBx.Text;
            SHA256 sha256 = SHA256.Create();
            byte[] hesloHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(heslo));
            string path = Environment.CurrentDirectory + "\\Data" + "\\Users";
            string userData = jmeno.ToLower() + "_" + prijmeni.ToLower();
            string userPath = path + "\\" + userData;
            Regex rxHeslo = new Regex(@"(?<=heslo: )\S+");
            //string check = userPath + "\\" + userData + ".txt";
            string lastLog;
            Regex rxLastLog = new Regex(@"(?<=lastlog: )\S+");

            if (Directory.Exists(userPath))
            {
                using (StreamReader sr = new StreamReader(userPath + "\\" + userData + ".txt"))
                {
                    string line;
                    bool ověřeno = false;
                    if (jmeno == "admin" && prijmeni == "admin")
                    {
                        while ((line = sr.ReadLine()) != null)
                        {

                            if (rxLastLog.IsMatch(line))
                            {
                                lastLog = line;
                                label5.Text = line;
                            }
                            if (rxHeslo.IsMatch(line))
                            {
                                if (rxHeslo.Match(line).ToString() == BitConverter.ToString(hesloHash).ToLower().Replace("-", ""))
                                {
                                    ověřeno = true;
                                }
                                else
                                {
                                    MessageBox.Show("zadali jste špatné heslo", "Wrong password");
                                    hesTxtBx.Text = "";
                                }
                            }
                        }

                        if (ověřeno == true)
                        {
                            lastLog = label5.Text;
                            adminRozhrani ar = new adminRozhrani(jmeno, prijmeni, lastLog);
                            ar.Show();
                            this.Hide();
                            sr.Close();
                            PrepisSouboruLastLog();
                        }
                    } //admin
                    else
                    {
                        while ((line = sr.ReadLine()) != null)
                        {

                            if (rxLastLog.IsMatch(line))
                            {
                                lastLog = line;
                                label5.Text = line;
                            }
                            if (rxHeslo.IsMatch(line))
                            {
                                if (rxHeslo.Match(line).ToString() == BitConverter.ToString(hesloHash).ToLower().Replace("-", ""))
                                {
                                    ověřeno = true;
                                }
                                else
                                {
                                    MessageBox.Show("zadali jste špatné heslo", "Wrong password");
                                    hesTxtBx.Text = "";
                                    hesTxtBx.Focus();
                                }
                            }
                        }

                        if (ověřeno == true)
                        {
                            lastLog = label5.Text;
                            uzivRozhrani ur = new uzivRozhrani(jmeno, prijmeni, lastLog);
                            ur.Show();
                            this.Hide();
                            sr.Close();
                            PrepisSouboruLastLog();
                        }
                        //while ((line = sr.ReadLine()) != null)
                        //{
                        //    if (rxHeslo.IsMatch(line))
                        //    {
                        //        if (rxHeslo.Match(line).ToString() == BitConverter.ToString(hesloHash).ToLower().Replace("-", ""))
                        //        {
                        //            uzivRozhrani ur = new uzivRozhrani(jmeno, prijmeni);
                        //            ur.Show();
                        //            this.Hide();
                        //        }
                        //        else
                        //        {
                        //            MessageBox.Show("zadali jste špatné heslo", "Wrong password");

                        //        }
                        //    }
                        //}
                    }//user
                }
            }
            else
            {
                MessageBox.Show("Uživatel neexistuje! Požádejte o založení uživatele", "No user");
                jmTxtBx.Text = "";
                prijTxtBx.Text = "";
                hesTxtBx.Text = "";
            }


        }

        public void PrepisSouboruLastLog()
        {
            string jmeno = jmTxtBx.Text;
            string prijmeni = prijTxtBx.Text;
            string heslo = hesTxtBx.Text;
            SHA256 sha256 = SHA256.Create();
            byte[] hesloHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(heslo));
            string path = Environment.CurrentDirectory + "\\Data" + "\\Users";
            string userData = jmeno.ToLower() + "_" + prijmeni.ToLower();
            string userPath = path + "\\" + userData;
            string[] prvniSoubor = File.ReadAllLines(userPath + "\\" + userData + ".txt");
            string tempFile = userPath + "\\" + "temp.txt";
            Regex rxLastLog = new Regex(@"(?<=lastlog: )\S+");
            using(StreamWriter sw = new StreamWriter(tempFile))
            {
                for (int i = 0; i < prvniSoubor.Length; i++)
                {
                    if (rxLastLog.IsMatch(prvniSoubor[i]))
                    {
                        sw.WriteLine("lastlog: " + DateTime.Now);
                        continue;
                    }
                    sw.WriteLine(prvniSoubor[i]);
                }
                sw.Close();
            }
            File.Delete(userPath + "\\" + userData + ".txt");

            File.Move(tempFile, userPath + "\\" + userData + ".txt");
        }
    }
}
