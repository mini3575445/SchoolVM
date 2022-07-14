using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSharp.Controllers
{
    public class _03HW2Controller : Controller
    {
       
        public string No1(int n)
        {
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                    return n + "不是質數";
                }
            }

            return n + "是質數";

        }

        public string No2(int n,int m)
        {
            int M = m, N = n;
            int z = 0;//這個變數來放餘數

            while(M % N!=0)
            {
                z = M % N;
                M = N;
                N = z;
            }

            return m+"與"+n+"之最大公因數為"+N; 
        }

        public string No3(int n)
        {
            int N = n, result = 0;
            int q = 0, r = 0;


            do
            {
                r = N % 10;
                q = N / 10;
                N = q;

                result *= 10;
                result += r;
            } while (q != 0) ;

            if(n==result)
                return n+"是迴文";

            return n + "不是迴文";
        }
    }
}