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
    public partial class manage_classroom : Form
    {
        codes.computation data = new codes.computation();
        public manage_classroom()
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        void clear()
        {
            admission_no.Text = "";
            admission_no.Focus();
            classroom1.DataSource = null;
            classroom1.DataSource = data.classrooms_list();
            classroom1.DisplayMember = "classroom";
            classroom2.DataSource = null;
            classroom2.DataSource = data.classrooms_list();
            classroom2.DisplayMember = "classroom";
            
        }

        private void manage_classroom_Load(object sender, EventArgs e)
        {
            try
            {

            
            schoolname.Text = Form1.get_schoolname;
            logo.Image = data.get_logo();
            totalclassroom.Text = data.total_classrooms().ToString();
            classroom1.DataSource = data.classrooms_list();
            classroom1.DisplayMember = "classroom";
            classroom2.DataSource = data.classrooms_list();
            classroom2.DisplayMember = "classroom";        
            dataGridView1.DataSource = data.classrooms_list();
            }

            catch
            {
                MessageBox.Show("Error occured - Please try again");
            }
        }

        private void buttonX17_Click(object sender, EventArgs e)
        {

            try
            {

            
            if (classroom_name.Text == "" || classroom_name.Text == null)
            {
                msg.Text = "Type classroom name into the box";
                msg.BackColor = Color.Tomato;
                msg.Visible = true;
            }
            else
            {
                data.new_classroom( data.cleanInput_normal( classroom_name.Text.ToUpper()));
                if (data.exe == 1)
                {
                    msg.Text = data.msg();
                    msg.BackColor = Color.MediumSeaGreen;
                    msg.Visible = true;
                    classroom1.DataSource = data.classrooms_list();
                    classroom1.DisplayMember = "classroom";
                    classroom2.DataSource = data.classrooms_list();
                    classroom2.DisplayMember = "classroom";    
                    totalclassroom.Text = data.total_classrooms().ToString();
                    dataGridView1.DataSource = data.classrooms_list();
                    classroom_name.Text = "";
                    classroom_name.Focus();
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
                MessageBox.Show("Error occured - Please try again");
            }
        }

        private void buttonX18_Click(object sender, EventArgs e)
        {

            try
            {

            
            if (classroom_name.Text == "" || classroom_name.Text == null)
            {
                msg.Text = "Type classroom name into the box";
                msg.BackColor = Color.Tomato;
                msg.Visible = true;
            }
            else
            {
                data.remove_classroom(data.cleanInput_normal( classroom_name.Text.ToUpper()));
                if (data.exe == 1)
                {
                    msg.Text = data.msg();
                    msg.BackColor = Color.MediumSeaGreen;
                    msg.Visible = true;
                    classroom1.DataSource = data.classrooms_list();
                    classroom1.DisplayMember = "classroom";
                    classroom2.DataSource = data.classrooms_list();
                    classroom2.DisplayMember = "classroom";    
                    totalclassroom.Text = data.total_classrooms().ToString();
                    dataGridView1.DataSource = data.classrooms_list();
                    classroom_name.Text = "";
                    classroom_name.Focus();
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
                MessageBox.Show("Error occured - Please try again");
            }
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

        private void switchButton1_ValueChanged(object sender, EventArgs e)
        {
            if (switchButton1.ValueObject == "N")
            {

                admission_no.Visible = true;
                classroom1.Visible = false;
            }
            else
            {
                
                admission_no.Visible = false;
                classroom1.Visible = true;
            }
        }

        private void buttonX19_Click(object sender, EventArgs e)
        {

            try
            {

            
            if (switchButton1.ValueObject == "N")
            {
                if (admission_no.Text == "")
                {
                    errorbox.Text = "Enter admission number";
                    errorbox.ForeColor = Color.Red;
                    errorbox.BackColor = Color.FromArgb(255, 224, 192);
                    errorbox.SymbolColor = Color.Red;
                    errorbox.Visible = true;
                }
                else if (classroom2.Text=="" || classroom2.SelectedValue== null)
                {
                    errorbox.Text = "Select destination class for promotion/demotion";
                    errorbox.ForeColor = Color.Red;
                    errorbox.BackColor = Color.FromArgb(255, 224, 192);
                    errorbox.SymbolColor = Color.Red;
                    errorbox.Visible = true;
                }
                else
                {

                    DialogResult ask = MessageBox.Show("Are you sure of this operation", "Promotion/Demotion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ask == System.Windows.Forms.DialogResult.Yes)
                    {
                        data.promote_student(admission_no.Text, classroom2.Text);
                        if (data.exe == 1)
                        {
                            errorbox.Text = data.msg();
                            errorbox.ForeColor = Color.Green;
                            errorbox.BackColor = Color.Honeydew;
                            errorbox.SymbolColor = Color.Green;
                            errorbox.Visible = true;
                            clear();
                           
                        }
                        else
                        {
                            errorbox.Text = data.msg();
                            errorbox.ForeColor = Color.Red;
                            errorbox.BackColor = Color.FromArgb(255, 224, 192);
                            errorbox.SymbolColor = Color.Red;
                            errorbox.Visible = true;
                        }
                    }

                }
            }
            else
            {
                if (classroom1.DataSource == null || classroom1.SelectedValue==null || classroom1.Text=="")
                {
                    errorbox.Text = "Select the class of origin you want to promote/demote";
                    errorbox.ForeColor = Color.Red;
                    errorbox.BackColor = Color.FromArgb(255, 224, 192);
                    errorbox.SymbolColor = Color.Red;
                    errorbox.Visible = true;
                }
                else if (classroom2.DataSource == null || classroom2.SelectedValue == null || classroom2.Text == "")
                {
                    errorbox.Text = "Select destination class for promotion/demotion";
                    errorbox.ForeColor = Color.Red;
                    errorbox.BackColor = Color.FromArgb(255, 224, 192);
                    errorbox.SymbolColor = Color.Red;
                    errorbox.Visible = true;
                }
                else
                {
                    DialogResult ask = MessageBox.Show("Are you sure of this operation", "Promotion/Demotion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ask == System.Windows.Forms.DialogResult.Yes)
                    {
                        data.promote_class(classroom1.Text, classroom2.Text);
                        if (data.exe == 1)
                        {
                            errorbox.Text = data.msg();
                            errorbox.ForeColor = Color.Green;
                            errorbox.BackColor = Color.Honeydew;
                            errorbox.SymbolColor = Color.Green;
                            errorbox.Visible = true;
                            clear();
                        }
                        else
                        {
                            errorbox.Text = data.msg();
                            errorbox.ForeColor = Color.Red;
                            errorbox.BackColor = Color.FromArgb(255, 224, 192);
                            errorbox.SymbolColor = Color.Red;
                            errorbox.Visible = true;
                        }
                    }
                }
            }

            }

            catch
            {
                MessageBox.Show("Error occured - Please try again");
            }
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
    }
}
