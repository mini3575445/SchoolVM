using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _0622.Models
{
    public class Student
    {
        public string id { get; set; }
        public string name { get; set; }
        public int score { get; set; }


        //預設建構子
        public Student() {
            id = "";
            name = "";
            score = 0;            
        }

        //第二個建構子，這樣就是多載，Student方法有兩種使用方式
        public Student(string _id , string _name , int _score)
        {
            id = _id;
            name = _name;
            score = _score;
        }


        //修飾詞override，***覆蓋繼承Object.ToString()這個內建方法
        //所有的class都是繼承Object class
        public override string ToString() 
        {
            //$，C#6新寫法，相當於以前的string.Format:
            //return String.Format("id={0}，name={1}，score={2}",id,name,score);
            return $"學號:{id}, 姓名:{name}, 分數:{score}.";
        }

    }
}