using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Drawing;

namespace My_Easy_Edu_V_1._0.codes
{
    class computation
    {
        public OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=sars_db.mdb");
        private string status, random_ID, cleaned_subject, compute_grade, cleaned_data;
        private Random rnd, rnd2;
        private int totalfound, cleaned_num, totalmark, compute_score, getValue, total_in_subjects;
        public int exe;
        public double no_of_subjects_offered_student;
        public string student_class, get_ca1, get_ca2, get_ca3, get_exam, get_total;
        private List<string> subjects_total = new List<string>();
        private List<string> compiled_total = new List<string>();
        private List<string> final_total_list = new List<string>();
        private OleDbDataAdapter da_pos = new OleDbDataAdapter();
        private DataTable dt_pos = new DataTable();

        private OleDbDataAdapter da_compiled = new OleDbDataAdapter();
        private DataTable dt_compiled = new DataTable();

        private OleDbDataAdapter da_admno = new OleDbDataAdapter();
        private DataTable dt_admno = new DataTable();
        private Image sch_logo;

        private OleDbDataAdapter da_total = new OleDbDataAdapter();
        public DataTable dt_total = new DataTable();

        private OleDbDataReader readTotalfromSubjects;

        public string current_session_term, current_academic_weeks;

        DataTable dt_ca_all_for_student = new DataTable();
        public int totalfound_ca_all_for_student;

        public string display_cumm_total;

        private double class_average;

        private void checkconn()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }


        public string msg()
        {
            return status;
        }

        public string generate_ID()
        {
            rnd = new Random();
            rnd2 = new Random();
            int value = rnd.Next(0, 999);
            int value2 = rnd2.Next(1000, 9999);
            random_ID = value.ToString() + value2.ToString();
            return random_ID;
        }


        public string get_session()
        {
            checkconn();
            conn.Open();
            string sql = "select * from current_session";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                current_session_term = dr[0].ToString();
            }
            else
            {
                current_session_term = "Not Set";
            }
            dr.Close();
            dr.Dispose();

