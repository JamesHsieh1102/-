using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace 輸入成績
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            while (true)
            {
                Console.WriteLine("請輸入學生的姓名(Enter 結束) :");
                string name = Console.ReadLine();
                if (string.IsNullOrEmpty(name)) { break; }

                Console.WriteLine("請輸入國文成績:");
                int chineseGrade = int.Parse(Console.ReadLine());

                Console.WriteLine("請輸入英文成績:");
                int englishGrade = int.Parse(Console.ReadLine());

                Console.WriteLine("請輸入數學成績:");
                int mathGrade = int.Parse(Console.ReadLine());

                students.Add(new Student { Name = name, ChineseGrade = chineseGrade, EnglishGrade = englishGrade, mathGrade = mathGrade });

                foreach (var student in students)
                {
                    Console.WriteLine($"{student.Name}的平均分數是{student.Average}，總分是{student.Total}");
                }

                //var studentSorted = students.OrderByDescending(s => s.Total);

                Console.WriteLine("排序後的結果如下:");
                students = students.OrderByDescending(s => s.Total).ToList();
                foreach (var student in students)
                {
                    Console.WriteLine($"{student.Name}\t 國文:{student.ChineseGrade}\t 數學:{student.mathGrade}\t英文{student.EnglishGrade}\t總分:{student.Total}\t 平均分數:{student.Average}");
                }


            }
        }

        class Student
        {
            public string Name { get; set; }
            public int ChineseGrade { get; set; }
            public int EnglishGrade { get; set; }
            public int mathGrade { get; set; }
            public int Total { get { return ChineseGrade + EnglishGrade + mathGrade; } }
            public double Average { get => Total / 3.0; } }
        }
    }
