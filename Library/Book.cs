using System;
namespace LibraryProgram
{
    class Book
    {
        public string Title { get; set; }

        public Author Author { get; set; }

        public int NumberOfPages { get; set; }

        public Genre Genre { get; set; }
    }

    enum Genre
    {
        Mystery,
        Fantasy,
        Nonficiton,
        ComicBook,
        ScienceFiction

    }
}
