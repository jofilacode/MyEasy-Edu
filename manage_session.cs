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
    public partial class manage_session : Form
    {
        codes.computation data = new codes.computation();
       
        
        public manage_session()
        {
            InitializeComponent();
           

        }

        private void buttonX16_Click(object sender, EventArgs e)
        {
            
            Form1 newfrm = new Form1();
            newfrm.Show(); this.Hide();
            
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            

                
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
            
            manage_session newfrm = new manage_session();
            newfrm.Show(); this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {

            
            int k;
            if(sessionbox.Text=="" || sessionbox.SelectedIndex== -1)
            {
                msg.Text = "No term selected yet - Please select a term to make current-session term";
                msg.BackColor = Color.Tomato;
                msg.Visible = true;
            }
            else if (academic_weeks.Text =="")
            {
                msg.Text = "Please specify academic weeks for the term";
                msg.BackColor = Color.Tomato;
                msg.Visible = true;
            }
            else if (int.TryParse(academic_weeks.Text, out k) == false)
            {
                msg.Text = "Academic weeks should be numeric e.g 13";
                msg.BackColor = Color.Tomato;
                msg.Visible = true;
            }
            else
            {
                data.set_session(sessionbox.Text + " " + DateTime.Now.Year, academic_weeks.Text );
                if(data.exe==1)
                {
                    msg.Text = data.msg();
                    msg.BackColor = Color.MediumSeaGreen;
                    msg.Visible = true;
                    sessionbox.SelectedIndex = -1;
                    data.get_session(true);
                    display_session.Text = data.current_session_term;
                    display_academic_weeks.Text = data.current_academic_weeks;
                }
                else
                {
                    msg.Text = data.msg();
                    msg.BackColor = Color.Tomato;
                    msg.Visible = true;
                }
            }
            }

            catch
            {
                MessageBox.Show("Error occured - Please try again" );
            }
        }

        private void manage_session_Load(object sender, EventArgs e)
        {

            try
            {
                schoolname.Text = Form1.get_schoolname;
                logo.Image = data.get_logo();
                data.get_session(true);
                display_session.Text = data.current_session_term;
                display_academic_weeks.Text = data.current_academic_weeks;
            }

            catch
            {
                MessageBox.Show("Error occured - Please try again");
            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {

            
            manage_student newfrm = new manage_student();
            newfrm.Show(); this.Hide();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            
            manage_classroom newfrm = new manage_classroom();
            newfrm.Show(); this.Hide();
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            
            manage_subject newfrm = new manage_subject();
            newfrm.Show(); this.Hide();
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            
            compute_result newfrm = new compute_result();
            newfrm.Show(); this.Hide();
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            
            view_Performance newfrm = new view_Performance();
            newfrm.Show(); this.Hide();
        }

      
        private void buttonX8_Click(object sender, EventArgs e)
        {
            
            print_offline newfrm = new print_offline();
            newfrm.Show(); this.Hide();
        }

        private void buttonX15_Click(object sender, EventArgs e)
        {
            
            back_up newfrm = new back_up();
            newfrm.Show(); this.Hide();
        }

        private void passport_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog img = new OpenFileDialog();
                img.Filter = "Image files (*.jpg,.jpeg,.*jpe,*.png) | *.jpg; *.jpe; *.png";
                if (img.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    System.IO.FileInfo fi = new System.IO.FileInfo(img.FileName);
                    long filesize = fi.Length;
                    if (filesize > 400000)
                    {
                        msg.Text = "Image size too large for passport (Recommended : less than or equal to 400kb)";
                        msg.BackColor = Color.Tomato;
                        msg.Visible = true;
                    }
                    else
                    {

                        logobox.Image = Image.FromFile(img.FileName);
                        msg.Text = "Passport upload was successful";
                        msg.BackColor = Color.MediumSeaGreen;
                        msg.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if(logobox.Image==null)
                {
                    MessageBox.Show("Please click imagebox to upload picture");
                }
                else
                {
                    data.update_logo(logobox.Image);
                    MessageBox.Show(data.msg());
                    logo.Image = data.get_logo();
                    logobox.Image = null;
                }
            }
            catch
            {
                MessageBox.Show("Error Occured - Please try again");
            }
        }
    }
}
