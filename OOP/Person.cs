using System;

namespace Person
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        class Person
        {
            string Name;
            int Age;

            public Person(string name, int age)
            {
                this.Name = name;
                this.Age = age;
            }


        }


        class Child : Person
        {

            public Child(string name, int age) : base(name, age)
            {
            }
        }

        public class StartUp
        {
            public static void Main()
            {
                string name = Console.ReadLine();
                int age = int.Parse(Console.ReadLine());

                Child child = new Child(name, age);
                Console.WriteLine(child);
            }
        }


    }
}

