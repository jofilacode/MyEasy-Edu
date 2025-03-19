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
    
    public partial class view_Performance : Form
    {
        codes.computation data = new codes.computation();
        public view_Performance()
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

        private void buttonX7_Click(object sender, EventArgs e)
        {
            
            view_Performance newfrm = new view_Performance();
            newfrm.Show(); this.Hide();
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

        private void subjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (subjects.Text != null)
                {
                    dataGridView1.DataSource = data.view_performance_all(subjects.Text,class_name.Text);
                    no_of_record.Text = data.total_record_found().ToString();
                    no_of_record.Text = data.total_record_found().ToString();
                   
                }

            }
            catch (Exception)
            {
                
            }
        }

        private void buttonX18_Click(object sender, EventArgs e)
        {
            try
            { 
            if (subjects.Text == "")
            {
                errorbox.Text = "Enter Subject Name";
                errorbox.ForeColor = Color.Red;
                errorbox.BackColor = Color.FromArgb(255, 224, 192);
                errorbox.SymbolColor = Color.Red;
                errorbox.Visible = true;
            }
            else if (admno.Text == "")
            {
                errorbox.Text = "Enter admission number";
                errorbox.ForeColor = Color.Red;
                errorbox.BackColor = Color.FromArgb(255, 224, 192);
                errorbox.SymbolColor = Color.Red;
                errorbox.Visible = true;
            }
            else
            {
                dataGridView1.DataSource = data.view_performance_admno(subjects.Text, admno.Text);
                if (data.exe == 1)
                {
                    errorbox.Text = data.msg();
                    errorbox.ForeColor = Color.Green;
                    errorbox.BackColor = Color.Honeydew;
                    errorbox.SymbolColor = Color.Green;
                    errorbox.Visible = true;
                    no_of_record.Text = data.total_record_found().ToString();
                }
                else
                {
                    errorbox.Text = data.msg();
                    errorbox.ForeColor = Color.Red;
                    errorbox.BackColor = Color.FromArgb(255, 224, 192);
                    errorbox.SymbolColor = Color.Red;
                    errorbox.Visible = true;
                    no_of_record.Text = data.total_record_found().ToString();
                }
            }
            }
            catch
            {
                MessageBox.Show("Error Occured - Please try again");
            }
        }

       

        private void view_Performance_Load(object sender, EventArgs e)
        {
            try
            {

                schoolname.Text = Form1.get_schoolname;
                logo.Image = data.get_logo();
                subjects.DataSource = data.view_subjects_list();
                subjects.DisplayMember = "subjects";
                class_name.DataSource = data.classrooms_list();
                class_name.DisplayMember = "classroom";
                dataGridView1.DataSource = data.view_performance_all(subjects.Text, class_name.Text);
                no_of_record.Text = data.total_record_found().ToString();

                for(int i=50;i<=100;i++)
                {
                    numbers_search.Items.Add(i.ToString());
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error Occured - Please try again");
            }
        }



        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                    e.RowIndex >= 0)
                {
                    string new_subject_id = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
                    string new_admno =  Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                    string new_class = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                    string new_subject_tile = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
                    string new_term = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[11].Value);
                   
                    DialogResult ask = MessageBox.Show("Are you sure of deleting this record", "Deleting...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ask == System.Windows.Forms.DialogResult.Yes)
                    {


                        try
                        {
                            
                            data.clear_performance_admno(new_subject_tile,new_subject_id);
                            if (data.exe == 1)
                            {


                                data.delete_class_data(new_admno);
                                dataGridView1.DataSource = data.view_performance_all(subjects.Text,class_name.Text);
                                no_of_record.Text = data.total_record_found().ToString();
                                errorbox.Text = data.msg();
                                errorbox.ForeColor = Color.Green;
                                errorbox.BackColor = Color.Honeydew;
                                errorbox.SymbolColor = Color.Green;
                                errorbox.Visible = true;
                                
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
                        catch
                        {
                            errorbox.Text = "No record Found to be deleted";
                            errorbox.ForeColor = Color.Red;
                            errorbox.BackColor = Color.FromArgb(255, 224, 192);
                            errorbox.SymbolColor = Color.Red;
                            errorbox.Visible = true;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured - Please try again");
            }

        }

        private void numbers_search_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            { 

                dataGridView1.DataSource = data.view_performance_based_on_score(subjects.Text, int.Parse(numbers_search.Text));

            }
            catch
            {
                MessageBox.Show("Error Occured - Please try again");
            }
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

        private void class_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (subjects.Text != null)
                {
                    dataGridView1.DataSource = data.view_performance_all(subjects.Text, class_name.Text);
                    no_of_record.Text = data.total_record_found().ToString();
                    no_of_record.Text = data.total_record_found().ToString();

                }

            }
            catch (Exception)
            {

            }
        }
    }
}
