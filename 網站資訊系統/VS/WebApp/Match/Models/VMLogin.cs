using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Match.Models
{
    public class VMLogin
    {
        [DisplayName("帳號")]
        [RegularExpression("^[A-Za-z0-9]{6,30}$")]
        public string member_account { get; set; }

        [DisplayName("密碼")]
        [RegularExpression("^[A-Za-z0-9]{6,30}$")]
        [DataType(DataType.Password)]
        public string member_password { get; set; }
    }
}