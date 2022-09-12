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
        public void Write()
        {

            string path = @"D:\SchoolVM\網站資訊系統\VS\WebApp\Match\testfile.txt";
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
                sw.WriteLine("2022-9-12 00:00:00　來我家看貓貓後空翻：測試123");
                sw.WriteLine("希望");
                sw.WriteLine("Text");
            }

        }

        public String Read()
        {

            string path = @"D:\SchoolVM\網站資訊系統\VS\WebApp\Match\testfile.txt";


            String result = "";

            using (StreamReader sr = new StreamReader(path))
            {
                String line;
                // Read and display lines from the file until the end of
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    result = result + line + "<br>";
                }
            }

            return result;
        }

    }
}