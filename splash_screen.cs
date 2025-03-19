using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Easy_Edu_V_1._0
{
    public partial class splash_screen : Form
    {
        codes.security data = new codes.security();
        public splash_screen()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                progressbar.Value += 1;
                progressbar2.Value += 1;
                if (progressbar.Value == 100)
                {
                    timer1.Enabled = false;
                    timer1.Stop();
                    login newfrm = new login();
                    this.Hide();
                    newfrm.Show();
                }


            }
            catch
            {
                MessageBox.Show("SOFTWARE HAS BEEN TEMPERED - CONTACT FREEDOMCODES");
                MessageBox.Show("APPLICATION WILL EXIT NOW...");
                Application.Exit();
            }
        }

        private void splash_screen_Load(object sender, EventArgs e)
        {

        }
    }
}
