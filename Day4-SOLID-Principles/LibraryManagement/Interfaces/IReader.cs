// ISP: Reader only gets methods
// related to reading and borrowing books.

using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Interfaces
{
    public interface IReader
    {
        void ReadBook();
        void BorrowBook();
    }
}