            return current_session_term;

        }
        public void get_session(bool xstatus)
        {
            checkconn();
            conn.Open();
            string sql = "select * from current_session";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                current_session_term = dr[0].ToString();
                current_academic_weeks = dr[1].ToString();
            }
            else
            {
                current_session_term = "Not Set";
                current_academic_weeks = "Not Set";
            }
            dr.Close();
            dr.Dispose();

        }

       public void set_session(string current_session_year, string xweeks)
        {
            string sql = "update current_session set current_term=@session,academic_weeks=@weeks";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.AddWithValue("@session", current_session_year);
            cmd.Parameters.AddWithValue("@weeks", xweeks);
            if (cmd.ExecuteNonQuery() != 0)
            {
                status = "Current-term has been set to " + current_session_year + " successfully";
                exe = 1;
            }
            else
            {
                status = "Error while processing request";
                exe = 0;
            }
        }


       public void new_classroom(string classname)
       {
           checkconn();
           conn.Open();
           string sqlx = "select * from classrooms where classroom = @classname";
           OleDbCommand cmdx = new OleDbCommand(sqlx, conn);
           cmdx.Parameters.AddWithValue("@classname", classname);
           OleDbDataReader dr = cmdx.ExecuteReader();
           if(dr.Read())
           {
               status = "Classroom exist please verify";
               exe = 0;
           }
           else
           {
               string sql = "insert into classrooms values (@classname)";
               OleDbCommand cmd = new OleDbCommand(sql, conn);
               cmd.Parameters.AddWithValue("@classname", classname);
               if (cmd.ExecuteNonQuery() != 0)
               {
                   status = classname + " has been added to classroom list successfully";
                   exe = 1;
               }
               else
               {
                   status = "Error while adding classroom to list";
                   exe = 0;
               }
           }
           dr.Close();
           dr.Dispose();

           
           
       }

       public void remove_classroom(string classname)
       {
           string sql = "delete from classrooms where classroom = @classname";
           OleDbCommand cmd = new OleDbCommand(sql, conn);
           cmd.Parameters.AddWithValue("@classname", classname);
           if (cmd.ExecuteNonQuery() != 0)
           {
               status = classname + " has been removed from classroom list successfully";
               exe = 1;
           }
           else
           {
               status = "Error : Classroom does not exit";
               exe = 0;
           }
       }
       public int total_classrooms()
       {
           checkconn();
           conn.Open();
           string sql = "select * from classrooms";
           OleDbCommand cmd = new OleDbCommand(sql, conn);
           OleDbDataAdapter da = new OleDbDataAdapter(cmd);
           DataTable dt = new DataTable();
           da.Fill(dt);
           return dt.Rows.Count;
       }

       public DataTable classrooms_list()
       {
           checkconn();
           conn.Open();
           string sql = "select * from classrooms";
           OleDbCommand cmd = new OleDbCommand(sql, conn);
           OleDbDataAdapter da = new OleDbDataAdapter(cmd);
           DataTable dt = new DataTable();
           da.Fill(dt);
           return dt;
       }

       public int total_student_in_classrooms(string stud_class)
       {
           checkconn();
           conn.Open();
           string sql = "select * from bio_data where [class]=@class";
           OleDbCommand cmd = new OleDbCommand(sql, conn);
           OleDbDataAdapter da = new OleDbDataAdapter(cmd);
           cmd.Parameters.AddWithValue("@class", stud_class);
           DataTable dt = new DataTable();
           da.Fill(dt);
           return dt.Rows.Count;
       }

        public string cleanInput(string data)
        {
            cleaned_subject = data;
            cleaned_subject = cleaned_subject.Replace("@", "");
            cleaned_subject = cleaned_subject.Replace("#", "");
            cleaned_subject = cleaned_subject.Replace("?", "");
            cleaned_subject = cleaned_subject.Replace("$", "");
            cleaned_subject = cleaned_subject.Replace("'", "");
            cleaned_subject = cleaned_subject.Replace("*", "");
            cleaned_subject = cleaned_subject.Replace(" ", "_");
            cleaned_subject = cleaned_subject.Trim(new char[] { '"' });
            return "tbl_" + cleaned_subject;
        }

        public string cleanInput_normal(string data)
        {
            cleaned_data = data;
            cleaned_data = cleaned_data.Replace("@", "");
            cleaned_data = cleaned_data.Replace("#", "");
            cleaned_data = cleaned_data.Replace("?", "");
            cleaned_data = cleaned_data.Replace("$", "");
            cleaned_data = cleaned_data.Replace("'", "");
            cleaned_data = cleaned_data.Replace("*", "");
            cleaned_data = cleaned_data.Trim(new char[] { '"' });
            return cleaned_data;
        }

        public void create_subject(string subject)
        {
            checkconn();
            conn.Open();
            string sql = "create table " + subject + "([subject_id] VARCHAR(50) NOT NULL, [adm_no] VARCHAR(50) NOT NULL, [class] VARCHAR(50) NOT NULL, [subject_title] VARCHAR(150) NOT NULL, [ca1] VARCHAR(50) NOT NULL, [ca2] VARCHAR(50) NOT NULL, [ca3] VARCHAR(50) NOT NULL, [exam] VARCHAR(50) NOT NULL, [total] VARCHAR(50) NOT NULL, [grade] VARCHAR(50) NOT NULL, [teacher_remark] VARCHAR(50) NOT NULL,[term] VARCHAR(50) NOT NULL)";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            if (cmd.ExecuteNonQuery() == 0)
            {
                addlist(subject);
                exe = 1;
                status = "Subject created successfully";
            }
            else
            {
                exe = 0;
                status = "Error: While creating subject";
            }

        }

        void addlist(string subject_title)
        {
            string sql = "insert into subject_list values(@subject)";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.AddWithValue("@subject", subject_title.Replace("tbl_", "").Replace("_", " ").ToUpper());
            cmd.ExecuteNonQuery();
        }

        public int get_no_subject()
        {
            checkconn();
            conn.Open();
            string sql = "select * from subject_list";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt.Rows.Count;
        }

       

        public DataTable view_subjects_list()
        {
            checkconn();
            conn.Open();
            string sql = "select * from subject_list";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void remove_subjects_list(string subjects)
        {
            checkconn();
            conn.Open();
            string sql = "delete from subject_list where subjects=@subject";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@subject", subjects);
            if (cmd.ExecuteNonQuery() != 0)
            {
                del_table("tbl_" + subjects.Replace(" ", "_"));
                exe = 1;
                status = "Subject removed successfully";
            }
            else
            {
                exe = 0;
                status = "Error: Subject name is not correct";
            }
        }

        void del_table(string table_name)
        {
            string sql = "drop table " + table_name;
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }

        public int total_record_found()
        {
            return totalfound;
        }
        //continous assessment
        public DataTable view_performance_all(string subject_name, string studclass)
        {
            checkconn();
            conn.Open();
            string sql = "select * from " + "tbl_" + subject_name.Replace(" ", "_").Replace("'", "") + " where [class] = @class ";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.AddWithValue("@class", studclass);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            totalfound = dt.Rows.Count;
            if (dt.Rows.Count > 0)
            {
                exe = 1;
                status = totalfound.ToString() + " Record found";
            }
            else
            {
                exe = 0;
                status = "No record found for " + subject_name;
            }
            return dt;
        }



        public DataTable view_performance_based_on_score(string subject_name, int total_score)
        {
            checkconn();
            conn.Open();
            string sql = "select * from " + "tbl_" + subject_name.Replace(" ", "_").Replace("'", "") + " where CLng([total]) >= @total ";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@total",  total_score);
            DataTable dt = new DataTable();
            da.Fill(dt);
            totalfound = dt.Rows.Count;
            if (dt.Rows.Count > 0)
            {
                exe = 1;
                status = totalfound.ToString() + " Record found";
            }
            else
            {
                exe = 0;
                status = "No record found for " + subject_name;
            }
            return dt;
        }

        //CHECK HERE

        public DataTable student_ca_for_term(string adm_no, string term)
        {
            checkconn();
            conn.Open();
            dt_ca_all_for_student.Clear();
            string sql2 = "select * from subject_list";
            OleDbCommand cmd2 = new OleDbCommand(sql2, conn);
            OleDbDataAdapter da2 = new OleDbDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            foreach(DataRow dr in dt2.Rows)
            {
                string sql = "select subject_title,ca1,ca2,exam,total from " + "tbl_" + dr["subjects"].ToString().Replace(" ", "_").Replace("'", "") + " where adm_no=@admno and term=@term";
                OleDbCommand cmd = new OleDbCommand(sql, conn);            
                cmd.Parameters.AddWithValue("@admno", adm_no);
                cmd.Parameters.AddWithValue("@term", term);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(dt_ca_all_for_student);
                totalfound_ca_all_for_student = dt_ca_all_for_student.Rows.Count;
                if (dt_ca_all_for_student.Rows.Count > 0)
                {
                    exe = 1;
                    
                }
                else
                {
                    exe = 0;
                    
                }
                
                
               
            }

            return dt_ca_all_for_student;

        }

        public DataTable student_result_for_term(string adm_no, string term)
        {
            checkconn();
            conn.Open();
            dt_ca_all_for_student.Clear();
            string sql2 = "select * from subject_list";
            OleDbCommand cmd2 = new OleDbCommand(sql2, conn);
            OleDbDataAdapter da2 = new OleDbDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            foreach (DataRow dr in dt2.Rows)
            {
                string sql = "select subject_title,ca1,ca2,ca3,exam,total,grade,teacher_remark from " + "tbl_" + dr["subjects"].ToString().Replace(" ", "_").Replace("'", "") + " where adm_no=@admno and term=@term";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.Parameters.AddWithValue("@admno", adm_no);
                cmd.Parameters.AddWithValue("@term", term);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(dt_ca_all_for_student);
                totalfound_ca_all_for_student = dt_ca_all_for_student.Rows.Count;
                if (dt_ca_all_for_student.Rows.Count > 0)
                {
                    exe = 1;

                }
                else
                {
                    exe = 0;

                }



            }

            return dt_ca_all_for_student;

        }
        public DataTable view_performance_admno(string subject_name, string adm_no)
        {
            checkconn();
            conn.Open();
            string sql = "select * from " + "tbl_" + subject_name.Replace(" ", "_").Replace("'", "") + " where adm_no=@admno";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@admno", adm_no);
            DataTable dt = new DataTable();
            da.Fill(dt);
            totalfound = dt.Rows.Count;
            if (dt.Rows.Count > 0)
            {
                exe = 1;
                status = totalfound.ToString() + " Record found";
            }
            else
            {
                exe = 0;
                status = "No record found for " + subject_name;
            }
            return dt;
        }


        public DataTable view_assessment_class_term(string subject_name, string stud_class, string term)
        {
            checkconn();
            conn.Open();
            string sql = "select adm_no,ca1,ca2,ca3,exam,total from " + "tbl_" + subject_name.Replace(" ", "_").Replace("'", "") + " where [class]=@class and term=@term";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@class", stud_class);
            cmd.Parameters.AddWithValue("@term", term);
            DataTable dt = new DataTable();
            da.Fill(dt);
            totalfound = dt.Rows.Count;
            
            return dt;
        }
        // CHECK HERE

        public DataTable view_performance_class_term(string subject_name, string stud_class, string term)
        {
            checkconn();
            conn.Open();
            string sql = "select * from " + "tbl_" + subject_name.Replace(" ", "_").Replace("'", "") + " where [class]=@class and term=@term ";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@class", stud_class);
            cmd.Parameters.AddWithValue("@term", term);
            DataTable dt = new DataTable();
            da.Fill(dt);
            totalfound = dt.Rows.Count;
            if (dt.Rows.Count > 0)
            {
                exe = 1;
                status = totalfound.ToString() + " Record found";
            }
            else
            {
                exe = 0;
                status = "No record found for " + subject_name;
            }

            return dt;
        }

        //CALCULATE ASSESSMENTS

        private int clean_num(string num)
        {
            if (num == "")
            {
                cleaned_num = 0;
            }
            else
            {
                cleaned_num = int.Parse(num);
            }

            return cleaned_num;
        }
        public int calculate(string ca1, string ca2, string ca3, string exam)
        {

            int new_ca1 = clean_num(ca1);
            int new_ca2 = clean_num(ca2);
            int new_ca3 = clean_num(ca3);
            int new_exam = clean_num(exam);

            ca1 = new_ca1.ToString();
            ca2 = new_ca2.ToString();
            ca3 = new_ca3.ToString();
            exam = new_exam.ToString();

            if (new_ca1 > 100)
            {
                exe = 0;
                status = "C.A 1 score or cummulative total cannot be greater than 100";
                totalmark = new_ca1 + new_ca2 + new_exam;
            }
            else if (new_ca2 > 100)
            {
                exe = 0;
                status = "C.A 2 score or cummulative total cannot be greater than 100";
                totalmark = new_ca1 + new_ca2 + new_exam;
            }

            else if (new_ca3 > 100)
            {
                exe = 0;
                status = "C.A 3 score or cummulative total cannot be greater than 100";
                totalmark = new_ca1 + new_ca2 + new_exam;
            }
            else if (new_exam > 100)
            {
                exe = 0;
                status = "EXAM score or cummulative total cannot be greater than 100";
                totalmark = new_ca1 + new_ca2 + new_exam;
            }
                else if((new_ca1 + new_ca2 + new_exam) > 100)
            {
                exe = 0;
                status = "Cummulative total mark cannot be greater than 100";
                totalmark = new_ca1 + new_ca2 + new_exam;
            }
            else
            {
                exe = 1;
                status = "CA(s) verified successfuly - continue";
                totalmark = new_ca1 + new_ca2 + new_ca3 + new_exam;
            }

            return totalmark;
        }

        //verify students


        // CHECK HERE

        public void verify_student(string adm_no, string subjects, string term)
        {
            checkconn();
            conn.Open();
            string sql = "select [class] from bio_data where adm_no=@admno";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.AddWithValue("@admno", adm_no);

            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                exe = 1;
                status = "Student has been verified successfully";
                student_class = dr[0].ToString();
                get_assessment_data(adm_no, subjects, term, student_class);

            }
            else
            {
                exe = 0;
                status = "Students/Pupils record not matched";
                student_class = "";
            }

        }

        public void get_cumm_total_class_total(string admission_no, string session_term, string student_class)
        {
            string sql = "select [total] from [class_data] where adm_no=@admno and term=@term and [class]=@class";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.AddWithValue("@admno", admission_no);
            cmd.Parameters.AddWithValue("@term", session_term);
            cmd.Parameters.AddWithValue("@class", student_class);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                display_cumm_total = dr[0].ToString();

            }
            else
            {
                display_cumm_total = "";
  


            }
        }

        public double get_average( string session_term, string student_class, int no_of_subject)
        {
            string sql = "select [total] from [class_data] where term=@term and [class]=@class";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.AddWithValue("@term", session_term);
            cmd.Parameters.AddWithValue("@class", student_class);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            if(dt.Rows.Count>0)
            {
                foreach(DataRow dtr in dt.Rows)
                {
                    class_average += (double.Parse(dtr["total"].ToString()) / no_of_subject) / (dt.Rows.Count);
                }
             
               
            }
            else
            {
                class_average = 0.0;
            }

            return class_average;
            
        }
        public void get_assessment_data(string admno, string subjects, string term, string stud_class)
        {
            string sql = "select ca1,ca2,ca3,exam,total from tbl_" + subjects.Replace(" ", "_") + " where adm_no=@admno and term=@term and [class]=@class";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.AddWithValue("@admno", admno);
            cmd.Parameters.AddWithValue("@term", term);
            cmd.Parameters.AddWithValue("@class", stud_class);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                get_ca1 = dr[0].ToString();
                get_ca2 = dr[1].ToString();
                get_ca3 = dr[2].ToString();
                get_exam = dr[3].ToString();
                get_total = dr[4].ToString();

            }
            else
            {
                get_ca1 = "0";
                get_ca2 = "0";
                get_ca3 = "0";
                get_exam = "0";
                get_total = "0";


            }

        }

        //save_update computation

        public void get_all_total_in_subjects(string stud_class, string term, string adm_no)
        {
            checkconn();
            conn.Open();
            total_in_subjects = 0;
            getValue = 0;
            string sql = "select [subjects] from subject_list";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            da_compiled = new OleDbDataAdapter(cmd);
            dt_compiled.Clear();
            da_compiled.Fill(dt_compiled);
            for (int i = 0; i < dt_compiled.Rows.Count; i++)
            {
                compiled_total.Add(dt_compiled.Rows[i]["subjects"].ToString());
            }

                for (int x = 0; x < compiled_total.Count; x++)
                {
                    string sql3 = "select [total] from tbl_" + compiled_total[x].Replace(" ", "_") + " where [adm_no]=@admno and [class]=@class and [term]=@term";
                    OleDbCommand cmd3 = new OleDbCommand(sql3, conn);
                    cmd3.Parameters.AddWithValue("@admno", adm_no);
                    cmd3.Parameters.AddWithValue("@class", stud_class);
                    cmd3.Parameters.AddWithValue("@term", term);
                    readTotalfromSubjects = cmd3.ExecuteReader();
                    if (readTotalfromSubjects.Read())
                    {
                        getValue = int.Parse(readTotalfromSubjects[0].ToString());
                        no_of_subjects_offered_student += 1;
                    }

                    total_in_subjects += getValue;
                    getValue = 0;


                }
        }

        public void save_update_computation(string admno, string stud_class, string subjects, string ca1, string ca2, string ca3, string exam, string total, string grade, string remark, string term)
        {
            checkconn();
            conn.Open();
            string sql = "select ca1,ca2,ca3,exam,total from tbl_" + subjects.Replace(" ", "_") + " where adm_no=@admno and term=@term";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.AddWithValue("@admno", admno);
            cmd.Parameters.AddWithValue("@term", term);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                update_compute(admno, stud_class, subjects, ca1, ca2,ca3, exam, total, grade, remark, term);

            }
            else
            {
                save_compute(admno, stud_class, subjects, ca1, ca2, ca3, exam, total, grade, remark, term);
               
            }

        }

        void save_compute(string admno, string stud_class, string subjects, string ca1, string ca2, string ca3, string exam, string total, string grade, string remark, string term)
        {
            string sql = "insert into tbl_" + subjects.Replace(" ", "_") + " values(@sid,@admno,@class,@subject,@ca1,@ca2,@ca3,@exam,@total,@grade,@remark,@term)";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.AddWithValue("@sid", generate_ID());
            cmd.Parameters.AddWithValue("@admno", admno);
            cmd.Parameters.AddWithValue("@class", stud_class);
            cmd.Parameters.AddWithValue("@subject", subjects);
            cmd.Parameters.AddWithValue("@ca1", ca1);
            cmd.Parameters.AddWithValue("@ca2", ca2);
            cmd.Parameters.AddWithValue("@ca3", ca3);
            cmd.Parameters.AddWithValue("@exam", exam);
            cmd.Parameters.AddWithValue("@total", total);
            cmd.Parameters.AddWithValue("@grade", grade);
            cmd.Parameters.AddWithValue("@remark", remark);
            cmd.Parameters.AddWithValue("@term", term);
            if (cmd.ExecuteNonQuery() != 0)
            {
                string sql_x = "select * from [class_data] where [adm_no]=@admno and [class]=@class and [term]=@term";
                OleDbCommand cmd_x = new OleDbCommand(sql_x, conn);
                cmd_x.Parameters.AddWithValue("@admno", admno);
                cmd_x.Parameters.AddWithValue("@class", stud_class);
                cmd_x.Parameters.AddWithValue("@term", term);
                OleDbDataReader dr = cmd_x.ExecuteReader();
                if (!dr.Read())
                {

                    get_all_total_in_subjects(stud_class, term, admno);
                    string sql2 = "insert into [class_data] values(@cid,@admno,@class,@total,@term)";
                    OleDbCommand cmd2 = new OleDbCommand(sql2, conn);
                    cmd2.Parameters.AddWithValue("@cid", generate_ID());
                    cmd2.Parameters.AddWithValue("@admno", admno);
                    cmd2.Parameters.AddWithValue("@class", stud_class);
                    cmd2.Parameters.AddWithValue("@total", total_in_subjects);
                    cmd2.Parameters.AddWithValue("@term", term);
                    cmd2.ExecuteNonQuery();
                }
                else
                {
                    get_all_total_in_subjects(stud_class, term, admno);
                    string sql4 = "update [class_data] set [total]=@total where [adm_no]=@admno and [class]=@class and [term]=@term";
                    OleDbCommand cmd4 = new OleDbCommand(sql4, conn);
                    cmd4.Parameters.AddWithValue("@total", total_in_subjects);
                    cmd4.Parameters.AddWithValue("@admno", admno);
                    cmd4.Parameters.AddWithValue("@class", stud_class);
                    cmd4.Parameters.AddWithValue("@term", term);
                    cmd4.ExecuteNonQuery(); 
                }
                exe = 1;
                status = "Computation was updated successfully...";
            }
            else
            {
                exe = 0;
                status = "Eror while updating computation...";
            }



        }

        

        void update_compute(string admno, string stud_class, string subjects, string ca1, string ca2, string ca3, string exam, string total, string grade, string remark, string term)
        {
            string sql = "update tbl_" + subjects.Replace(" ", "_") + " set [subject_id]=@sid,[adm_no]=@admno,[class]=@class,[subject_title]=@subject,[ca1]=@ca1,[ca2]=@ca2,[ca3]=@ca3,[exam]=@exam,[total]=@total,[grade]=@grade,[teacher_remark]=@remark,[term]=@term where adm_no=@admno and term=@term and subject_title=@subject ";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.AddWithValue("@sid", generate_ID());
            cmd.Parameters.AddWithValue("@admno", admno);
            cmd.Parameters.AddWithValue("@class", stud_class);
            cmd.Parameters.AddWithValue("@subject", subjects);
            cmd.Parameters.AddWithValue("@ca1", ca1);
            cmd.Parameters.AddWithValue("@ca2", ca2);
            cmd.Parameters.AddWithValue("@ca3", ca3);
            cmd.Parameters.AddWithValue("@exam", exam);
            cmd.Parameters.AddWithValue("@total", total);
            cmd.Parameters.AddWithValue("@grade", grade);
            cmd.Parameters.AddWithValue("@remark", remark);
            cmd.Parameters.AddWithValue("@term", term);
            if (cmd.ExecuteNonQuery() != 0)
            {
                exe = 1;
                status = "Computation was updated successful";
                get_all_total_in_subjects(stud_class, term, admno);
                string sql4 = "update [class_data] set [total]=@total where [adm_no]=@admno and [class]=@class and [term]=@term";
                OleDbCommand cmd4 = new OleDbCommand(sql4, conn);
                cmd4.Parameters.AddWithValue("@total",  total_in_subjects);
                cmd4.Parameters.AddWithValue("@admno", admno);
                cmd4.Parameters.AddWithValue("@class", stud_class);
                cmd4.Parameters.AddWithValue("@term", term);
                cmd4.ExecuteNonQuery(); 
            }
            else
            {
                exe = 0;
                status = "computation update was not successful";
            }
        }

        public string get_grade(string score)
        {
            compute_score = int.Parse(score);
            if (compute_score >= 75 && compute_score <= 100)
            {
                compute_grade = "A1";
            }
            else if (compute_score >= 70 && compute_score <= 74)
            {
                compute_grade = "B2";
            }
            else if (compute_score >= 65 && compute_score <= 69)
            {
                compute_grade = "B3";
            }
            else if (compute_score >= 60 && compute_score <= 64)
            {
                compute_grade = "C4";
            }
            else if (compute_score >= 55 && compute_score <= 59)
            {
                compute_grade = "C5";
            }
            else if (compute_score >= 50 && compute_score <= 54)
            {
                compute_grade = "C6";
            }
            else if (compute_score >= 45 && compute_score <= 49)
            {
                compute_grade = "D7";
            }
            else if (compute_score >= 40 && compute_score <= 44)
            {
                compute_grade = "E8";
            }
            else if (compute_score >= 0 && compute_score <= 39)
            {
                compute_grade = "F9";
            }

            return compute_grade;
        }


        // CHECK HERE
        public DataTable view_compiled_result()
        {
            checkconn();
            conn.Open();
            string sql = "select * from [class_data] ";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            totalfound = dt.Rows.Count;
            return dt;
        }


        // CHECK HERE
        public DataTable view_compiled_result_admno(string adm_no)
        {
            checkconn();
            conn.Open();
            string sql = "select * from [class_data] where [adm_no]=@admno ";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.AddWithValue("@admno", adm_no);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            totalfound = dt.Rows.Count;
            if (dt.Rows.Count > 0)
            {
                exe = 1;
                status = totalfound.ToString() + " Record found";
            }
            else
            {
                exe = 0;
                status = "No record found";
            }
            return dt;
        }

        //CHECK HERE

        public DataTable view_compiled_result_class(string studclass, string term)
        {
            checkconn();
            conn.Open();
            string sql = "select * from [class_data] where [class]=@class and [term]=@term ";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.AddWithValue("@class", studclass);
            cmd.Parameters.AddWithValue("@term", term);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            totalfound = dt.Rows.Count;
            if (dt.Rows.Count > 0)
            {
                exe = 1;
                status = totalfound.ToString() + " Record found";
            }
            else
            {
                exe = 0;
                status = "No record found";
            }
            return dt;
        }


        //PROMOTION AND DEMOTION

        public void promote_student(string admno, string new_class)
        {
            checkconn();
            conn.Open();
            string sql = "update [bio_data] set [class]=@new_class where adm_no=@admno";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.AddWithValue("@new_class", new_class);
            cmd.Parameters.AddWithValue("@admno", admno);
            if (cmd.ExecuteNonQuery() != 0)
            {
                exe = 1;
                status = "students/pupils with admission number " + admno + " has been updated to " + new_class;
            }
            else
            {
                exe = 0;
                status = "No record found to be updated";
            }

        }
        public void promote_class(string old_class, string new_class)
        {
            checkconn();
            conn.Open();
            string sql = "update [bio_data] set [class]=@new_class where [class]=@old_class";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.AddWithValue("@new_class", new_class);
            cmd.Parameters.AddWithValue("@oldclass", old_class);
            if (cmd.ExecuteNonQuery() != 0)
            {
                exe = 1;
                status = "All students/pupils from " + old_class + " has been updated to " + new_class;
            }
            else
            {
                exe = 0;
                status = "No record found to be updated";
            }
        }

        //CLEAR PERFORMANCE


        public void delete_class_data(string admno)
        {
            checkconn();
            conn.Open();
            string sql = "delete from class_data where adm_no=@admno";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.AddWithValue("@admno", admno);
            cmd.ExecuteNonQuery();
        }

      
        public void clear_performance_admno( string subject_title,string subject_id)
        {
            checkconn();
            conn.Open();
            string sql = "delete from tbl_" + subject_title.Replace(" ", "_") + " where subject_id=@subject_id";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.AddWithValue("@subject_id", subject_id);
           
            if (cmd.ExecuteNonQuery() != 0)
            {

                exe = 1;
                status = "Performance and result compilation has been cleared successfully";


            }
            else
            {
                exe = 0;
                status = "No record Found to be deleted";
            }
        }


        public void update_logo(Image school_logo)
        {
            checkconn();
            conn.Open();
            codes.bio_data_api data = new bio_data_api();
            string sql = "update current_session set [logo]=@logo";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.AddWithValue("@logo", data.imageToByteArray(school_logo));
            if (cmd.ExecuteNonQuery() != 0)
            {
                exe = 1;
                status = "School Logo has been Updated Successfully!";
            }
            else
            {
                exe = 0;
                status = "Error: Having issue updating logo";
            }
        }

        public Image get_logo()
        {
            checkconn();
            conn.Open();
            codes.bio_data_api data = new bio_data_api();
            string sql = "select [logo] from current_session";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                exe = 1;
                sch_logo = data.byteArrayToImage((Byte[])dr[0]);

                status = "Record found";
                dr.Close();
                dr.Dispose();
            }
            else
            {
                sch_logo = null;
            }

            return sch_logo;
        }


        //Teachers comment & Principal Comment

      public void add_teachers_comment(string comment)
        {
            string sql = "insert into teachers_comment values(@comment)";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.AddWithValue("@comment", comment);
            if (cmd.ExecuteNonQuery() != 0)
            {

                exe = 1;
                status = "Teacher's Comment added successfully";
            }
            else
            {
                exe = 0;
                status = "Error: Adding Teacher's Comment";
            }

        }


        public void remove_teachers_comment(string comment)
        {
            checkconn();
            conn.Open();
            string sql = "delete from teachers_comment where comments=@comment";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.AddWithValue("@comment", comment);
            if (cmd.ExecuteNonQuery() != 0)
            {
               
                exe = 1;
                status = "Teacher's Comment removed successfully";
            }
            else
            {
                exe = 0;
                status = "Error: Removing Teacher's Comment";
            }
        }


        public DataTable view_teachers_comment()
        {
            checkconn();
            conn.Open();
            string sql = "select * from [teachers_comment] ";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        //principal comment

     public void add_principal_comment(string comment)
        {
            string sql = "insert into principal_comment values(@comment)";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.AddWithValue("@comment", comment);
            if (cmd.ExecuteNonQuery() != 0)
            {

                exe = 1;
                status = "Principal's Comment added successfully";
            }
            else
            {
                exe = 0;
                status = "Error: Adding Principal's Comment";
            }

        }


        public void remove_principal_comment(string comment)
        {
            checkconn();
            conn.Open();
            string sql = "delete from principal_comment where comments=@comment";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.AddWithValue("@comment", comment);
            if (cmd.ExecuteNonQuery() != 0)
            {

                exe = 1;
                status = "Principal's Comment removed successfully";
            }
            else
            {
                exe = 0;
                status = "Error: Removing Principal's Comment";
            }
        }


        public DataTable view_principal_comment()
        {
            checkconn();
            conn.Open();
            string sql = "select * from [principal_comment] ";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


    }
}
