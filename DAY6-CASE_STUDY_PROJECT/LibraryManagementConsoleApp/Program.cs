using Library_Management_System.Services;

namespace Library_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LibraryService service = new LibraryService();

            while (true)
            {
                Console.WriteLine("\n===== LIBRARY MANAGEMENT =====");
                Console.WriteLine("1. View Books");
                Console.WriteLine("2. View Members");
                Console.WriteLine("3. Total Books");
                Console.WriteLine("4. Total Members");
                Console.WriteLine("5. Available Books");
                Console.WriteLine("6. Issued Books");
                Console.WriteLine("7. Overdue Books");
                Console.WriteLine("8. Most Borrowed Book");
                Console.WriteLine("9. Exit");

                Console.Write("Enter Choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        service.ViewBooks();
                        break;

                    case 2:
                        service.ViewMembers();
                        break;

                    case 3:
                        service.TotalBooks();
                        break;

                    case 4:
                        service.TotalMembers();
                        break;

                    case 5:
                        service.AvailableBooks();
                        break;

                    case 6:
                        service.IssuedBooks();
                        break;

                    case 7:
                        service.OverdueBooks();
                        break;

                    case 8:
                        service.MostBorrowedBook();
                        break;

                    case 9:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }
    }
}