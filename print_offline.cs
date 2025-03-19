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
    public partial class print_offline : Form
    {
        public static string search_adm_no;
        codes.computation data = new codes.computation();
        codes.bio_data_api data2 = new codes.bio_data_api();
        public print_offline()
        {
            InitializeComponent();
        }

        private void buttonX18_Click(object sender, EventArgs e)
        {
            ;
            Form1 newfrm = new Form1();
            newfrm.Show(); this.Hide();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            ;
            login newfrm = new login();
            newfrm.Show(); this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult ask = MessageBox.Show("Are you sure of exiting this application", "Exiting...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ask == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            ;
            manage_session newfrm = new manage_session();
            newfrm.Show(); this.Hide();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            ;
            manage_classroom newfrm = new manage_classroom();
            newfrm.Show(); this.Hide();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            ;
            manage_student newfrm = new manage_student();
            newfrm.Show(); this.Hide();
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            ;
            manage_subject newfrm = new manage_subject();
            newfrm.Show(); this.Hide();
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            ;
            compute_result newfrm = new compute_result();
            newfrm.Show(); this.Hide();
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            ;
            view_Performance newfrm = new view_Performance();
            newfrm.Show(); this.Hide();
        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
            ;
            print_offline newfrm = new print_offline();
            newfrm.Show(); this.Hide();
        }

        private void buttonX15_Click(object sender, EventArgs e)
        {
            ;
            back_up newfrm = new back_up();
            newfrm.Show(); this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            if(admno.Text=="")
            {
                errmsg.Text = "Enter Admission Number";
                errmsg.ForeColor = Color.Red;
                errmsg.BackColor = Color.FromArgb(255, 224, 192);
                errmsg.SymbolColor = Color.Red;
                errmsg.Visible = true;
            }
            else
            {
                search_adm_no = admno.Text;
                data2.search_bio(search_adm_no);
               if(data2.g_fullname!="")
               {
                result newfrm = new result();
                newfrm.ShowDialog();
               }
                else
               {
                   MessageBox.Show("No record for admission number: " + search_adm_no);
               }

            }
        }

        private void print_offline_Load(object sender, EventArgs e)
        {
            try
            {

            
            schoolname.Text = Form1.get_schoolname;
            logo.Image = data.get_logo();

            }

            catch
            {
                MessageBox.Show("Error occured - Please try again");
            }
        }
    }
}
