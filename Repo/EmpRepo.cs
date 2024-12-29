using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using crud.Models;
using System.Net;

namespace crud.Repo
{
    public class EmpRepo
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ConnectionString);

        public List<Emp> getemplist()
        {
            List<Emp> emplist = new List<Emp>();
            SqlCommand cmd = new SqlCommand("GetEmp",con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                emplist.Add(new Emp
                {
                    id = Convert.ToInt32(dr["id"]),
                    Name = Convert.ToString(dr["Name"]),
                    Address = Convert.ToString(dr["Address"]),
                    Department = Convert.ToString(dr["Department"]),
                    Gender = Convert.ToString(dr["Gender"]),
                    Hobby = Convert.ToString(dr["Hobby"]),
                    doj = Convert.ToDateTime(dr["doj"])
                });
            }
            return emplist;
        }

        public bool InsertData(Emp emp)
        {
            int i;
            SqlCommand cmd = new SqlCommand("InsertEmp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", emp.Name);
            cmd.Parameters.AddWithValue("@Address", emp.Address);
            cmd.Parameters.AddWithValue("@Department", emp.Department);
            cmd.Parameters.AddWithValue("@Gender", emp.Gender);
            cmd.Parameters.AddWithValue("@Hobby", emp.Hobby);
            cmd.Parameters.AddWithValue("@doj", emp.doj);
            con.Open();
            i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateData(Emp emp)
        {
            int i;
            SqlCommand cmd = new SqlCommand("UpdateEmp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", emp.id);
            cmd.Parameters.AddWithValue("@Name", emp.Name);
            cmd.Parameters.AddWithValue("@Address", emp.Address);
            cmd.Parameters.AddWithValue("@Department", emp.Department);
            cmd.Parameters.AddWithValue("@Gender", emp.Gender);
            cmd.Parameters.AddWithValue("@Hobby", emp.Hobby);
            cmd.Parameters.AddWithValue("@doj", emp.doj);
            con.Open();
            i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteData(Emp emp)
        {
            int i;
            SqlCommand cmd = new SqlCommand("DeleteEmp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", emp.id);
            con.Open();
            i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}