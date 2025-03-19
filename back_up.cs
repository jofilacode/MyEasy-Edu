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
    public partial class back_up : Form
    {
        codes.computation data = new codes.computation();
        string fullpathname;
        public back_up()
        {
            InitializeComponent();
        }

        private void buttonX18_Click(object sender, EventArgs e)
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

        private void buttonX4_Click(object sender, EventArgs e)
        {
            
            manage_classroom newfrm = new manage_classroom();
            newfrm.Show(); this.Hide();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            
            manage_student newfrm = new manage_student();
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

      
        private void buttonX15_Click(object sender, EventArgs e)
        {
            
            back_up newfrm = new back_up();
            newfrm.Show(); this.Hide();
        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
            
            print_offline newfrm = new print_offline();
            newfrm.Show(); this.Hide();
        }

       

        private void switchButton1_ValueChanged(object sender, EventArgs e)
        {
            if (switchButton1.ValueObject  == "N")
            {
                backup.Visible = false;
                restore.Visible = true;
                restorepath.Text = "";
                backuppath.Text = "";
                errorbox.Text = "Restore mode activated...";
                errorbox.ForeColor = Color.Green;
                errorbox.BackColor = Color.Honeydew;
                errorbox.SymbolColor = Color.Green;
                errorbox.Visible = true;   
            }
            else
            {

                backup.Visible = true;
                restore.Visible = false;
                restorepath.Text = "";
                backuppath.Text = "";
                errorbox.Text = "Back-Up mode activated...";
                errorbox.ForeColor = Color.Green;
                errorbox.BackColor = Color.Honeydew;
                errorbox.SymbolColor = Color.Green;
                errorbox.Visible = true;



                         

            }
        }

       

        private void buttonX19_Click(object sender, EventArgs e)
        {
            try
            { 
            openFileDialog1.Filter = "Database files|*.mdb";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                restorepath.Text = openFileDialog1.SafeFileName;
                fullpathname = openFileDialog1.FileName;
            }
            }

            catch
            {
                MessageBox.Show("Error occured - Please try again");
            }
        }

        private void buttonX20_Click(object sender, EventArgs e)
        {
            try
            {

            
            if (restorepath.Text == "")
            {
                errorbox.Text = "You have not selected the path to restore database - Click browse and select path";
                errorbox.ForeColor = Color.Red;
                errorbox.BackColor = Color.FromArgb(255, 224, 192);
                errorbox.SymbolColor = Color.Red;
                errorbox.Visible = true;
            }
            else
            {

                DialogResult ask = MessageBox.Show("Are you sure of this operation", "Restoring...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ask == System.Windows.Forms.DialogResult.Yes)
                {
                    System.IO.File.Copy(fullpathname, Application.StartupPath + @"\" + restorepath.Text, true);
                    errorbox.Text = "You database has been restored successfully...";
                    errorbox.ForeColor = Color.Green;
                    errorbox.BackColor = Color.Honeydew;
                    errorbox.SymbolColor = Color.Green;
                    errorbox.Visible = true;
                    restorepath.Text = "";
                    fullpathname = "";
                }
                else
                {
                    errorbox.Text = "No action was taken";
                    errorbox.ForeColor = Color.Red;
                    errorbox.BackColor = Color.FromArgb(255, 224, 192);
                    errorbox.SymbolColor = Color.Red;
                    errorbox.Visible = true;
                }

            }
            }

            catch
            {
                MessageBox.Show("Error occured - Please try again");
            }
         }

        private void buttonX16_Click_1(object sender, EventArgs e)
        {
            try
            { 
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                backuppath.Text = folderBrowserDialog1.SelectedPath;
            }
            }

            catch
            {
                MessageBox.Show("Error occured - Please try again");
            }
        }

        private void buttonX17_Click_1(object sender, EventArgs e)
        {
            try
            {

                if (backuppath.Text == "")
                {
                    errorbox.Text = "You have not selected the path to back up database - Click browse and select path";
                    errorbox.ForeColor = Color.Red;
                    errorbox.BackColor = Color.FromArgb(255, 224, 192);
                    errorbox.SymbolColor = Color.Red;
                    errorbox.Visible = true;
                }
                else
                {


                     DialogResult askme = MessageBox.Show("Are you sure of this operation", "Restoring...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                     if (askme == System.Windows.Forms.DialogResult.Yes)
                     {

                         if (System.IO.File.Exists(backuppath.Text + @"\sars_db.mdb"))
                         {
                             DialogResult ask = MessageBox.Show("Seems Back-up exist in the selected path - would you like to overwrite the file", "Backup-Exist...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                             if (ask == System.Windows.Forms.DialogResult.Yes)
                             {
                                 System.IO.File.Copy(Application.StartupPath + @"\sars_db.mdb", backuppath.Text + @"\sars_db.mdb", true);
                                 errorbox.Text = "You database has been back-up successfully...";
                                 errorbox.ForeColor = Color.Green;
                                 errorbox.BackColor = Color.Honeydew;
                                 errorbox.SymbolColor = Color.Green;
                                 errorbox.Visible = true;
                             }
                             else
                             {
                                 errorbox.Text = "No action was taken";
                                 errorbox.ForeColor = Color.Red;
                                 errorbox.BackColor = Color.FromArgb(255, 224, 192);
                                 errorbox.SymbolColor = Color.Red;
                                 errorbox.Visible = true;
                             }
                         }
                         else
                         {

                             System.IO.File.Copy(Application.StartupPath + @"\sars_db.mdb", backuppath.Text + @"\sars_db.mdb", true);
                             errorbox.Text = "You database has been back up successfully...";
                             errorbox.ForeColor = Color.Green;
                             errorbox.BackColor = Color.Honeydew;
                             errorbox.SymbolColor = Color.Green;
                             errorbox.Visible = true;
                             backuppath.Text = "";
                         }
                     }
                    else
                     {
                         errorbox.Text = "No action was taken";
                         errorbox.ForeColor = Color.Red;
                         errorbox.BackColor = Color.FromArgb(255, 224, 192);
                         errorbox.SymbolColor = Color.Red;
                         errorbox.Visible = true;
                     }




                }
            }
            catch
            {
                errorbox.Text = "Error: something went wrong... please try again ";
                errorbox.ForeColor = Color.Red;
                errorbox.BackColor = Color.FromArgb(255, 224, 192);
                errorbox.SymbolColor = Color.Red;
                errorbox.Visible = true;
            }



        }

        private void back_up_Load(object sender, EventArgs e)
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
