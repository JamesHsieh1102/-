using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    
    internal class 委派
    {
        delegate string PrintPattern(int n);
        static void Main(string[] args)
        {
            PrintPattern printPattern = n =>new string('*', n);
            int rows = 5;
            /*
            for (int i = 1; i <= rows; i++)//靠左三角形
            {  
                Console.WriteLine(printPattern(i));
            }*/
            
            for(int i = 1; i <= rows; i++){//靠右三角形
                string pattern = printPattern(i).PadLeft(5);
                Console.WriteLine(pattern);
            }

            for(int i = 1; i <= rows; i++)  {//等腰三角形
                Console.WriteLine($"{new string(' ',rows-i)}{printPattern(2*i-1)}");
            }

        }

        
    }
}
