﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Match.Controllers
{
    /// <summary>
    /// 主要功能為自動編碼ID(抓DB最後一筆資料);
    /// idIn，db裡面的ID最後一碼;
    /// data，ID第一碼的英文
    /// </summary>
    /// <param name="idIn">db裡面的ID最後一碼</param>
    /// <param name="data">ID第一碼的英文</param>
    /// <returns></returns>
    public class ChangeIDAuto
    {
        public string ChangeIDNumber(string idIn, string data) 
        {
            int id = Int32.Parse(idIn.Substring(2)) + 1;
            string CheckID = data + id.ToString().PadLeft(4, '0');
            return CheckID;
        }
    }
}