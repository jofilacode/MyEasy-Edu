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
    public partial class login : Form
    {
        codes.security data = new codes.security();
        public login()
        {
            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult ask = MessageBox.Show("Are you sure you want to exit this application....", "Exiting.....", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ask == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {
                var app_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Windows Files");
                if (username.Text == "" || password.Text == "")
                {
                    MessageBox.Show("Specify your username and password");
                }
                else
                {

                    string[] alltext = System.IO.File.ReadAllText(app_path + @"\system_info.txt").Split(',');
                    if (data.Decrypt(alltext[3].ToString(), "freedom@0991") != "" || data.Decrypt(alltext.ToString(), "freedom@0991") != null)
                    {
                        if (username.Text == data.Decrypt(alltext[4].ToString(), "freedom@0991") && password.Text == data.Decrypt(alltext[5].ToString(), "freedom@0991"))
                        {
                           
                            Form1 frm = new Form1();
                            frm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Userword/Password - Please verify");
                        }
                    }
                    else
                    {
                        MessageBox.Show("CANNOT lOGIN - SOFTWARE HAS NOT BEEN VERIFIED ");
                    }




                }
            }
            catch
            {
                MessageBox.Show("SOFTWARE HAS BEEN TEMPERED/NOT REGISTERED - CONTACT FREEDOMCODES");
                var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Windows Files");
                if (Directory.Exists(folder))
                {
                    System.IO.Directory.Delete(folder, true);
                }
                activate_mee newfrm = new activate_mee();
                this.Hide();
                newfrm.Show();
            }
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
