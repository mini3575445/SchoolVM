using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _0623Form.Models
{
    public class Student
    {
        [Required]
        [RegularExpression("[AB][0-9]{3}")]
        public string id { get; set; }
        public string name { get; set; }
        public int score { get; set; }


        public Student()
        {
            id = string.Empty;
            name = string.Empty;
            score = 0;
        }
        public Student(string _id, string _name, int _score)
        {
            id = _id;
            name = _name;
            score = _score;
        }
        public override string ToString()
        {
            return $"學號:{id}, 姓名:{name}, 分數:{score}.";
        }
    }
}