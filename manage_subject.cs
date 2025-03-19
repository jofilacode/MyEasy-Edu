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
    public partial class manage_subject : Form
    {
        codes.computation data = new codes.computation();
        public manage_subject()
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

        private void buttonX17_Click(object sender, EventArgs e)
        {
            try
            {
                if (subjectName.Text == "")
                {
                    msg.Text = "Enter Subject Name";
                    msg.Text = data.msg();
                    msg.BackColor = Color.Tomato;
                    msg.Visible = true;
                }
                else
                {
                    data.create_subject(data.cleanInput(subjectName.Text));
                    if (data.exe == 1)
                    {
                        msg.Text = data.msg();
                        msg.BackColor = Color.Green;
                        msg.Visible = true;
                        subjectName.Text = "";
                        subjectName.Focus();
                        totalsubject.Text = data.get_no_subject().ToString();
                        dataGridView1.DataSource = data.view_subjects_list();

                    }
                    else
                    {
                        msg.Text = data.msg();
                        msg.BackColor = Color.Red;
                        msg.Visible = true;
                    }
                }


            }
            catch (Exception ex)
            {
                msg.Text = "Error: " + ex.Message.Replace("tbl_", "");
                msg.BackColor = Color.Tomato;
                msg.Visible = true;
                msg.Visible = true;
            }
        }

        private void manage_subject_Load(object sender, EventArgs e)
        {

            try
            { 
            schoolname.Text = Form1.get_schoolname;
            logo.Image = data.get_logo();
            dataGridView1.DataSource = data.view_subjects_list();
            totalsubject.Text = data.get_no_subject().ToString();

            teacher_data.DataSource = data.view_teachers_comment();
            principal_data.DataSource = data.view_principal_comment();

            }

            catch
            {
                MessageBox.Show("Error occured - Please try again");
            }
        }

        private void buttonX18_Click(object sender, EventArgs e)
        {
            try
            {

                if (subjectName.Text == "")
                {
                    msg.Text = "Enter Subject Name";
                    msg.BackColor = Color.Tomato;
                    msg.Visible = true;
                }
                else
                {
                    DialogResult ask = MessageBox.Show("Are you sure of removing " + subjectName.Text + " from list of subjects","Removing...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ask == System.Windows.Forms.DialogResult.Yes)
                    {
                        data.remove_subjects_list(subjectName.Text);
                        if (data.exe == 1)
                        {

                            msg.Text = data.msg();
                            msg.BackColor = Color.Green;
                            msg.Visible = true;
                            subjectName.Text = "";
                            subjectName.Focus();
                            totalsubject.Text = data.get_no_subject().ToString();
                            dataGridView1.DataSource = data.view_subjects_list();
                        }
                        else
                        {
                            msg.Text = data.msg();
                            msg.BackColor = Color.Red;
                            msg.Visible = true;
                        }
                        
                    }
                }
            }
             catch(Exception)
            {
                MessageBox.Show("Error occured - try again");
            }
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

        private void buttonX13_Click(object sender, EventArgs e)
        {
            try
            {
                if (teacher_comment.Text == "")
                {
                    msg.Text = "Enter Teacher Comment";
                    msg.Text = data.msg();
                    msg.BackColor = Color.Tomato;
                    msg.Visible = true;
                }
                else
                {
                    data.add_teachers_comment(teacher_comment.Text);
                    if (data.exe == 1)
                    {
                        msg.Text = data.msg();
                        msg.BackColor = Color.Green;
                        msg.Visible = true;
                        teacher_comment.Text = "";
                        teacher_comment.Focus();

                        teacher_data.DataSource = data.view_teachers_comment();

                    }
                    else
                    {
                        msg.Text = data.msg();
                        msg.BackColor = Color.Red;
                        msg.Visible = true;
                    }
                }


            }
            catch (Exception ex)
            {
                msg.Text = "Error: " + ex.Message;
                msg.BackColor = Color.Tomato;
                msg.Visible = true;
                msg.Visible = true;
            }
        }

        private void buttonX19_Click(object sender, EventArgs e)
        {
            try
            {
                if (principal_comment.Text == "")
                {
                    msg.Text = "Enter Principal Comment";
                    msg.Text = data.msg();
                    msg.BackColor = Color.Tomato;
                    msg.Visible = true;
                }
                else
                {
                    data.add_principal_comment(principal_comment.Text);
                    if (data.exe == 1)
                    {
                        msg.Text = data.msg();
                        msg.BackColor = Color.Green;
                        msg.Visible = true;
                        principal_comment.Text = "";
                        principal_comment.Focus();

                        principal_data.DataSource = data.view_principal_comment();

                    }
                    else
                    {
                        msg.Text = data.msg();
                        msg.BackColor = Color.Red;
                        msg.Visible = true;
                    }
                }


            }
            catch (Exception ex)
            {
                msg.Text = "Error: " + ex.Message;
                msg.BackColor = Color.Tomato;
                msg.Visible = true;
                msg.Visible = true;
            }
        }

        private void buttonX9_Click(object sender, EventArgs e)
        {
            try
            {

                if (teacher_comment.Text == "")
                {
                    msg.Text = "Enter Teacher's Comment";
                    msg.BackColor = Color.Tomato;
                    msg.Visible = true;
                }
                else
                {
                    DialogResult ask = MessageBox.Show("Are you sure of removing " + teacher_comment.Text + " from list of comments", "Removing...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ask == System.Windows.Forms.DialogResult.Yes)
                    {
                        data.remove_teachers_comment(teacher_comment.Text);
                        if (data.exe == 1)
                        {

                            msg.Text = data.msg();
                            msg.BackColor = Color.Green;
                            msg.Visible = true;
                            teacher_comment.Text = "";
                            teacher_comment.Focus();

                            teacher_data.DataSource = data.view_teachers_comment();
                        }
                        else
                        {
                            msg.Text = data.msg();
                            msg.BackColor = Color.Red;
                            msg.Visible = true;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured " + ex.Message);
            }
        }

        private void buttonX14_Click(object sender, EventArgs e)
        {
            try
            {

                if (principal_comment.Text == "")
                {
                    msg.Text = "Enter Principal's Comment";
                    msg.BackColor = Color.Tomato;
                    msg.Visible = true;
                }
                else
                {
                    DialogResult ask = MessageBox.Show("Are you sure of removing " + principal_comment.Text + " from list of comments", "Removing...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ask == System.Windows.Forms.DialogResult.Yes)
                    {
                        data.remove_principal_comment(principal_comment.Text);
                        if (data.exe == 1)
                        {

                            msg.Text = data.msg();
                            msg.BackColor = Color.Green;
                            msg.Visible = true;
                            principal_comment.Text = "";
                            principal_comment.Focus();

                            principal_data.DataSource = data.view_principal_comment();
                        }
                        else
                        {
                            msg.Text = data.msg();
                            msg.BackColor = Color.Red;
                            msg.Visible = true;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured " + ex.Message);
            }
        }
    }
        
}
