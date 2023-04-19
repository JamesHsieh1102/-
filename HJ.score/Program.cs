using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;

namespace HJ.score {
    internal class Program {
        static void Main(string[] args)
        {
            Student student = new Student();
            Input(student);
            //student.Name = "James";
            //student.Age = 27;
            //student.MathGrade = 95;
            //student.EnglishGrade = 93;
            //student.ChineseGrade = 96;

            Console.WriteLine(student.GetInfo());

        }
        private static void Input(Student inputStudent)
        {
            string[] arrayInput = new string[inputStudent.array.Length];
            for (int i = 0; i < inputStudent.array.Length; i++) {
                Console.WriteLine("請輸入學生的" + inputStudent.array[i]);
                arrayInput[i] = Console.ReadLine();
                if (!FoolProof(arrayInput[i])) {
                    i--;
                    continue;
                }
                FoolProof(arrayInput[i]);
            }
            inputStudent.InputAll(arrayInput);


            //inputStudent.Name = Console.ReadLine(); 
        }

        private static bool FoolProof(string array)
        {
            int number;

            if (int.TryParse(array, out number))
            {
                if (number < 0 || number > 100)
                {
                    Console.WriteLine("數字不能為小於0或大於100");
                    return false;
                }
            }
            if (string.IsNullOrEmpty(array) || string.IsNullOrWhiteSpace(array))
            {
                Console.WriteLine("輸入不能為空白或NULL");
                return false;
            }
            return true;
        }        
        }
        
        public class Student {

            public string[] array = { "名字", "年齡", "數學成績", "國文成績", "英文成績","物理成績" };
            public string Name { get; set; }
            public int Age { get; set; }
            public int MathGrade { get; set; }
            public int EnglishGrade { get; set; }
            public int ChineseGrade { get; set; }
            public int Physics { get; set; }
            public int Total { get => EnglishGrade + MathGrade + ChineseGrade; }
            public double Average { get => Total / 3.0; }

            public void InputAll(string[] test)
            {
                this.Name = test[0];
                this.Age =  int.Parse(test[1]);
                this.MathGrade = int.Parse(test[2]);
                this.ChineseGrade = int.Parse(test[3]);
                this.EnglishGrade = int.Parse(test[4]);
                this.Physics = int.Parse(test[5]);
            }

            public string[] arrayInput = {"Name","Age","MathGrade","EnglishGrade","ChineseGrade"};
            public string GetInfo()
            {
                return Total >= 180 ? PassMessage() : FailMessage();
            }
            private string PassMessage()
            {
                string pass = "本次考試及格";
                string temp = "學生:{0},國文成績:{1},數學成績:{2},英文成績:{3},總分:{4},平均分數:{5},考試結果:{6}";
                string message = string.Format(temp, Name, ChineseGrade, MathGrade, EnglishGrade, Total, Average, pass);
                return message;
            }
            private string FailMessage()
            {
                string fail = "本次考試不及格";
                string temp = "學生:{0}\n國文成績:{1}\n數學成績:{2}\n英文成績:{3}\n總分:{4}\n平均分數:{5}考試結果:{6}";
                string message = string.Format(temp, Name, ChineseGrade, MathGrade, EnglishGrade, Total, Average, fail);
                return message;
            }

        }
    
}
