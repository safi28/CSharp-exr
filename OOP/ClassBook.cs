using System;

namespace Book
{

   public class Book
    {
        private string library;
        private string author;
        private string title;
        private decimal price;

        private static decimal totalPrice = 0;
        private static int bookCount = 0;

        public Book(string library, string author, string title, decimal price)
        {
            this.library = library;
            this.author = author;
            this.title = title;
            this.price = price;
            totalPrice += price;
            bookCount++;
        }

        public string Library
        {
            get { return this.library; }
            set { this.library = value; }
        }
        public string Author
        {
            get { return this.author; }
            set { this.author = value; }
        }
        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }
        public decimal Price
        {
            get { return this.price; }
            set {
                if (value <= 0.00m)
                {
                    Console.WriteLine("Invalid input!");
                }
                this.price = value;
            }
        }

        public void PrintBooks(string label)
        {
            Console.WriteLine($"{label}");
            Console.WriteLine($"Library: {this.library}");
            Console.WriteLine($"Author: {this.author}");
            Console.WriteLine($"Title: {this.title}");
            Console.WriteLine($"Price: {this.price}");

        }

        public void CurrentTotalPrice()
        {
            Console.WriteLine($"Count books: {bookCount}\nTotal price: {totalPrice} lv.");
        }
    }
   public class BookInfo {
        public void ShowBookInfo(Book myBook)
        {
        Console.WriteLine($"Book info title: {myBook.Title}, Book info price {myBook.Price}");
        }
   }
    class Program
    {
        static void Main(string[] args)
        {
            Book firstBook = new Book("UNIBIT", "Ivan", "Edu", 23.00m);
            Book secondBook = new Book("UNI", "Mariq", "Moodle", 28.00m);
            BookInfo info = new BookInfo();
            info.ShowBookInfo(firstBook);
            info.ShowBookInfo(secondBook);
            firstBook.Price = 0.00m;
            secondBook.Price -= -11.00m;
            info.ShowBookInfo(firstBook);
            info.ShowBookInfo(secondBook);
        }
    }
}
