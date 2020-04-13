using System;

namespace pchatApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Student a = new Student("Student");
            Teacher b = new Teacher("Teacher");

            while(a.sendMessage() != "bye" && b.sendMessage() != "bye")
            {
                Chat.Message(a, b);
            }
        }
    }
}
