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
    public partial class manage_student : Form
    {
        codes.computation data = new codes.computation();
        codes.bio_data_api data2 = new codes.bio_data_api();
        public manage_student()
        {
            InitializeComponent();
        }

        private void buttonX16_Click(object sender, EventArgs e)
        {
            
            Form1 newfrm = new Form1();
            newfrm.Show();  this.Hide();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {

                
                login newfrm = new login();
                newfrm.Show();  this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult ask = MessageBox.Show("Are you sure of exiting this application", "Exiting...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ask == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {

            
            manage_student newfrm = new manage_student();
            newfrm.Show();  this.Hide();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            
            manage_session newfrm = new manage_session();
            newfrm.Show();  this.Hide();
        }

        private void buttonX17_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            
            manage_classroom newfrm = new manage_classroom();
            newfrm.Show();  this.Hide();
        }

        private void manage_student_Load(object sender, EventArgs e)
        {
            try
            { 
            schoolname.Text = Form1.get_schoolname;
            logo.Image = data.get_logo();
            class_name.DataSource = data.classrooms_list();
            class_name.DisplayMember = "classroom";

            m_class.DataSource = data.classrooms_list();
            m_class.DisplayMember = "classroom";

            s_class.DataSource = data.classrooms_list();
            s_class.DisplayMember = "classroom";

            totalno.Text = data2.get_bio_data().Rows.Count.ToString();

            dataGridView1.DataSource = data2.get_bio_data();

            }

            catch
            {
                MessageBox.Show("Error occured - Please try again");
            }

           

            
            
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            try
            { 
            if(fullname.Text=="" || admno.Text=="" || fullname.Text=="" || class_name.Text=="" || nationality.Text=="" || state.Text=="" )
            {
                msg.Text = "Fill all the neccessary box with required information";
                msg.BackColor = Color.Tomato;
                msg.Visible = true;
            }            
            else
            {
                data2.new_bio(admno.Text, fullname.Text, dob.Text, gender.Text, address.Text,class_name.Text, nationality.Text, state.Text, postalcode.Text, lga.Text, parent.Text, phone.Text, email.Text, occupation.Text, passport.Image);
                if (data2.exe == 1)
                {
                    msg.Text = data2.msg();
                    msg.BackColor = Color.MediumSeaGreen;
                    msg.Visible = true;
                    clear();
                    dataGridView1.DataSource = data2.get_bio_data();
                }
                else
                {
                    msg.Text = data2.msg();
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

        void clear()
        {
            admno.Text = "";
            fullname.Text = "";
            address.Text = "";
            class_name.Text = "";
            nationality.Text = "";
            nationality.SelectedIndex = -1;
            state.Text = "";
            state.SelectedIndex = -1;
            postalcode.Text = "";
            lga.Text = "";
            parent.Text = "";
            phone.Text = "";
            email.Text = "";
            occupation.Text = "";
            passport.Image = null;
            admno.Focus();

        }

        void clear2()
        {
            searchbox.Text = "";
            m_fullname.Text = "";
            m_address.Text = "";
            sp_class.Text = "";
            sp_dob.Text = "";
            m_nationality.Text = "";
            m_nationality.SelectedIndex = -1;
            m_state.Text = "";
            m_state.SelectedIndex = -1;
            m_postal.Text = "";
            m_lga.Text = "";
            m_parent.Text = "";
            m_phone.Text = "";
            m_email.Text = "";
            m_occupation.Text = "";
            m_passport.Image = null;
            searchbox.Focus();

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                    e.RowIndex >= 0)
                {
                    string search_admno = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
                    data2.search_bio(search_admno);
                    x_id.Text = data2.g_studentid;
                    x_admno.Text = data2.g_admno;
                    x_fullname.Text = data2.g_fullname;
                    x_dob.Text = data2.g_dob.ToString();
                    x_gender.Text = data2.g_gender.ToString();
                    x_address.Text = data2.g_address;
                    x_class.Text = data2.g_stud_class;
                    x_nationality.Text = data2.g_nationality;
                    x_state.Text = data2.g_state;
                    x_postal.Text = data2.g_postal;
                    x_lga.Text = data2.g_lga;
                    x_parent.Text = data2.g_parent;
                    x_phone.Text = data2.g_phone;
                    x_email.Text = data2.g_email;
                    x_occupation.Text = data2.g_occupation;
                    x_passport.Image = data2.g_passport;
                    x_regdate.Text = data2.g_date;
                    if (data2.exe == 1)
                    {
                        x_view.Visible = true;
                        x_close.Visible = true;
                        x_bar.Visible = true;
                    }
                    else
                    {
                        x_view.Visible = false;
                        x_close.Visible = false;
                        x_bar.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

 
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (searchbox.Text == "")
            {
                msg.Text = "Enter admission number";
                msg.BackColor = Color.Tomato;
                msg.Visible = true;
            }
            else
            {
                try
                {
                    data2.search_bio(searchbox.Text);
                    if (data2.exe == 1)
                    {
                        m_fullname.Text = data2.g_fullname;
                        sp_dob.Text = data2.g_dob;
                        m_gender.Text = data2.g_gender;
                        m_address.Text = data2.g_address;
                        sp_class.Text = data2.g_stud_class;
                        m_nationality.Text = data2.g_nationality;
                        m_state.Text = data2.g_state;
                        m_postal.Text = data2.g_postal;
                        m_lga.Text = data2.g_lga;
                        m_parent.Text = data2.g_parent;
                        m_phone.Text = data2.g_phone;
                        m_email.Text = data2.g_email;
                        m_occupation.Text = data2.g_occupation;
                        m_passport.Image = data2.g_passport;

                        msg.Text = data2.msg();
                        msg.BackColor = Color.MediumSeaGreen;
                        msg.Visible = true;
                    }
                    else
                    {
                        msg.Text = data2.msg();
                        msg.BackColor = Color.Tomato;
                        msg.Visible = true;
                        string val = searchbox.Text;
                        clear2();
                        searchbox.Text = val;

                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (searchbox.Text == "")
            {
                msg.Text = "Enter admission number";
                msg.BackColor = Color.Tomato;
                msg.Visible = true;
            }
            else
            {
                try 
                { 
                DialogResult ask = MessageBox.Show("Are you sure of updating this record", "Updating...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ask == System.Windows.Forms.DialogResult.Yes)
                {
                 
                    
                    data2.update_bio(m_fullname.Text, sp_dob.Text, m_gender.Text, m_address.Text, sp_class.Text, m_nationality.Text, m_state.Text, m_postal.Text, m_lga.Text, m_parent.Text, m_phone.Text, m_email.Text, m_occupation.Text, m_passport.Image ,searchbox.Text);
                   
                    if (data2.exe == 1)
                    {                     
                        msg.Text = data2.msg();
                        msg.BackColor = Color.MediumSeaGreen;
                        msg.Visible = true;
                        clear2();
                        dataGridView1.DataSource = data2.get_bio_data();
                    }
                    else
                    {
                        dataGridView1.DataSource = data2.get_bio_data();
                        msg.Text = data2.msg();
                        msg.BackColor = Color.Tomato;
                        msg.Visible = true;
                    }
                }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message);
                }
            }
                
        }

        private void button5_Click(object sender, EventArgs e)
        {

            try
            {

            
            if (searchbox.Text == "")
            {
                msg.Text = "Enter admission number";
                msg.BackColor = Color.Tomato;
                msg.Visible = true;
            }
            else
            {
                DialogResult ask = MessageBox.Show("Are you sure of deleting this record", "Deleting...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ask == System.Windows.Forms.DialogResult.Yes)
                {
                    data2.delete_bio(searchbox.Text);
                    if (data2.exe == 1)
                    {
                       
                        msg.Text = data2.msg();
                        msg.BackColor = Color.MediumSeaGreen;
                        msg.Visible = true;
                        clear2();
                        dataGridView1.DataSource = data2.get_bio_data();
                    }
                    else
                    {
                        msg.Text = data2.msg();
                        msg.BackColor = Color.Tomato;
                        msg.Visible = true;
                    }
                }
            }
            }

            catch
            {
                MessageBox.Show("Error occured - Please try again");
            }
        }

        private void manage_student_Activated(object sender, EventArgs e)
        {
            dataGridView1.DataSource = data2.get_bio_data();
        }

        private void buttonX19_Click(object sender, EventArgs e)
        {

            try
            { 
            if (s_admno.Text == "")
            {
                msg.Text = "Enter admission number";
                msg.BackColor = Color.Tomato;
                msg.Visible = true;
            }
            else
            {
                dataGridView1.DataSource = data2.get_bio_data_admno(s_admno.Text);
                if (data2.exe == 1)
                {
                    msg.Text = data2.msg();
                    msg.BackColor = Color.MediumSeaGreen;
                    msg.Visible = true;
                    totalno.Text = data2.get_bio_data_admno(s_admno.Text).Rows.Count.ToString();
                }
                else
                {
                    msg.Text = data2.msg();
                    msg.BackColor = Color.Tomato;
                    msg.Visible = true;
                    dataGridView1.DataSource = data2.get_bio_data_admno("");
                    totalno.Text = data2.get_bio_data_admno(s_admno.Text).Rows.Count.ToString();
             
                }
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
            if (s_class.Text == "")
            {
                msg.Text = "Select class";
                msg.BackColor = Color.Tomato;
                msg.Visible = true;
            }
            else
            {
                dataGridView1.DataSource = data2.get_bio_data_class(s_class.Text);
                if (data2.exe == 1)
                {
                    msg.Text = data2.msg();
                    msg.BackColor = Color.MediumSeaGreen;
                    msg.Visible = true;
                    totalno.Text = data2.get_bio_data_class(s_class.Text).Rows.Count.ToString();
                }
                else
                {
                    msg.Text = data2.msg();
                    msg.BackColor = Color.Tomato;
                    msg.Visible = true;
                    dataGridView1.DataSource = data2.get_bio_data_admno("");
                    totalno.Text = data2.get_bio_data_admno(s_admno.Text).Rows.Count.ToString();
                  
                }


            }
            }

            catch
            {
                MessageBox.Show("Error occured - Please try again");
            }
        }

        private void buttonX21_Click(object sender, EventArgs e)
        {

            try
            { 
            if (s_fullname.Text == "")
            {
                msg.Text = "Enter fullname";
                msg.BackColor = Color.Tomato;
                msg.Visible = true;
            }
            else
            {
                dataGridView1.DataSource = data2.get_bio_data_fullname(s_fullname.Text);
                if (data2.exe == 1)
                {
                    msg.Text = data2.msg();
                    msg.BackColor = Color.MediumSeaGreen;
                    msg.Visible = true;
                    totalno.Text = data2.get_bio_data_fullname(s_fullname.Text).Rows.Count.ToString();
                }
                else
                {
                    msg.Text = data2.msg();
                    msg.BackColor = Color.Tomato;
                    msg.Visible = true;
                    dataGridView1.DataSource = data2.get_bio_data_admno("");
                    totalno.Text = data2.get_bio_data_admno(s_admno.Text).Rows.Count.ToString();
                
                }

            }
            }

            catch
            {
                MessageBox.Show("Error occured - Please try again");
            }
        }

        private void x_close_Click(object sender, EventArgs e)
        {
            x_view.Visible = false;
            x_close.Visible = false;
            x_bar.Visible = false;
        }

        private void buttonX22_Click(object sender, EventArgs e)
        {

            try
            { 
            dataGridView1.DataSource = data2.get_bio_data();
            msg.Visible = false;
            totalno.Text = data2.get_bio_data().Rows.Count.ToString();
            }

            catch
            {
                MessageBox.Show("Error occured - Please try again");
            }
        }

   

        private void buttonX5_Click(object sender, EventArgs e)
        {
            
            manage_subject newfrm = new manage_subject();
            newfrm.Show();  this.Hide();
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            
            compute_result newfrm = new compute_result();
            newfrm.Show();  this.Hide();
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            
            view_Performance newfrm = new view_Performance();
            newfrm.Show();  this.Hide();
        }

        private void m_class_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            sp_class.Text = m_class.Text;
           if(sp_class.Text =="System.Data.DataRowView")
           {
               sp_class.Text = "";
           }
            
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

                        passport.Image = Image.FromFile(img.FileName);
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

        private void m_dob_ValueChanged(object sender, EventArgs e)
        {
            try
            { 
            sp_dob.Text = m_dob.Text;
            }

            catch
            {
                MessageBox.Show("Error occured - Please try again");
            }
        }

        private void m_passport_Click(object sender, EventArgs e)
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

                        m_passport.Image = Image.FromFile(img.FileName);
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

      

        private void buttonX8_Click(object sender, EventArgs e)
        {
            
            print_offline newfrm = new print_offline();
            newfrm.Show();  this.Hide();
        }

        

      

        

        private void buttonX15_Click(object sender, EventArgs e)
        {
            
            back_up newfrm = new back_up();
            newfrm.Show();  this.Hide();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

       
    }
}
