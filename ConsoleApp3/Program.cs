using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student james = new Student();
            james.Name = "James";
            james.Age = 27;
            james.MathGrade = 100;
            james.EnglishGrade = 90;
            james.ChineseGrade = 85;

            Console.WriteLine(james.GetInfo());

        }

        public class Student
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public int MathGrade { get; set; }
            public int EnglishGrade { get; set; }

            public int ChineseGrade { get; set; }
            public string GetInfo()
            {
                if (MathGrade + EnglishGrade + ChineseGrade >= 180)
                {
                    return PassMessage();
                }
                else
                {
                    return FailMessage();
                }
            }


            private string PassMessage()
            {
                int accounts = MathGrade + EnglishGrade + ChineseGrade;
                int avg = accounts / 3;
                string pass = "本次考試及格";
                string tempt = "你好，我是{0}，我的年齡是{1}，我的數學成績是{2}，我的英文成績是{3}，我的國文成績是{4}，平均分數{5}，{6}";
                string message = string.Format(tempt, Name, Age, MathGrade, EnglishGrade, ChineseGrade, avg, pass);
                return message;
            }
            private string FailMessage()
            {
                int accounts = MathGrade + EnglishGrade + ChineseGrade;
                int avg = accounts / 3;
                string fail = "本次考試不及格";
                string tempt = "你好，我是{0}，我的年齡是{1}，我的數學成績是{2}，我的英文成績是{3}，我的國文成績是{4}，平均分數{5}，{6}";
                string message = string.Format(tempt, Name, Age, MathGrade, EnglishGrade, ChineseGrade, avg, fail);
                return message;
            }
        }

    }
}

