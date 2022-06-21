using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _0622.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public class Student
        {
            public string id { get; set; }
            public string name { get; set; }
            public int score { get; set; }

            //定義兩個建構子
            //第一個:預設建構子
            public Student()
            {   //id = String.Empty;與id="";差不多
                id = String.Empty;
                name = String.Empty;
                score = 0;
            }
            //第二個建構子
            public Student(string _id, string _name, int _score)
            {
                id = _id;
                name = _name;
                score = _score;
            }
            //若沒有這個建構子就要這樣:
            //Student student = new Student();
            //student.id = "1";
            //student.name = "小明";
            //student.score = 80;




            //修飾詞override，覆蓋繼承
            public override string ToString()
            {
                //$，C#6新寫法，相當於以前的string.Format 
                return $"學號:{id}, 姓名:{name}, 分數:{score}.";
            }

        }
        public ActionResult Index()
        {
            DateTime date = DateTime.Now;
            Student data = new Student();
            List<Student> list = new List<Student>();
            list.Add(new Student("1", "小明", 80));
            list.Add(new Student("2", "小華", 70));
            list.Add(new Student("3", "小英", 60));
            list.Add(new Student("4", "小李", 50));
            list.Add(new Student("5", "小張", 90));

            ViewBag.Date = date;
            ViewBag.Student = data;
            ViewBag.List = list;
            return View();
        }
    }
}