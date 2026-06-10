using Library_Management_System.Models;
using Library_Management_System.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management_System.Services
{
    public class LibraryService
    {
        private readonly LibraryRepository repository = new();
        public void AddBook(Book book)
        {
            repository.AddBook(book);
        }

        public void ViewBooks()
        {
            repository.ViewBooks();
        }

        public void AddMember(Member member)
        {
            repository.AddMember(member);
        }

        public void ViewMembers()
        {
            repository.ViewMembers();
        }

        public void UpdateBook(int bookId, int quantity)
        {
            repository.UpdateBook(bookId, quantity);
        }

        public void DeleteBook(int bookId)
        {
            repository.DeleteBook(bookId);
        }

        public void UpdateMember(int memberId, string phone)
        {
            repository.UpdateMember(memberId, phone);
        }

        public void DeleteMember(int memberId)
        {
            repository.DeleteMember(memberId);
        }

        public void IssueBook(int bookId, int memberId)
        {
            repository.IssueBook(bookId, memberId);
        }

        public void ReturnBook(int transactionId)
        {
            repository.ReturnBook(transactionId);
        }

        public void TotalBooks()
        {
            repository.TotalBooks();
        }

        public void TotalMembers()
        {
            repository.TotalMembers();
        }

        public void AvailableBooks()
        {
            repository.AvailableBooks();
        }

        public void IssuedBooks()
        {
            repository.IssuedBooks();
        }

        public void OverdueBooks()
        {
            repository.OverdueBooks();
        }

        public void MostBorrowedBook()
        {
            repository.MostBorrowedBook();
        }

    }
}
