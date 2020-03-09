using System;

namespace ClassStudent
{
    class Student
    {
        private decimal[] grades;

        public Student(int fNum, string names, string discipline, decimal[] grades)
        {
            this.FNum = fNum;
            this.Names = names;
            this.Discipline = discipline;
            this.Grades = grades;
        }
        
        public int FNum { get; set; }
        public string Names { get; set; }
        public string Discipline { get; set; }
        public decimal[] Grades
        {
            get
            {
                return this.grades;
            }
            set
            {
                this.grades = value;
            }
        }

        public decimal GetAvarageGrade()
        {
            decimal sum = 0;
            for(int i = 0; i < this.grades.Length; i++)
            {
                sum += this.grades[i];
            }
            decimal result = sum / this.grades.Length;
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var student = new Student(432, "Saphie Hanadi", "OOP", null);
            Console.Write($"Please enter count available grades\nin {student.Discipline} for {student.Names}");
            int n = int.Parse(Console.ReadLine());
            decimal[] array = new decimal[n];
            student.Grades = array;
            for(int i = 0; i < array.Length; i++)
            {
                Console.Write($"Please enter grade {i + 1}: ");
                array[i] = decimal.Parse(Console.ReadLine());
                if(array[i] > 6.0M || array[i] < 2.0M)
                {
                    Console.WriteLine("Please enter grade between 2 and 6: ");
                    i--;
                }
            }
            var studentAvrgGrade = student.GetAvarageGrade();
            Console.WriteLine();
            Console.WriteLine($"Avarage grade for {student.Names}\nin {student.Discipline} is {student.GetAvarageGrade().ToString("N2")}");
        }
    }
}
