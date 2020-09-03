using System;
using System.Collections.Generic;

namespace LibraryProgram
{
    class Program
    {
        public static Library<Book> Library { get; set; }
        public static Library<Book> BookBag { get; set; }

        static void Main(string[] args)
        {
            Console.Clear();
            UserInterface();
        }

        static void UserInterface()
        {
            Library = new Library<Book>();
            StarterBooks();
            StartBookBag();

        start:
            Console.Clear();
            Console.WriteLine("Enter a number with the corresponding command; \n " +
                "1: View Book in Library, 2: Add a book, 3: Remove a book from library");
                // + ", 4: View Book Bag, 5: Borrow a Book, 6: Return a Book ");
            string input = Console.ReadLine();

            if (input == "1")
            {
                Console.Clear();
                Console.WriteLine("Books in Library: \n");
                LoadBooks();
                Console.WriteLine(" \nPress enter to return to the menu.");
                Console.ReadLine();
                goto start;
            }


            else if (input == "2")
            {
                Console.WriteLine("Enter book title:");
                string inputTitle = Console.ReadLine();

                Console.WriteLine("Enter Author first name:");
                string inputAuthorFirst = Console.ReadLine();

                Console.WriteLine("Enter Author last name:");
                string inputAuthorLast = Console.ReadLine();

                //int numPages = GetPages();

            getPages:
                Console.WriteLine("Enter number of pages:");
                string inputNumberOfPages = Console.ReadLine();
                int numberNumberOfPages;
                if (int.TryParse(inputNumberOfPages, out numberNumberOfPages))
                {
                    if (numberNumberOfPages < 0)
                    {
                        Console.WriteLine("Incorrect page length entered");
                        goto getPages;
                    }
                }

            getGenre:
                Console.WriteLine("Enter a number to assign a genre:");

                int counter = 1;
                foreach (Genre genre in Enum.GetValues(typeof(Genre)))
                    Console.WriteLine($"{counter++} : {genre}");
                string inputGenre = Console.ReadLine();

                int numberGenre = Convert.ToInt32(inputGenre);

                if (numberGenre < 0 || numberGenre > counter - 1)
                {
                    Console.WriteLine("Incorrect entery");
                    goto getGenre;
                }

                int genreNumber = numberGenre - 1;

                AddABook(inputTitle, inputAuthorFirst, inputAuthorLast, numberNumberOfPages, (Genre)genreNumber);

                Console.Clear();

                Console.WriteLine("Book added! Updated Library: ");
                LoadBooks();

                Console.WriteLine(" \nPress enter to return to the menu.");
                Console.ReadLine();

                goto start;
            }

            else if (input == "3")
            {
                Console.Clear();

                Console.WriteLine("Current library: ");
                LoadBooks();

                Console.WriteLine("Enter a book number to remove it: ");
                string remove = Console.ReadLine();
                int removeNumber = Convert.ToInt32(remove);
                Library.Remove(removeNumber);


                Console.Clear();

                Console.WriteLine("Book added! Updated Library: ");
                LoadBooks();

                Console.WriteLine(" \nPress enter to return to the menu.");
                Console.ReadLine();

                goto start;

            }

            //else if (input == "4")
            //{
            //    LoadBookBag();
            //}

            //else if (input == "5")
            //{
            //    BorrowBook();
            //}

            //else if (input == "6")
            //{
            //    ReturnBook();
            //}

            else
            {
                Console.WriteLine("Incorrect command. Press enter to try again.");
                Console.ReadLine();
                goto start;
            }
        }


        public static void AddABook(string title, string firstName, string lastName, int numberOfPages, Genre genre)
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

        static void StarterBooks()
        {
            AddABook("A Song of Ice and Fire", "George RR", "Martin", 694, Genre.Fantasy);
            AddABook("Shade's Children", "Garth", "Nix", 310, Genre.ScienceFiction);
            AddABook("Skelling", "David", "Almond", 176, Genre.ScienceFiction);

        }

        public static void BookBagStarter(string title, string firstName, string lastName, int numberOfPages, Genre genre)
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

            BookBag.Add(book);
        }

        static void StartBookBag()
        {
            BookBagStarter("Fight Club", "Chuck", "Palahniuk", 208, Genre.Fiction);
        }

        static int GetPages()
        {
                Console.WriteLine("Enter number of pages:");
                string inputNumberOfPages = Console.ReadLine();
                int numberNumberOfPages;
            if(int.TryParse(inputNumberOfPages, out numberNumberOfPages)){
                if (numberNumberOfPages < 0)
                {
                    Console.WriteLine("Incorrect page length entered");
                    GetPages();
                }
                return numberNumberOfPages;
            }

            else
            {
                Console.WriteLine("Incorrect page length entered");
                GetPages();
            }

            return numberNumberOfPages;
           
        }

        static void LoadBooks()
        { 
            int counter = 1;
            foreach (Book book in Library)
                Console.WriteLine($"{counter++} : {book.Title}, {book.Author.Name()}, {book.NumberOfPages}, {book.Genre}");
        }

        static void LoadBookBag()
        {
            int counter = 1;
            foreach (Book book in BookBag)
                Console.WriteLine($"{counter++} : {book.Title}, {book.Author.Name()}, {book.NumberOfPages}, {book.Genre}");
        }

        static void BorrowBook()
        {
            Dictionary<int, Book> books = new Dictionary<int, Book>();
            Console.WriteLine("Which book would you like to borrow");
            int counter = 1;
            foreach (var item in BookBag)
            {
                books.Add(counter, item);
                Console.WriteLine($"{counter++}. {item.Title} - {item.Author.FirstName} {item.Author.LastName}");

            }

            string response = Console.ReadLine();
            int.TryParse(response, out int selection);
            books.TryGetValue(selection, out Book returnedBook);
            Library.Remove(selection);
            BookBag.Add(returnedBook);
        }

        static void ReturnBook()
        {
            Dictionary<int, Book> books = new Dictionary<int, Book>();
            Console.WriteLine("Which book would you like to return");
            int counter = 1;
            foreach (var item in BookBag)
            {
                books.Add(counter, item);
                Console.WriteLine($"{counter++}. {item.Title} - {item.Author.FirstName} {item.Author.LastName}");

            }

            string response = Console.ReadLine();
            int.TryParse(response, out int selection);
            books.TryGetValue(selection, out Book returnedBook);
            BookBag.Remove(selection);
            Library.Add(returnedBook);
        }
    }
}
