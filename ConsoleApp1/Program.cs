using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class 使用Func
    {
        static void Main(string[] args)
        {
            Func<int, string> printFunc = x => new string('*', x);
            int rows = 5;

           
            
            //for (int i = 1; i <= rows; i++) //靠左三角形
            //{
            //    string stars = printFunc(i).PadLeft(5);
            //    Console.WriteLine(stars);
            //}
            //for(int i = 1; i <= rows; i++)//靠右三角形
            //{
            //    Console.WriteLine(printFunc(i));
            //}
            for(int i = 1; i <= rows; i++)//等腰三角形
            {
                Console.WriteLine($"{new string(' ',rows-i)}{printFunc(2*i-1)}");
            }

        }
        
    }
}
