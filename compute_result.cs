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
    public partial class compute_result : Form
    {
        codes.computation data = new codes.computation();
        codes.bio_data_api data2 = new codes.bio_data_api();
        string new_term;
        public compute_result()
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

        private void buttonX6_Click(object sender, EventArgs e)
        {
            
            compute_result newfrm = new compute_result();
            newfrm.Show(); this.Hide();
        }

        private void compute_result_Load(object sender, EventArgs e)
        {
             try
            {

            
            schoolname.Text = Form1.get_schoolname;
            logo.Image = data.get_logo();

            subjects.DataSource = data.view_subjects_list();
            subjects.DisplayMember = "subjects";

            studclass.DataSource = data.classrooms_list();
            studclass.DisplayMember = "classroom";

            displaysubject_name.Text = subjects.Text;

            teacher_data.DataSource = data.view_teachers_comment();
            teacher_data.DisplayMember = "comments";

            
            

            errorbox.Visible = false;
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

                if (student_admno_list.Text == "")
                {
                    errorbox.Text = "Specify admission number";
                    errorbox.ForeColor = Color.Red;
                    errorbox.BackColor = Color.FromArgb(255, 224, 192);
                    errorbox.SymbolColor = Color.Red;
                    errorbox.Visible = true;
                }
                else if (new_term == "")
                {
                    errorbox.Text = "Select term";
                    errorbox.ForeColor = Color.Red;
                    errorbox.BackColor = Color.FromArgb(255, 224, 192);
                    errorbox.SymbolColor = Color.Red;
                    errorbox.Visible = true;
                }
                else if (studclass.Text == "" || studclass.Visible == false)
                {
                    errorbox.Text = "No class - Please verify students/pupils";
                    errorbox.ForeColor = Color.Red;
                    errorbox.BackColor = Color.FromArgb(255, 224, 192);
                    errorbox.SymbolColor = Color.Red;
                    errorbox.Visible = true;
                }
                else if (ca1.Text == "")
                {
                    errorbox.Text = "No Computation has been made (Atleast CA1)";
                    errorbox.ForeColor = Color.Red;
                    errorbox.BackColor = Color.FromArgb(255, 224, 192);
                    errorbox.SymbolColor = Color.Red;
                    errorbox.Visible = true;
                }

                else if (double.Parse(total.Text) > 100)
                {
                    errorbox.Text = "Cummulative Total score cannot be greater than 100";
                    errorbox.ForeColor = Color.Red;
                    errorbox.BackColor = Color.FromArgb(255, 224, 192);
                    errorbox.SymbolColor = Color.Red;
                    errorbox.Visible = true;
                }
                else
                {
                    data.save_update_computation(student_admno_list.Text, studclass.Text, subjects.Text, ca1.Text, ca2.Text, ca3.Text, exam.Text, total.Text, data.get_grade(total.Text), teacher_data.Text, new_term);
                                    
                    if (data.exe == 1)
                    {
                       
                        errorbox.Text = data.msg();
                        errorbox.ForeColor = Color.Green;
                        errorbox.BackColor = Color.Honeydew;
                        errorbox.SymbolColor = Color.Green;

                        

                        errorbox.Visible = true;
                        teachers_remark.DataSource = data.view_assessment_class_term(subjects.Text, studclass.Text, new_term);
                        

                        
                      

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
            catch (Exception ex)
            {
                errorbox.Text = "Error: while saving computation " + ex.Message;
                errorbox.ForeColor = Color.Red;
                errorbox.BackColor = Color.FromArgb(255, 224, 192);
                errorbox.SymbolColor = Color.Red;
                errorbox.Visible = true;
            }
        }

        private void subjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

            
            if (student_admno_list.Text == "")
            {
                errorbox.Text = "Specify admission number";
                errorbox.ForeColor = Color.Red;
                errorbox.BackColor = Color.FromArgb(255, 224, 192);
                errorbox.SymbolColor = Color.Red;
                errorbox.Visible = true;
            }
            else if (new_term == "")
            {
                errorbox.Text = "Specify term to compute";
                errorbox.ForeColor = Color.Red;
                errorbox.BackColor = Color.FromArgb(255, 224, 192);
                errorbox.SymbolColor = Color.Red;
                errorbox.Visible = true;
            }
            else
            {
                displaysubject_name.Text = subjects.Text;
                new_term = data.get_session().Replace(" 2020", "");
                teachers_remark.DataSource = data.view_assessment_class_term(subjects.Text, studclass.Text, new_term);
                data.get_assessment_data(student_admno_list.Text, subjects.Text, new_term, studclass.Text);
                if (data.exe == 1)
                {
                    ca1.Text = data.get_ca1;
                    ca2.Text = data.get_ca2;
                    ca3.Text = data.get_ca3;
                    exam.Text = data.get_exam;
                    total.Text = data.get_total;
                    data2.search_bio(student_admno_list.Text);
                    student_name.Text = data2.g_fullname;
                    student_name.Visible = true;
                    errorbox.Text = data.msg();
                    errorbox.ForeColor = Color.Green;
                    errorbox.BackColor = Color.Honeydew;
                    errorbox.SymbolColor = Color.Green;
                    errorbox.Visible = true;
                }
                else
                {
                    ca1.Text = data.get_ca1;
                    ca2.Text = data.get_ca2;
                    ca3.Text = data.get_ca3;
                    exam.Text = data.get_exam;
                    total.Text = data.get_total;
                    student_name.Visible = false;
                    errorbox.Text = data.msg();
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

        private void ca1_TextChanged_1(object sender, EventArgs e)
        {
            try
            {

                total.Text = data.calculate(ca1.Text, ca2.Text, ca3.Text, exam.Text).ToString();
                if (data.exe == 1)
                {
                    errorbox.Text = data.msg();
                    errorbox.ForeColor = Color.Green;
                    errorbox.BackColor = Color.Honeydew;
                    errorbox.SymbolColor = Color.Green;
                    errorbox.Visible = true;
                    total.Visible = true;
                }
                else
                {
                    errorbox.Text = data.msg();
                    errorbox.ForeColor = Color.Red;
                    errorbox.BackColor = Color.FromArgb(255, 224, 192);
                    errorbox.SymbolColor = Color.Red;
                    errorbox.Visible = true;
                    total.Visible = false;
                }
            }
            catch (Exception)
            {
                errorbox.Text = "Wrong Input - Numbers only";
                errorbox.ForeColor = Color.Red;
                errorbox.BackColor = Color.FromArgb(255, 224, 192);
                errorbox.SymbolColor = Color.Red;
                errorbox.Visible = true;
                total.Visible = false;
            }
        }

        private void ca2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                total.Text = data.calculate(ca1.Text, ca2.Text,ca3.Text, exam.Text).ToString();
                if (data.exe == 1)
                {
                    errorbox.Text = data.msg();
                    errorbox.ForeColor = Color.Green;
                    errorbox.BackColor = Color.Honeydew;
                    errorbox.SymbolColor = Color.Green;
                    errorbox.Visible = true;
                    total.Visible = true;
                }
                else
                {
                    errorbox.Text = data.msg();
                    errorbox.ForeColor = Color.Red;
                    errorbox.BackColor = Color.FromArgb(255, 224, 192);
                    errorbox.SymbolColor = Color.Red;
                    errorbox.Visible = true;
                    total.Visible = false;
                }
            }
            catch (Exception)
            {
                errorbox.Text = "Wrong Input - Numbers only";
                errorbox.ForeColor = Color.Red;
                errorbox.BackColor = Color.FromArgb(255, 224, 192);
                errorbox.SymbolColor = Color.Red;
                errorbox.Visible = true;
                total.Visible = false;
            }

        }

        private void exam_TextChanged(object sender, EventArgs e)
        {
            try
            {
                total.Text = data.calculate(ca1.Text, ca2.Text, ca3.Text, exam.Text).ToString();
                if (data.exe == 1)
                {
                    errorbox.Text = data.msg();
                    errorbox.ForeColor = Color.Green;
                    errorbox.BackColor = Color.Honeydew;
                    errorbox.SymbolColor = Color.Green;
                    errorbox.Visible = true;
                    total.Visible = true;
                }
                else
                {
                    errorbox.Text = data.msg();
                    errorbox.ForeColor = Color.Red;
                    errorbox.BackColor = Color.FromArgb(255, 224, 192);
                    errorbox.SymbolColor = Color.Red;
                    errorbox.Visible = true;
                    total.Visible = false;
                }
            }
            catch (Exception)
            {
                errorbox.Text = "Wrong Input - Numbers only";
                errorbox.ForeColor = Color.Red;
                errorbox.BackColor = Color.FromArgb(255, 224, 192);
                errorbox.SymbolColor = Color.Red;
                errorbox.Visible = true;
                total.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            
            view_Performance newfrm = new view_Performance();
            newfrm.Show(); this.Hide();
        }

        private void groupBox11_Enter(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

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

        private void studclass_SelectedIndexChanged(object sender, EventArgs e)
        {
           student_admno_list.DataSource = data2.get_admno_list(studclass.Text);
           student_admno_list.DisplayMember = "adm_no";

           new_term = data.get_session().Replace(" 2020", "");
           teachers_remark.DataSource = data.view_assessment_class_term(subjects.Text, studclass.Text, new_term);

           data2.search_bio(student_admno_list.Text);
           if (data.exe == 1)
           {
               student_name.Text = data2.g_fullname ;
               student_name.Visible = true;
           }
           else
           {
               student_name.Visible = false;
           }
       

        }

        private void student_admno_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                new_term = data.get_session().Replace(" 2020", "");
                if (student_admno_list.Text == "")
                {
                    errorbox.Text = "Specify admission number";
                    errorbox.ForeColor = Color.Red;
                    errorbox.BackColor = Color.FromArgb(255, 224, 192);
                    errorbox.SymbolColor = Color.Red;
                    errorbox.Visible = true;
                }
                else if (new_term == "")
                {
                    errorbox.Text = "Specify term to compute";
                    errorbox.ForeColor = Color.Red;
                    errorbox.BackColor = Color.FromArgb(255, 224, 192);
                    errorbox.SymbolColor = Color.Red;
                    errorbox.Visible = true;
                }
                else
                {
                    data.get_assessment_data(student_admno_list.Text, subjects.Text, new_term, studclass.Text);
                    if (data.exe == 1)
                    {
                        ca1.Text = data.get_ca1;
                        ca2.Text = data.get_ca2;
                        ca3.Text = data.get_ca3;
                        exam.Text = data.get_exam;
                        total.Text = data.get_total;
                        data2.search_bio(student_admno_list.Text);
                        student_name.Text = data2.g_fullname ;
                        student_name.Visible = true;
                        errorbox.Text = data.msg();
                        errorbox.ForeColor = Color.Green;
                        errorbox.BackColor = Color.Honeydew;
                        errorbox.SymbolColor = Color.Green;
                        errorbox.Visible = true;
                    }
                    else
                    {
                        ca1.Text = data.get_ca1;
                        ca2.Text = data.get_ca2;
                        ca3.Text = data.get_ca3;
                        exam.Text = data.get_exam;
                        total.Text = data.get_total;
                        student_name.Visible = false;
                        errorbox.Text = data.msg();
                        errorbox.ForeColor = Color.Red;
                        errorbox.BackColor = Color.FromArgb(255, 224, 192);
                        errorbox.SymbolColor = Color.Red;
                        errorbox.Visible = true;
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            } 
            
        }

        private void ca3_TextChanged(object sender, EventArgs e)
        {
            try
            {

                total.Text = data.calculate(ca1.Text, ca2.Text,ca3.Text, exam.Text).ToString();
                if (data.exe == 1)
                {
                    errorbox.Text = data.msg();
                    errorbox.ForeColor = Color.Green;
                    errorbox.BackColor = Color.Honeydew;
                    errorbox.SymbolColor = Color.Green;
                    errorbox.Visible = true;
                    total.Visible = true;
                }
                else
                {
                    errorbox.Text = data.msg();
                    errorbox.ForeColor = Color.Red;
                    errorbox.BackColor = Color.FromArgb(255, 224, 192);
                    errorbox.SymbolColor = Color.Red;
                    errorbox.Visible = true;
                    total.Visible = false;
                }
            }
            catch (Exception)
            {
                errorbox.Text = "Wrong Input - Numbers only";
                errorbox.ForeColor = Color.Red;
                errorbox.BackColor = Color.FromArgb(255, 224, 192);
                errorbox.SymbolColor = Color.Red;
                errorbox.Visible = true;
                total.Visible = false;
            }
        }


    }
}
