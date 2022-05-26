using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _001controller.Models
{
    //把class類別看成資料表
    
    public class Product    //產品實體    
    {
        public string PId { get; set; } //品號屬性     //類似宣告變數，前面加修飾詞，大括號裡面是"封裝"
        public string PName { get; set; } //品名屬性
        public int Price { get; set; }  //價格屬性
    }
}