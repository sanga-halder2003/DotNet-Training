using Library_Management_System.Models;
using Microsoft.Data.SqlClient;
using Library_Management_System.DbConnections;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management_System.Repository
{
    public class LibraryRepository
    {
        private readonly DbConnection db = new DbConnection();

        public void AddBook(Book book)
        {
            using SqlConnection con = db.GetConnection();

            string query = @"insert into Books
                            (Title,ISBN,PublishedYear,Quantity,CategoryID,AuthorID)
                             values
                            (@Title, @ISBN, @PublishedYear, @Quantity, @CategoryID, @AuthorID)
                            ";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Title", book.Title);
            cmd.Parameters.AddWithValue("@ISBN", book.ISBN);
            cmd.Parameters.AddWithValue("@PublishedYear", book.PublishedYear);
            cmd.Parameters.AddWithValue("@Quantity", book.Quantity);
            cmd.Parameters.AddWithValue("@CategoryID", book.CategoryID);
            cmd.Parameters.AddWithValue("@AuthorID", book.AuthorID);

            con.Open();

            cmd.ExecuteNonQuery();

            Console.WriteLine("Book Added Successfully");


        }
        public void ViewBooks()
        {
            using SqlConnection con = db.GetConnection();

            string query = "SELECT * FROM Books";

            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(
                    $"{reader["BookID"]} | " +
                    $"{reader["Title"]} | " +
                    $"{reader["ISBN"]} | " +
                    $"{reader["PublishedYear"]} | " +
                    $"{reader["Quantity"]}");
            }
        }
        public void AddMember(Member member)
        {
            using SqlConnection con = db.GetConnection();

            string query = @"INSERT INTO Members
                    (MemberName,Email,Phone,Address)
                    VALUES
                    (@MemberName,@Email,@Phone,@Address)";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@MemberName", member.MemberName);
            cmd.Parameters.AddWithValue("@Email", member.Email);
            cmd.Parameters.AddWithValue("@Phone", member.Phone);
            cmd.Parameters.AddWithValue("@Address", member.Address);

            con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("Member Added Successfully");
        }

        public void ViewMembers()
        {
            using SqlConnection con = db.GetConnection();

            string query = "SELECT * FROM Members";

            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(
                    $"{reader["MemberID"]} | " +
                    $"{reader["MemberName"]} | " +
                    $"{reader["Email"]} | " +
                    $"{reader["Phone"]}");
            }
        }

        public void UpdateBook(int bookId, int quantity)
        {
            using SqlConnection con = db.GetConnection();

            string query = @"UPDATE Books
                     SET Quantity = @Quantity
                     WHERE BookID = @BookID";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Quantity", quantity);
            cmd.Parameters.AddWithValue("@BookID", bookId);

            con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("Book Updated Successfully");
        }

        public void DeleteBook(int bookId)
        {
            using SqlConnection con = db.GetConnection();

            string query = "DELETE FROM Books WHERE BookID=@BookID";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@BookID", bookId);

            con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("Book Deleted Successfully");
        }

        public void UpdateMember(int memberId, string phone)
        {
            using SqlConnection con = db.GetConnection();

            string query = @"UPDATE Members
                     SET Phone=@Phone
                     WHERE MemberID=@MemberID";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Phone", phone);
            cmd.Parameters.AddWithValue("@MemberID", memberId);

            con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("Member Updated Successfully");
        }

        public void DeleteMember(int memberId)
        {
            using SqlConnection con = db.GetConnection();

            string query = "DELETE FROM Members WHERE MemberID=@MemberID";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@MemberID", memberId);

            con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("Member Deleted Successfully");
        }
        public void IssueBook(int bookId, int memberId)
        {
            using SqlConnection con = db.GetConnection();

            string query = @"INSERT INTO Transactions
                    (IssueDate, DueDate, ReturnDate, Status, BookID, MemberID)
                    VALUES
                    (@IssueDate, @DueDate, @ReturnDate, @Status, @BookID, @MemberID)";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@IssueDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@DueDate", DateTime.Now.AddDays(15));
            cmd.Parameters.AddWithValue("@ReturnDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@Status", "Issued");
            cmd.Parameters.AddWithValue("@BookID", bookId);
            cmd.Parameters.AddWithValue("@MemberID", memberId);

            con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("Book Issued Successfully");
        }

        public void ReturnBook(int transactionId)
        {
            using SqlConnection con = db.GetConnection();

            string query = @"UPDATE Transactions
                     SET ReturnDate = @ReturnDate,
                         Status = @Status
                     WHERE TransactionID = @TransactionID";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@ReturnDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@Status", "Returned");
            cmd.Parameters.AddWithValue("@TransactionID", transactionId);

            con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("Book Returned Successfully");
        }

        public void TotalBooks()
        {
            using SqlConnection con = db.GetConnection();

            string query = "SELECT COUNT(*) FROM Books";

            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();

            int count = (int)cmd.ExecuteScalar();

            Console.WriteLine($"Total Books: {count}");
        }
        public void TotalMembers()
        {
            using SqlConnection con = db.GetConnection();

            string query = "SELECT COUNT(*) FROM Members";

            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();

            int count = (int)cmd.ExecuteScalar();

            Console.WriteLine($"Total Members: {count}");
        }

        public void AvailableBooks()
        {
            using SqlConnection con = db.GetConnection();

            string query = "SELECT * FROM Books WHERE Quantity > 0";

            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(
                    $"{reader["BookID"]} | {reader["Title"]} | {reader["Quantity"]}");
            }
        }

        public void IssuedBooks()
        {
            using SqlConnection con = db.GetConnection();

            string query =
                "SELECT * FROM Transactions WHERE Status='Issued'";

            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(
                    $"{reader["TransactionID"]} | {reader["BookID"]} | {reader["MemberID"]}");
            }
        }

        public void OverdueBooks()
        {
            using SqlConnection con = db.GetConnection();

            string query =
                @"SELECT * FROM Transactions
          WHERE DueDate < GETDATE()
          AND Status='Issued'";

            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(
                    $"{reader["TransactionID"]} | {reader["BookID"]}");
            }
        }

        public void MostBorrowedBook()
        {
            using SqlConnection con = db.GetConnection();

            string query = @"
        SELECT TOP 1
        BookID,
        COUNT(*) AS BorrowCount
        FROM Transactions
        GROUP BY BookID
        ORDER BY BorrowCount DESC";

            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(
                    $"BookID: {reader["BookID"]}  Borrowed: {reader["BorrowCount"]} times");
            }
        }


    }
}
