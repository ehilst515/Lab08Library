using System;


namespace LibraryProgram
{
    class Program
    {
        public static Library<Book> Library { get; set; }
        public static Library<Book> BookBag { get; set; }

        static void Main(string[] args)
        {
            Library = new Library<Book>();

            start:

            Console.WriteLine("Welcome to the library!");
            Console.WriteLine("Enter a number with the corresponding command; 1: View Books, 2: Add a book");
            string input = Console.ReadLine();

            if (input == "1")
            {
                LoadBooks();
                goto start;
            }


            if (input == "2")
            {
                Console.WriteLine("Enter book title:");
                string inputTitle = Console.ReadLine();

                Console.WriteLine("Enter Author first name:");
                string inputAuthorFirst = Console.ReadLine();

                Console.WriteLine("Enter Author last name:");
                string inputAuthorLast = Console.ReadLine();

                Console.WriteLine("Enter number of pages:");
                string inputNumberOfPages = Console.ReadLine();
                int numberNumberOfPages = Convert.ToInt32(inputNumberOfPages);

                Console.WriteLine("Enter number genre:");
                string inputGenre = Console.ReadLine();
                int numberGenre = Convert.ToInt32(inputGenre);

                AddABook(inputTitle, inputAuthorFirst, inputAuthorLast, numberNumberOfPages, Genre.Fantasy);

                Console.Clear();

                Console.WriteLine("Book added! Updated Library: ");
                LoadBooks();

                goto start;
            }

            Console.ReadLine();

        }

        //static string UI()
        //{
        //    Console.WriteLine("Welcome to the library!");
        //    Console.WriteLine("Enter a number with the corresponding command; 1: View Books, 2: Add a book");
        //    string input = Console.ReadLine();

        //    return input;

        //}

        static void AddABook(string title, string firstName, string lastName, int numberOfPages, Genre genre)
        {
            Book book = new Book()
            {
                Title = title,
                Author = new Author(firstName, lastName)
                {
                    FirstName = firstName,
                    LastName = lastName
                },
                NumberOfPages = numberOfPages,
                Genre = genre
            };

            Library.Add(book);
        }

        static void LoadBooks()
        {
            AddABook("A Song of Ice and Fire", "George RR", "Martin", 694, Genre.Fantasy);
            AddABook("Shade's Children", "Garth", "Nix", 310, Genre.ScienceFiction);
            AddABook("Skelling", "David", "Almond", 176, Genre.ScienceFiction);

            int counter = 1;
            foreach (Book book in Library)
                Console.WriteLine($"{counter++} : {book.Title}, {book.Author.Name()}, {book.NumberOfPages}, {book.Genre}");
        }


        //static void ReturnBook()
        //{
        //    Dictionary<int, Book> books = new Dictionary<int, Book>();
        //    Console.WriteLine("Which book would you like to return");
        //    int counter = 1;
        //    foreach (var item in BookBag)
        //    {
        //        books.Add(counter, item);
        //        Console.WriteLine($"{counter++}. {item.Title} - {item.Author.FirstName} {item.Author.LastName}");

        //    }

        //    string response = Console.ReadLine();
        //    int.TryParse(response, out int selection);
        //    books.TryGetValue(selection, out Book returnedBook);
        //    BookBag.Remove(returnedBook);
        //    Library.Add(returnedBook);
        //}
    }
}
