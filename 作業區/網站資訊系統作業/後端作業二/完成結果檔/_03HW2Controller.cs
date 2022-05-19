using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSharp.Controllers
{
    public class _03HW2Controller : Controller
    {
        //for寫法 
        public string Q1(int num)
        {
            for (int i =2; i<num; i++)
            {
                if (num % i==0) return num+"不是質數";                
            }
            return num + "是質數";
        }
        //while寫法 (旗標控制)
        
        //迴圈原則:成立的話做XXX就用While，其他就用For，避免用While迴圈產生邏輯謬誤
        

        //////////////////////////////////////////
        //迴圈寫法
        public void Q2(int n1,int n2)
        {
            Boolean change = false;
            //把大的數字丟到n1
            if (n1<n2)
            {
                n1 = n1 + n2;
                n2 = n1 - n2;
                n1 = n1 - n2;
                change = true;
            }
            //尋找公因數
            for (int i =n1-1; i>=1; i--)
            {                
                if (n1%i == 0 && n2 % i==0)                    
                {                    
                    if (change== true) { 
                    Response.Write(n2+"及"+n1+"之最大公因數為" + i);
                    break;
                    }
                    else                        
                    Response.Write(n1 + "及" + n2 + "之最大公因數為" + i);
                    break;                        
                }                
            }
        }
        //輾轉相除法
        public void Q22(int n1,int n2)
        {
            int X = n1;
            int Y = n2;
            int mod = 1;
            while (mod != 0) { 
            mod = n1 % n2;

            n1 = n2;
            n2 = mod;
            }
            Response.Write(X+"及"+Y+"之最大公因數:"+n1);
        }
        public void Q3(int n)
        {
            int N = n;
            int m = 0;
            int result = 0;            
            //判斷數值n的長度
            int len = 0;
            while (n > 0)
            {
                n /= 10;
                len++;               
            }
            n = N;
            //抓倒過來的數值
            for (int i = 0; i < len; i++)
            {
                m = n % 10;
                result = result * 10 + m;                 
                n = n / 10;
            }
            //判斷回文
            if (N==result) Response.Write(N+"是回文");
            else Response.Write(N + "不是回文");
        }
    }
}