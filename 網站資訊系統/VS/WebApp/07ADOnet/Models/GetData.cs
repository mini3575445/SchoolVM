using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Configuration; //讀Web.config的資料
using System.Data;  //DataSet

namespace _07ADOnet.Models
{
    

    public class GetData
    {
        static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["aaa"].ConnectionString);//指定連線資訊，Web.config
        SqlDataAdapter adp = new SqlDataAdapter("", conn);    //做CRUD，這邊字串錯誤的話會報例外
                                           //第二個參數是SqlConnection
        DataSet ds = new DataSet();//記憶體的資料集
        DataTable dt = new DataTable();


        /// <summary>
        /// 傳入SelectCommad或SP名稱,可自行取DataTable名稱
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmt"></param>
        /// <returns></returns>
        public DataTable querySql(string sql, CommandType cmt) 
        {
            adp.SelectCommand.CommandType = cmt;
            adp.SelectCommand.CommandText = sql;    //將字串傳入
            adp.Fill(ds);//把資料存到記憶體的資料集
                         //第二個參數為資料表名稱
            dt = ds.Tables[0];
            //dt = ds.Tables["students"]
            return dt;
        }
        public DataTable querySql(string sql, CommandType cmt,String dtName)
        {
            adp.SelectCommand.CommandType = cmt;
            adp.SelectCommand.CommandText = sql;    //將字串傳入
            adp.Fill(ds,dtName);//把資料存到記憶體的資料集
                         //第二個參數為資料表名稱
            dt = ds.Tables[dtName];
            //dt = ds.Tables["students"]
            return dt;
        }

        public DataTable querySql(string sql, CommandType cmt, string id, string name)
        {
            adp.SelectCommand.Parameters.AddWithValue("@id", id);
            adp.SelectCommand.Parameters.AddWithValue("@name", name);


            adp.SelectCommand.CommandType = cmt;
            adp.SelectCommand.CommandText = sql;
            adp.Fill(ds);
            dt = ds.Tables[0];

            return dt;
        }

    }
}