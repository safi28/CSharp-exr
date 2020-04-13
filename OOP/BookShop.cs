using System;

namespace BookShop
{
    public class Book
    {
        private string library;
        private string author;
        private string title;
        private decimal price;

        private static decimal totalPrice = 0;
        private static int counter = 0;

        public Book() { }

        public Book(string library, string author, string title,  decimal price)
        {
            this.library = library;
            this.author = author;
            this.title = title;
            this.price = price;

            totalPrice += price;
            counter++;
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
                if (value < 0.00m) {
                    new ArgumentException("Price should be postive number!");
                    Console.WriteLine("Invalid price!");
                }
                this.price = value;
            }
        }
        public void PrintBook(string label)
        {
            Console.WriteLine($"{label}");
            Console.WriteLine($"Library: {this.library}");
            Console.WriteLine($"Author: {this.author}");
            Console.WriteLine($"Title: {this.title}");
            Console.WriteLine($"Price {this.price}");
        }

        public static void CurrentTotalPrice()
        {
            Console.WriteLine($"Total books: {counter}: Price - {totalPrice}");
        }
    }
    public class BookShop
    {
        private static readonly int capacity = int.Parse(Console.ReadLine());
        decimal clientSum = 0;
        private string name;
        private Book[] books;
        public BookShop()
        {
            this.name = "Orange";
            books = new Book[capacity];
            
        }
        public BookShop(string name)
        {
            this.name = name;
            this.books = new Book[capacity];
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public void AddBook(Book book, int i)
        {
            books[i] = book;
        }
        
        public void ShowBooks(BookShop objShop)
        {
            name = objShop.Name;
            Console.WriteLine($"Shop Name: {name}");
            foreach(Book book in objShop.books)
            {
                Console.WriteLine($"Library: {book.Library}, Title: {book.Title}, Author: {book.Author}, Price: {book.Price}");
            }
        }
        public void PushNextBook()
        {
            for(int i = 0; i < capacity; i++)
            {
                Book inserBook = new Book();

                Console.WriteLine("Enter Library:");
                inserBook.Library = Console.ReadLine();
                Console.WriteLine("Enter Title:");
                inserBook.Title = Console.ReadLine();
                Console.WriteLine("Enter Author:");
                inserBook.Author = Console.ReadLine();
                Console.WriteLine("Enter Price:");
                inserBook.Price = decimal.Parse(Console.ReadLine());

                AddBook(inserBook, i);
            }
        }
        public void SearchBook()
        {
            Console.WriteLine("Wanna buy a book?");
            var answer = Console.ReadLine();
            if(answer == "yes") {
                Console.WriteLine("What is the title of the book you are looking for?");
                string wantedBook = Console.ReadLine();
                var exist = 0;
                for (int y = 0; y < capacity; y++)
                {
                    var book = books[y].Title;
                    var price = books[y].Price;
                    exist = book.IndexOf(wantedBook);

                    if (book == wantedBook)
                    {
                        Console.WriteLine("We have this book in our store.");
                            clientSum += price;
                           // books[y].Price += price;                          
                            Console.WriteLine("Successfully bought book!");
                       
                    } 

                }
                if(exist == -1)
                {
                    Console.WriteLine("Sorry we dont have this book!");
                }
                
            }

        }
        public void InfoBookShop(BookShop objShop)
        {
            decimal total = 0;
            decimal sum = 0;
            foreach(Book book in objShop.books)
            {
                total += book.Price;
                if(total >= clientSum)
                {
                  sum = total - clientSum;
                } else
                {
                    sum = clientSum - total;
                }
                
            }
            Console.WriteLine("**************");
            Console.WriteLine($"Total price for the left books in store: {sum}");
            Console.WriteLine($"Sum for the client: {clientSum}");
        }

        
    }

    public class BookRegister
    {
       
        private static readonly int capacity = 3;

        private object[] booksArr;
        private int counter;

        public int Count
        {
            get { return counter; }
        }

        public BookRegister()
        {
            booksArr = new object[capacity];
            counter = 0;
        }

        public object this[int index]
        {
            get
            {
                if(index > counter || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid index:" + index);
                }
                return booksArr[index];
            }
            set
            {
                if(index > counter || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid index:" + index);
                }
                 booksArr[index] = value;
            }
        }

        public void Add(object item)
        {
            Insert(counter, item);
        }

        public void Insert(int index, object item)
        {
            if (index > counter || index < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid index:" + index);
            }
            object[] extendArr = booksArr;
            if(counter+1 == booksArr.Length)
            {
                extendArr = new object[booksArr.Length * 2];
            }
            Array.Copy(booksArr, extendArr, index);
            counter++;
            extendArr[index] = item;
            booksArr = extendArr;
        }
        public void PrintBooks(BookRegister listBook)
        {
            foreach(Book item in listBook.booksArr)
            {
                if(item != null)
                {
                    Console.WriteLine($"Title: {item.Title} --- Price: {item.Price}");
                } else
                {
                    Console.WriteLine("Invalid element!");
                }
            }
        }
        public int BookIndexOf(object item)
        {
            for(int i = 0; i < booksArr.Length; i++)
            {
                if(item == booksArr[i])
                {
                    return i;
                }
            }
            return -1;
        }
        public bool Contains(object item)
        {
            int index = BookIndexOf(item);
            bool found = (index != -1);
            return found;
        }
        public void Clear()
        {
            booksArr = new object[capacity];
            counter = 0;
            Console.WriteLine("The register is cleared!");
        }
        public object RremoveBookIndex(int index)
        {
            if(index > counter || index < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid index" + index);
            }
            object item = booksArr[index];
            Array.Copy(booksArr, index + 1, booksArr, index, counter - index + 1);
            booksArr[counter - 1] = null;
            counter--;
            return item;
        }
        public int RemoveBook(object item)
        {
            int index = BookIndexOf(item);
            if(index == -1)
            {
                return index;
            }
            Array.Copy(booksArr, index + 1, booksArr, index, counter - index + 1);
            counter--;
            return index;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            BookRegister register = new BookRegister();
            Book firstBook = new Book { Library = "Library 1", Author = "Stephen", Title = "Somewhere", Price = 22.12m };
            Book secondBook = new Book { Library = "Library 2", Author = "John", Title = "Where", Price = 10.12m };
            Book thirdBook = new Book { Library = "Library 3", Author = "Ellen", Title = "Go", Price = 12.12m };

            register.Add(firstBook);
            register.Add(secondBook);
            register.Add(thirdBook);
            Console.WriteLine("Test registration:");
            register.PrintBooks(register);

            register[1] = new Book { Library = "Library 4", Author = "Carl", Title = "OOP", Price = 2.12m };
            Console.WriteLine("Remove array object by index:");
            register.RemoveBook(thirdBook);
            Console.WriteLine("Test removed book by index");
            register.BookIndexOf(1);
            Console.WriteLine("Final registration");
            register.PrintBooks(register);

        }
    }
}
