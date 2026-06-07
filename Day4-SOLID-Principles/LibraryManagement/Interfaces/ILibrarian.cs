using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Interfaces
{
    public interface ILibrarian
    {
        void IssueBook();
        void ReturnBook();
        void AddBook();
    }
}
