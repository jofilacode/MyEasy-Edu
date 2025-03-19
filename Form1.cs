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
    public partial class Form1 : Form
    {
        codes.computation data = new codes.computation();
        codes.security freedomcodes = new codes.security();
        public static string get_schoolname ;
        public static Image get_logo;
        public Form1()
        {
            InitializeComponent();
          
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult ask = MessageBox.Show("Are you sure of exiting this application", "Exiting...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(ask== System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
           
            manage_student newfrm = new manage_student();
            newfrm.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                var app_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Windows Files");
                string[] alltext = System.IO.File.ReadAllText(app_path + @"\system_info.txt").Split(',');
                if (freedomcodes.Decrypt(alltext[3].ToString(), "freedom@0991") != "" || freedomcodes.Decrypt(alltext[3].ToString(), "freedom@0991") != null)
                {
                    schoolname.Text = freedomcodes.Decrypt(alltext[1].ToString(), "freedom@0991").ToUpper();
                    school_id.Text = freedomcodes.Decrypt(alltext[3].ToString(), "freedom@0991");

                    displayterm.Text = data.get_session();
                    get_schoolname = schoolname.Text;

                    try
                    {
                        logo.Image = data.get_logo();
                    }
                    catch
                    {

                    }
                }
                else
                {
                    schoolname.Text = "SOFTWARE LICENSED IS NOT VERIFIED AND MAY NOT WORK PROPERLY";
                    school_id.Text = "--------";

                }
            }
            catch
            {
                MessageBox.Show("SOFTWARE HAS BEEN TEMPERED - CONTACT FREEDOMCODES");
                splash_screen newfrm = new splash_screen();
                newfrm.Show();
                this.Hide();
            }
            
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
           
            manage_session newfrm = new manage_session();
            newfrm.Show();
            this.Hide();
        }

        private void buttonX18_Click(object sender, EventArgs e)
        {
           
            Form1 newfrm = new Form1();
            newfrm.Show();
            this.Hide();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            

               
                login newfrm = new login();
                newfrm.Show();
                this.Hide();
            
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
           
            manage_classroom newfrm = new manage_classroom();
            newfrm.Show();
            this.Hide();
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            
            manage_subject newfrm = new manage_subject();
            newfrm.Show();
            this.Hide();
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
          
            compute_result newfrm = new compute_result();
            newfrm.Show();
            this.Hide();
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
           
            view_Performance newfrm = new view_Performance();
            newfrm.Show();
            this.Hide();
        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
           
            print_offline newfrm = new print_offline();
            newfrm.Show();
            this.Hide();
        }

        private void buttonX15_Click(object sender, EventArgs e)
        {
           
            back_up newfrm = new back_up();
            newfrm.Show();
            this.Hide();
        }

        private void buttonX16_Click(object sender, EventArgs e)
        {

        }

        private void buttonX9_Click(object sender, EventArgs e)
        {
            cummulative newfrm = new cummulative();
            newfrm.Show();
            this.Hide();
        }
    }
}
