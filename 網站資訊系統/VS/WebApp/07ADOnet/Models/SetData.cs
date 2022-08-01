using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace _07ADOnet.Models
{
    public class SetData
    {
        static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["aaa"].ConnectionString);
        SqlCommand cmd = new SqlCommand("", conn);
        public void executeSql(string sql)
        {
            //***如果用Sqlcommannd，一定要把連線打開再關掉conn.Open()+conn.Close()
            
            cmd.CommandText = sql;

            conn.Open();

            cmd.ExecuteNonQuery();
            cmd.Dispose();

            conn.Close();
        }
        public void executeSql(string sql, List<SqlParameter> list)
        {
            cmd.CommandText = sql;
            foreach (SqlParameter p in list)
            {
                cmd.Parameters.Add(p);
            }

            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            conn.Close();


        }

    }
    
}