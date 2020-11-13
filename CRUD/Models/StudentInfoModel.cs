using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace CRUD.Models
{
    public class StudentInfoModel : BaseService
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string address { get; set; }
        public string contact { get; set; }

        public bool InsertStudent(StudentInfoModel model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(this.ConnectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand("StudentInfoInsert_SP", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@first_name", model.first_name));
                cmd.Parameters.Add(new SqlParameter("@last_name", model.last_name));
                cmd.Parameters.Add(new SqlParameter("@address", model.address));
                cmd.Parameters.Add(new SqlParameter("@contact", model.contact));

                cmd.ExecuteNonQuery();
                conn.Close();

                return true;
            }
            catch(Exception exp)
            {
                return false;
            }
        }

        public bool UpdateStudent(StudentInfoModel model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(this.ConnectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand("StudentInfoUpdate_SP", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@id", model.id));
                cmd.Parameters.Add(new SqlParameter("@first_name", model.first_name));
                cmd.Parameters.Add(new SqlParameter("@last_name", model.last_name));
                cmd.Parameters.Add(new SqlParameter("@address", model.address));
                cmd.Parameters.Add(new SqlParameter("@contact", model.contact));

                cmd.ExecuteNonQuery();
                conn.Close();

                return true;
            }
            catch(Exception exp)
            {
                return false;
            }
        }

        public bool DeleteStudent(int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(this.ConnectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand("StudentInfoDelete_SP", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@id", id));
                
                cmd.ExecuteNonQuery();
                conn.Close();

                return true;
            }
            catch (Exception exp)
            {
                return false;
            }
        }

        public List<StudentInfoModel> GetStudentList()
        {
            try
            {
                SqlConnection conn = new SqlConnection(this.ConnectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand("StudentInfoSelect_SP", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                List<StudentInfoModel> studentInfoModels = new List<StudentInfoModel>();
                IDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    StudentInfoModel model = new StudentInfoModel();
                    model.id = this.StringToInt(reader["id"].ToString());
                    model.first_name = reader["first_name"].ToString();
                    model.last_name = reader["last_name"].ToString();
                    model.contact = reader["contact"].ToString();
                    model.address = reader["address"].ToString();
                    studentInfoModels.Add(model);
                }

                reader.Close();
                conn.Close();

                return studentInfoModels;
                
            }
            catch(Exception exp)
            {
                return null;
            }
        }

        public StudentInfoModel GetStudentDetails(int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(this.ConnectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand("StudentInfoSelect_SP", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@id", id));

                StudentInfoModel model = new StudentInfoModel();
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    model.id = this.StringToInt(reader["id"].ToString());
                    model.first_name = reader["first_name"].ToString();
                    model.last_name = reader["last_nae"].ToString();
                    model.contact = reader["contact"].ToString();
                    model.address = reader["address"].ToString();
                }

                reader.Close();
                contact.Clone();

                return model;

            }
            catch (Exception exp)
            {
                return null;
            }
        }
    }
}