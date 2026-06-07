using LibraryManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Models
{
    public class Reader:IReader
    {
        public void ReadBook()
        {
            Console.WriteLine("Reading a book");
        }
        public void BorrowBook()
        {
            Console.WriteLine("Borrowing a book");
        }
    }
}
