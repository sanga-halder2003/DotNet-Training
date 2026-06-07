using LibraryManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Models
{
    public class Librarian:ILibrarian
    {
        public void IssueBook()
        {
            Console.WriteLine("Book Issued");
        }

        public void ReturnBook()
        {
            Console.WriteLine("Book Returned");
        }

        public void AddBook()
        {
            Console.WriteLine("New Book Added");
        }

    }
}
