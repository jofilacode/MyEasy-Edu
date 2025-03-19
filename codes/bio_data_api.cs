using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
namespace My_Easy_Edu_V_1._0.codes
{

    class bio_data_api
    {
        public OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=sars_db.mdb");
        private string status;
        private Random rnd, rnd2;
        private string random_ID;
        public string g_studentid,g_admno, g_fullname, g_dob,g_gender, g_address, g_stud_class, g_nationality, g_state, g_postal, g_lga, g_parent, g_phone, g_email, g_occupation,g_date;
        public Image g_passport,s_passport;
        public string s_staff_id, s_fullname, s_category, s_dob, s_gender, s_nationality, s_state, s_address, s_phone, s_salary,s_date;
        public int exe;
        public double cleaned_num;
        private Image sch_logo;


        public void checkconn()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
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

        public double clean_num(string num)
        {
            if (num == "")
            {
                cleaned_num = 0;
            }
            else
            {
                cleaned_num = double.Parse(num);
            }

            return cleaned_num;
        }

        //IMAGE CONVERSION 
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }


        //CREATE NEW BIO DATA
        public void new_bio(string admno, string fulllname, string dob, string gender, string address, string stud_class, string nationality, string state, string postal, string lga, string parent, string phone, string email, string occupation, Image passport)
        {

            try
            {
                double k;
                if (admno == "" || fulllname == "" || dob == "" || gender=="" || (stud_class == "" || stud_class == null || stud_class == " ") || nationality == "" || state == "" )
                {
                    status = "All fields are Required - Please fill correctly";
                    exe = 0;
                }

               
                else
                {
                    checkconn();
                    conn.Open();
                    string sql_x = "select * from bio_data where adm_no=@admno";
                    OleDbCommand cmd_x = new OleDbCommand(sql_x, conn);
                    cmd_x.Parameters.AddWithValue("@admno", admno);
                    OleDbDataReader dr = cmd_x.ExecuteReader();
                    if (dr.Read())
                    {
                        exe = 0;
                        status = "Students/Pupils exist with admission number " + admno;
                    }
                    else
                    {
                        string sql = "insert into bio_data values(@id,admno,@fullname,@dob,@gender,@address,@class,@nationality,@state,@postal,@lga,@parent,@phone,@email,@occupation,@passport,@date)";
                        OleDbCommand cmd = new OleDbCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@id", generate_ID());
                        cmd.Parameters.AddWithValue("@admno", admno);
                        cmd.Parameters.AddWithValue("@fullname", fulllname.ToUpper());
                        cmd.Parameters.AddWithValue("@dob", dob);
                        cmd.Parameters.AddWithValue("@gender", gender);
                        cmd.Parameters.AddWithValue("@address", address);
                        cmd.Parameters.AddWithValue("@class", stud_class);
                        cmd.Parameters.AddWithValue("@nationality", nationality.ToUpper());
                        cmd.Parameters.AddWithValue("@state", state.ToUpper());
                        cmd.Parameters.AddWithValue("@postal", postal);
                        cmd.Parameters.AddWithValue("@lga", lga.ToUpper());
                        cmd.Parameters.AddWithValue("@parent", parent.ToUpper());
                        cmd.Parameters.AddWithValue("@phone", phone);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@occupation", occupation.ToUpper());
                        cmd.Parameters.AddWithValue("@passport", imageToByteArray(passport));
                        cmd.Parameters.AddWithValue("@date", DateTime.Now.ToShortDateString());
                        if (cmd.ExecuteNonQuery() != 0)
                        {
                            exe = 1;
                            status = "New Bio Record Created Successfully!";
                        }
                        else
                        {
                            exe = 0;
                            status = "Error: Having issue creating record";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                status = "Error: " + ex.Message;
            }

        }



        //DISPLAY BIO RECORD TABLE

        public DataTable get_admno_list(string student_class)
        {

            checkconn();
            conn.Open();
            string sql = "select adm_no from bio_data where [class] = @class";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.AddWithValue("@class", student_class);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            return dt;
        }

        public DataTable get_bio_data()
        {

            checkconn();
            conn.Open();
            string sql = "select adm_no,fullname,dob,address,[class] from bio_data";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            return dt;
        }

        public DataTable get_bio_data_admno(string admission_no)
        {
            checkconn();
            conn.Open();
            string sql = "select adm_no,fullname,dob,address,[class] from bio_data where adm_no=@admno";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.AddWithValue("@admno", admission_no);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                exe = 1;
                status = "Record found";
            }
            else
            {
                exe = 0;
                status = "No Record found";
            }
            return dt;

        }

        public DataTable get_bio_data_class(string stud_class)
        {
            checkconn();
            conn.Open();
            string sql = "select adm_no,fullname,dob,address,[class] from bio_data where [class]=@class";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.AddWithValue("@class", stud_class);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                exe = 1;
                status = "Record found";
            }
            else
            {
                exe = 0;
                status = "No Record found";
            }
            return dt;
        }

        public DataTable get_bio_data_fullname(string fullname)
        {
            checkconn();
            conn.Open();
            string sql = "select adm_no,fullname,dob,address,[class] from bio_data where fullname like @fname";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.AddWithValue("@fname", "%" + fullname + "%");
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                exe = 1;
                status = "Record found";
            }
            else
            {
                exe = 0;
                status = "No Record found";
            }
            return dt;

        }

