﻿namespace LibraryProgram
{
    public class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Name => $"{FirstName} {LastName}";
    }
}