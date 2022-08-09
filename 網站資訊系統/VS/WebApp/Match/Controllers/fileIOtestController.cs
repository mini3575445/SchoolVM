using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Match.Controllers
{
    public class fileIOtestController : Controller
    {
        // GET: test
        public void Index()
        {

            string path = @"D:\SchoolVM\網站資訊系統\VS\WebApp\testfile.txt";
            // This text is added only once to the file.
            if (!System.IO.File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = System.IO.File.CreateText(path))
                {
                    sw.WriteLine("Hello");
                    sw.WriteLine("And");
                    sw.WriteLine("Welcome");
                }
            }

            // This text is always added, making the file longer over time
            // if it is not deleted.
            using (StreamWriter sw = System.IO.File.AppendText(path))
            {
                sw.WriteLine("中文可以寫");
                sw.WriteLine("希望");
                sw.WriteLine("Text");
            }

        }
    }
}