        //MODIFY BIO DATA


        public void search_bio(string adm_no)
        {
            checkconn();
            conn.Open();
            string sql = "select * from bio_data where adm_no=@admno";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.AddWithValue("@admno", adm_no);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                exe = 1;
                g_studentid = dr[0].ToString();
                g_admno = dr[1].ToString();
                g_fullname = dr[2].ToString();
                g_dob =  dr[3].ToString();
                g_gender = dr[4].ToString();
                g_address = dr[5].ToString();
                g_stud_class = dr[6].ToString();
                g_nationality = dr[7].ToString();
                g_state = dr[8].ToString();
                g_postal = dr[9].ToString();
                g_lga = dr[10].ToString();
                g_parent = dr[11].ToString();
                g_phone = dr[12].ToString();
                g_email = dr[13].ToString();
                g_occupation = dr[14].ToString();
                g_passport = byteArrayToImage((Byte[])dr[15]);
                g_date = dr[16].ToString();

                status = "Record found";
                dr.Close();
                dr.Dispose();
            }
            else
            {
                exe = 0;
                g_admno = "";
                g_studentid = "";
                g_fullname = "";
                g_dob = "";
                g_gender = "";
                g_address = "";
                g_stud_class = "";
                g_nationality = "";
                g_state = "";
                g_postal = "";
                g_lga = "";
                g_parent = "";
                g_phone = "";
                g_email = "";
                g_occupation = "";
                g_passport = null;
                g_date = "";

                status = "No record found for admission number " + adm_no;
            }
        }


        public void update_bio(string fulllname, string dob, string gender, string address, string stud_class, string nationality, string state, string postal, string lga, string parent, string phone, string email, string occupation, Image passportx, string searchno)
        {

            try
            {
                double k;
                if (searchno == "")
                {
                    status = "Enter Admission number";
                }
                else if (fulllname == "" || dob == "" || gender=="" ||  stud_class == "" || nationality == "" || state == "" )
                {
                    status = "All fields are Required - Please fill correctly";
                }
              
                else
                {
                    checkconn();
                    conn.Open();
                    string sql = "update bio_data set fullname=@fullname,dob=@dob,gender=@gender,address=@address,[class]=@class,nationality=@nationality,[state]=@state,postal_code=@postal,lga=@lga,parent_guardian=@parent,phone=@phone,email=@email,occupation=@occupation,[passport]=@passport where adm_no=@searchno";
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@fullname", fulllname.ToUpper());
                    cmd.Parameters.AddWithValue("@dob", dob);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@class", stud_class);
                    cmd.Parameters.AddWithValue("@nationality", nationality.ToUpper());
                    cmd.Parameters.AddWithValue("@state", state.ToUpper());
                    cmd.Parameters.AddWithValue("@postal", postal);
                    cmd.Parameters.AddWithValue("@lga", lga.ToUpper());
                    cmd.Parameters.AddWithValue("@parent", parent.ToUpper());
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@occupation", occupation.ToUpper());
                    cmd.Parameters.AddWithValue("@passport", imageToByteArray(passportx));
                    cmd.Parameters.AddWithValue("@searchno", searchno);
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        exe = 1;
                        status = "Bio Record Updated Successfully!";
                    }
                    else
                    {
                        exe = 0;
                        status = "Error: Having issue updating record";
                    }
                }
            }
            catch (Exception ex)
            {
                status = "Error: " + ex.Message;
            }

        }

        

        public void delete_bio(string adm_no)
        {

            string sql = "delete from bio_data where adm_no=@admno";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.AddWithValue("@admno", adm_no);
            if (cmd.ExecuteNonQuery() != 0)
            {
                exe = 1;
                status = "Record deleted successfully";
            }
            else
            {
                exe = 0;
                status = "No Record deleted";
            }

        }



        //STAFF RECORD

        public void new_staff(string staff_id,string fulllname, string category, string dob, string gender, string nationality, string state, string address, string phone, string salary, Image passport)
        {

            try
            {
                double k;
                if (staff_id=="" || fulllname == "" || category=="" || dob=="" || gender=="" ||  nationality == "" || state == "" || address == "" || phone == "" || salary == "")
                {
                    status = "All fields are Required - Please fill correctly";
                    exe = 0;
                }

                else if (double.TryParse(phone, out k) == false)
                {
                    status = "Invalid Phone Number";
                    exe = 0;
                }
                else if (double.TryParse(salary, out k) == false)
                {
                    status = "Invalid salary amount - Numeric values expected";
                    exe = 0;
                }
                else if (passport == null)
                {
                    status = "Upload passport";
                    exe = 0;
                }
                else
                {
                    checkconn();
                    conn.Open();
                    string sql_x = "select * from bio_data_staff where staff_id=@staff_id or  fullname=@fullname ";
                    OleDbCommand cmd_x = new OleDbCommand(sql_x, conn);
                    cmd_x.Parameters.AddWithValue("@staff_id", staff_id);      
                    cmd_x.Parameters.AddWithValue("@fullname", fulllname);                
                    OleDbDataReader dr = cmd_x.ExecuteReader();
                    if (dr.Read())
                    {
                        exe = 0;
                        status = "Staff record already exist";
                    }
                    else
                    {
                        string sql = "insert into bio_data_staff values(@id,@staff_id,@fullname,@category,@dob,@gender,@nationality,@state,@address,@phone,@salary,@passport,@date)";
                        OleDbCommand cmd = new OleDbCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@id", generate_ID());
                        cmd.Parameters.AddWithValue("@staff_id", staff_id);
                        cmd.Parameters.AddWithValue("@fullname", fulllname.ToUpper());
                        cmd.Parameters.AddWithValue("@category", category);
                        cmd.Parameters.AddWithValue("@dob", dob);
                        cmd.Parameters.AddWithValue("@gender", gender);
                        cmd.Parameters.AddWithValue("@nationality", nationality.ToUpper());
                        cmd.Parameters.AddWithValue("@state", state.ToUpper());
                        cmd.Parameters.AddWithValue("@address", address);
                        cmd.Parameters.AddWithValue("@phone", phone);
                        cmd.Parameters.AddWithValue("@salary", salary);
                        cmd.Parameters.AddWithValue("@passport", imageToByteArray(passport));
                        cmd.Parameters.AddWithValue("@date", DateTime.Now.ToShortDateString());
                        if (cmd.ExecuteNonQuery() != 0)
                        {
                            exe = 1;
                            status = "New Staff Record Created Successfully!";
                        }
                        else
                        {
                            exe = 0;
                            status = "Error: Having issue creating record";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                status = "Error: " + ex.Message;
            }

        }



        //DISPLAY BIO RECORD TABLE

        public DataTable get_bio_data_staff()
        {
            

                checkconn();
                conn.Open();
                string sql = "select staff_id,fullname,dob,address,[phone],salary from bio_data_staff";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                dt.Clear();
                da.Fill(dt);
                return dt;
          
        }

        public DataTable get_bio_data_staff_id(string fullname_staff_id)
        {

                checkconn();
                conn.Open();
                string sql = "select staff_id,fullname,dob,address,[phone],salary from bio_data_staff where staff_id = @staff_id or fullname like @fullname";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.Parameters.AddWithValue("@staff_id", fullname_staff_id);
                cmd.Parameters.AddWithValue("@fullname", "%" +fullname_staff_id + "%");
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                dt.Clear();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    exe = 1;
                    status = "Record found";
                }
                else
                {
                    exe = 0;
                    status = "No Record found";
                }
           
                return dt;

            
        }

        public DataTable get_bio_data_category(string category)
        {
            checkconn();
            conn.Open();
            string sql = "select staff_id,fullname,dob,address,[phone],salary from bio_data_staff where [category]=@category";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.AddWithValue("@category", category);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                exe = 1;
                status = "Record found";
            }
            else
            {
                exe = 0;
                status = "No Record found";
            }
            return dt;
        }

       
        //MODIFY BIO DATA


        public void search_bio_staff_list(string x_staff_id)
        {
            checkconn();
            conn.Open();
            string sql = "select * from bio_data_staff where staff_id=@staff_id";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.AddWithValue("@staff_id", x_staff_id);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                exe = 1;
                s_staff_id = dr[1].ToString();
                s_fullname = dr[2].ToString();
                s_category = dr[3].ToString();
                s_dob = dr[4].ToString();
                s_gender = dr[5].ToString();
                s_nationality = dr[6].ToString();
                s_state = dr[7].ToString();
                s_address = dr[8].ToString();
                s_phone = dr[9].ToString();
                s_salary = dr[10].ToString();
                s_passport = byteArrayToImage((Byte[])dr[11]);
                s_date = dr[12].ToString();

                status = "Record found";
                dr.Close();
                dr.Dispose();
            }
            else
            {
                exe = 0;
                s_staff_id = "";
                s_fullname = "";
                s_category = "";
                s_dob = "";
                s_gender = "";
                s_nationality = "";
                s_state = "";
                s_address = "";
                s_phone = "";
                s_salary = "";
                s_passport = null;
                s_date = "";

                status = "No record found for staff_id " +  x_staff_id;
            }
            
        }


        public void update_bio_staff(string fulllname, string category, string dob, string gender, string nationality, string state, string address, string phone, string salary, Image passport, string searchid)
        {

            try
            {
                double k;
                if (searchid == "")
                {
                    status = "Enter Admission number";
                }
                else if (fulllname == "" || category == "" || dob == "" || gender == "" || nationality == "" || state == "" || address == "" || phone == "" || salary == "" || passport== null)
                {
                    status = "All fields are Required - Please fill correctly";
                }
                else if (double.TryParse(phone, out k) == false)
                {
                    status = "Invalid Phone Number";
                }
                
                else
                {
                    checkconn();
                    conn.Open();
                    string sql = "update bio_data_staff set fullname=@fullname,category=@category,dob=@dob,gender=@gender,nationality=@nationality,[state]=@state,address=@address,phone=@phone,salary=@salary,[passport]=@passport where staff_id=@staff_id";
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@fullname", fulllname.ToUpper());
                    cmd.Parameters.AddWithValue("@category", category);
                    cmd.Parameters.AddWithValue("@dob", dob);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@nationality", nationality.ToUpper());
                    cmd.Parameters.AddWithValue("@state", state.ToUpper());
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@salary", salary);
                    cmd.Parameters.AddWithValue("@passport", imageToByteArray(passport));
                    cmd.Parameters.AddWithValue("@staff_id", searchid);
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        exe = 1;
                        status = "Staff Record Updated Successfully!";
                    }
                    else
                    {
                        exe = 0;
                        status = "Error: Having issue updating record";
                    }
                }
            }
            catch (Exception ex)
            {
                status = "Error: " + ex.Message;
            }

        }



        public void delete_bio_staff(string staff_id)
        {

            string sql = "delete from bio_data_staff where staff_id=@staff_id";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.AddWithValue("@staff_id", staff_id);
            if (cmd.ExecuteNonQuery() != 0)
            {
                exe = 1;
                status = "Staff Record deleted successfully";
            }
            else
            {
                exe = 0;
                status = "No Record Found to be deleted";
            }

        }






    }
}
