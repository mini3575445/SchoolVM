using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HW7Project.Models
{
    public class PayTypes
    {
        [Key]
        public int PayTypeID { get; set; }

        [DisplayName("付款方式")]
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(10, ErrorMessage = "長度不超過10字元")]
        public string PayTypeName { get; set; }
    }
}