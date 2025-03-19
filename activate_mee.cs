using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Easy_Edu_V_1._0
{
    public partial class activate_mee : Form
    {
        codes.security data = new codes.security();
        private Random rnd, rnd2;
        private string random_ID, new_mod_password;
        public activate_mee()
        {
            InitializeComponent();
        }

        public string generate_ID()
        {
            rnd = new Random();
            rnd2 = new Random();
            int value = rnd.Next(0, 999);
            int value2 = rnd2.Next(1000, 9999);
            random_ID = value.ToString() + value2.ToString();
            return random_ID;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            DialogResult ask = MessageBox.Show("Are you sure you want to exit this application....", "Exiting.....", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ask == System.Windows.Forms.DialogResult.Yes)
            {
                var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Windows Files");
                System.IO.Directory.Delete(folder, true);
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (schoolname.Text == "" || pin.Text == "" || schoolid.Text == "" || username.Text == "" || password.Text == "" || confirmpassword.Text == "")
                {
                    errorbox.Text = "All fields are required!";
                    errorbox.ForeColor = Color.Red;
                    errorbox.BackColor = Color.FromArgb(255, 224, 192);
                    errorbox.SymbolColor = Color.Red;
                    errorbox.Visible = true;
                }
                else if (username.Text.Length < 5)
                {
                    errorbox.Text = "Username is too short (5 Characters minimum)";
                    errorbox.ForeColor = Color.Red;
                    errorbox.BackColor = Color.FromArgb(255, 224, 192);
                    errorbox.SymbolColor = Color.Red;
                    errorbox.Visible = true;
                }
                else if (password.Text.Length < 5)
                {
                    errorbox.Text = "password is too short (5 Characters minimum)";
                    errorbox.ForeColor = Color.Red;
                    errorbox.BackColor = Color.FromArgb(255, 224, 192);
                    errorbox.SymbolColor = Color.Red;
                    errorbox.Visible = true;
                }
                else if (confirmpassword.Text != password.Text)
                {
                    errorbox.Text = "Password does not match";
                    errorbox.ForeColor = Color.Red;
                    errorbox.BackColor = Color.FromArgb(255, 224, 192);
                    errorbox.SymbolColor = Color.Red;
                    errorbox.Visible = true;
                }
                else if (pin.Text != mod_password(schoolid.Text))
                {
                    errorbox.Text = "Activation pin is not verified/invalid";
                    errorbox.ForeColor = Color.Red;
                    errorbox.BackColor = Color.FromArgb(255, 224, 192);
                    errorbox.SymbolColor = Color.Red;
                    errorbox.Visible = true;
                }
                else
                {
                    activate_complete();
                    timer1.Enabled = true;
                    timer1.Start();
                    errorbox.Text = "Activation was successful you will be automatically redirected to login page...";
                    errorbox.ForeColor = Color.Green;
                    errorbox.BackColor = Color.Honeydew;
                    errorbox.SymbolColor = Color.Green;
                    errorbox.Visible = true;
                }
            }

            catch
            {
                MessageBox.Show("SOFTWARE HAS BEEN TEMPERED - CONTACT FREEDOMCODES");
            }
        }

        void activate_complete()
        {
            var app_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Windows Files");
            if (!System.IO.File.Exists(app_path))
            {
                System.IO.Directory.CreateDirectory(app_path);
                System.IO.File.Create(app_path + @"\system_info.txt").Close();
                System.IO.File.WriteAllText(app_path + @"\system_info.txt", data.Encrypt(generate_ID().ToString(), "freedom@0991") + "," + data.Encrypt(schoolname.Text, "freedom@0991") + "," + pin.Text + "," + data.Encrypt(schoolid.Text, "freedom@0991") + "," + data.Encrypt(username.Text, "freedom@0991") + "," + data.Encrypt(password.Text, "freedom@0991") + "," + data.Encrypt("true", "freedom@0991") + "," + data.Encrypt(DateTime.Now.ToShortDateString(), "freedom@0991"));
            }
            else
            {
                System.IO.File.WriteAllText(app_path + @"\system_info.txt", data.Encrypt(generate_ID().ToString(), "freedom@0991") + "," + data.Encrypt(schoolname.Text, "freedom@0991") + "," + pin.Text + "," + data.Encrypt(schoolid.Text, "freedom@0991") + "," + data.Encrypt(username.Text, "freedom@0991") + "," + data.Encrypt(password.Text, "freedom@0991") + "," + data.Encrypt("true", "freedom@0991") + "," + data.Encrypt(DateTime.Now.ToShortDateString(), "freedom@0991"));
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            countdown.Visible = true;
            int value = int.Parse(countdown.Text);
            value -= 1;
            countdown.Text = value.ToString();
            if (value == 0)
            {
                timer1.Enabled = false;
                timer1.Stop();
                login newfrm = new login();
                this.Hide();
                newfrm.Show();
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (schoolid.Text == null || schoolid.Text == "")
            {
                MessageBox.Show("Cannot copy empty text");
            }
            else
            {
                Clipboard.SetText(schoolid.Text.Replace("MEE-", ""));
                MessageBox.Show("Copied successfully!");
            }
        }

        public string mod_password(string id)
        {
            new_mod_password = id.Replace("MEE-", "");
            string numb = new_mod_password.Substring(new_mod_password.Length - 2, 2);
            double parsenum1 = double.Parse(numb) * 137;
            double parsenum2 = double.Parse(numb) * 731;
            double ver_id = double.Parse(new_mod_password);
            double new_id = (ver_id + parsenum2) - (ver_id + parsenum1);
            new_mod_password = new_id.ToString() + "-" + (double.Parse(new_mod_password) - new_id).ToString().Substring(0, 4) + "-" + (double.Parse(new_mod_password) + new_id).ToString().Substring(0, 4);
            return new_mod_password;
        }

        private void activate_mee_Load(object sender, EventArgs e)
        {
            try
            {

                string gen_id = "MEE-" + generate_ID().ToString();
                var app_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Windows Files");
                if (!File.Exists(app_path + @"\system_info.txt"))
                {
                    Directory.CreateDirectory(app_path);
                    System.IO.File.Create(app_path + @"\system_info.txt").Close();
                    File.WriteAllText(app_path + @"\system_info.txt", data.Encrypt(gen_id, "freedom@0991"));
                    string[] alltext = System.IO.File.ReadAllText(app_path + @"\system_info.txt").Split(',');
                    schoolid.Text = data.Decrypt(alltext[0].ToString(), "freedom@0991");

                }
                else
                {
                    login newfrm = new login();
                    this.Hide();
                    newfrm.Show();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("SOFTWARE HAS BEEN TEMPERED - CONTACT FREEDOMCODES");
                //MessageBox.Show(ex.Message);
            }
        }
    }
}
