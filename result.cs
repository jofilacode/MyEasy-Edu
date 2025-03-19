using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Easy_Edu_V_1._0
{
    public partial class result : Form
    {

        string new_term;
       
        public result()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void result_Load(object sender, EventArgs e)
        {
            try 
            { 

           
            codes.bio_data_api data = new codes.bio_data_api();
            codes.computation data2 = new codes.computation();
            new_term = data2.get_session().Replace(" 2020", "");


            data.search_bio(print_offline.search_adm_no);
            
            fullname.Text = data.g_fullname;
            schoolname.Text = Form1.get_schoolname;
            logo.Image = data.get_logo();
            admno.Text = print_offline.search_adm_no;
            current_term.Text = new_term;
            studclass.Text = data.g_stud_class;
            classno.Text = data2.total_student_in_classrooms(studclass.Text).ToString();
            nopresent.Text = "0";
            noabsent.Text = "0";
            data2.get_cumm_total_class_total(admno.Text, new_term, studclass.Text);
            marksobtained.Text = data2.display_cumm_total;
            MarksObtainable.Text = (data2.student_result_for_term(print_offline.search_adm_no, new_term).Rows.Count * 100).ToString();
            Average.Text = data2.get_average(new_term, studclass.Text, data2.student_result_for_term(print_offline.search_adm_no, new_term).Rows.Count).ToString("0.00");

            data2.get_all_total_in_subjects(studclass.Text, new_term, admno.Text);
            Percentage.Text = Math.Round (double.Parse(marksobtained.Text) / (data2.no_of_subjects_offered_student), MidpointRounding.ToEven).ToString() + " %";

            dataGridView1.DataSource = data2.student_result_for_term(print_offline.search_adm_no, new_term);

            teacher_data.DataSource = data2.view_teachers_comment();
            teacher_data.DisplayMember = "comments";

            principal_data.DataSource = data2.view_principal_comment();
            principal_data.DisplayMember = "comments";


            }

            catch(Exception ex)
            {
                MessageBox.Show("Error occured: " + ex.Message);
            }
        
         
        }





        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(groupBox1.ClientRectangle.Width, groupBox1.ClientRectangle.Height);
            groupBox1.DrawToBitmap(bmp, groupBox1.ClientRectangle);
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try 
            { 
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            PrintDocument Pd = new PrintDocument();
            Pd.DocumentName = fullname.Text + "( " + admno.Text + " - " + studclass.Text + " )";
            Pd.PrintPage += printDocument1_PrintPage;
            ppd.Document = Pd;
            ppd.ShowDialog();
            }

            catch
            {
                MessageBox.Show("Error occured - Please try again");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox20_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox14_Enter(object sender, EventArgs e)
        {

        }

        

        

        

       

       
    }
}
