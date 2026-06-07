using LibraryManagement.Interfaces;
using LibraryManagement.Models;
using LibraryManagement.Sevices;

class Program
{ 
    static void Main(string[] args)
    {
        Member member = new FacultyMembership();
        member.MembershipDetails();

        IAlert email = new EmailAlert();
        email.SendAlert("Book due tomorrow");

        IAlert sms = new SMSAlert();
        sms.SendAlert("Fine Pending");

        IReader reader = new Reader();
        reader.BorrowBook();
        reader.ReadBook();

        ILibrarian librarian = new Librarian();
        librarian.IssueBook();
        librarian.ReturnBook();
        librarian.AddBook();
    }
}
