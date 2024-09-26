using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace multiuser
{
    public class Class1
    {
        SqlConnection con;
        SqlCommand cmd;

        public Class1()
        {
            con = new SqlConnection(@"server=MSI\SQLEXPRESS;database=luminar1;integrated security=true");
        }
        public int Fn_NonQuery(string sql)
        {
            cmd = new SqlCommand(sql, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public string Fn_Scalar(string sql)
        {
            cmd = new SqlCommand(sql, con);
            con.Open();
            string s = cmd.ExecuteScalar().ToString();
            con.Close();
            return s;

        }
    }
    
}