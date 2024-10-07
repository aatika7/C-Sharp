using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem
{
    class Program
    {
        // Book class to store book details
        public class Book
        {
            public int BookId { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public bool IsIssued { get; set; }
        }

        // Member class to store member details
        public class Member
        {
            public int MemberId { get; set; }
            public string Name { get; set; }
        }

        // Loan class to manage issued books
        public class Loan
        {
            public int LoanId { get; set; }
            public int BookId { get; set; }
            public int MemberId { get; set; }
            public DateTime IssueDate { get; set; }
            public DateTime? ReturnDate { get; set; }
        }

        // Static lists to act as database
        static List<Book> Books = new List<Book>();
        static List<Member> Members = new List<Member>();
        static List<Loan> Loans = new List<Loan>();

        static int bookIdCounter = 1;
        static int memberIdCounter = 1;
        static int loanIdCounter = 1;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Library Management System");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. View Books");
                Console.WriteLine("3. Delete Book");
                Console.WriteLine("4. Add Member");
                Console.WriteLine("5. View Members");
                Console.WriteLine("6. Issue Book");
                Console.WriteLine("7. Return Book");
                Console.WriteLine("8. View Loans");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddBook();
                        break;
                    case "2":
                        ViewBooks();
                        break;
                    case "3":
                        DeleteBook();
                        break;
                    case "4":
                        AddMember();
                        break;
                    case "5":
                        ViewMembers();
                        break;
                    case "6":
                        IssueBook();
                        break;
                    case "7":
                        ReturnBook();
                        break;
                    case "8":
                        ViewLoans();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option! Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // Method to add a new book
        static void AddBook()
        {
            Console.Clear();
            Console.WriteLine("Add New Book");
            Console.Write("Enter title: ");
            string title = Console.ReadLine();
            Console.Write("Enter author: ");
            string author = Console.ReadLine();

            Books.Add(new Book
            {
                BookId = bookIdCounter++,
                Title = title,
                Author = author,
                IsIssued = false
            });

            Console.WriteLine("Book added successfully! Press any key to continue...");
            Console.ReadKey();
        }

        // Method to view all books
        static void ViewBooks()
        {
            Console.Clear();
            Console.WriteLine("Available Books");
            foreach (var book in Books)
            {
                string status = book.IsIssued ? "Issued" : "Available";
                Console.WriteLine($"{book.BookId}. {book.Title} by {book.Author} - {status}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        // Method to delete a book
        static void DeleteBook()
        {
            Console.Clear();
            Console.Write("Enter Book ID to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var book = Books.FirstOrDefault(b => b.BookId == id);

            if (book != null && !book.IsIssued)
            {
                Books.Remove(book);
                Console.WriteLine("Book deleted successfully!");
            }
            else
            {
                Console.WriteLine("Book not found or it is currently issued.");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        // Method to add a new member
        static void AddMember()
        {
            Console.Clear();
            Console.WriteLine("Add New Member");
            Console.Write("Enter member name: ");
            string name = Console.ReadLine();

            Members.Add(new Member
            {
                MemberId = memberIdCounter++,
                Name = name
            });

            Console.WriteLine("Member added successfully! Press any key to continue...");
            Console.ReadKey();
        }

        // Method to view all members
        static void ViewMembers()
        {
            Console.Clear();
            Console.WriteLine("Library Members");
            foreach (var member in Members)
            {
                Console.WriteLine($"{member.MemberId}. {member.Name}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        // Method to issue a book to a member
        static void IssueBook()
        {
            Console.Clear();
            Console.Write("Enter Book ID to issue: ");
            int bookId = Convert.ToInt32(Console.ReadLine());
            var book = Books.FirstOrDefault(b => b.BookId == bookId);

            if (book != null && !book.IsIssued)
            {
                Console.Write("Enter Member ID: ");
                int memberId = Convert.ToInt32(Console.ReadLine());
                var member = Members.FirstOrDefault(m => m.MemberId == memberId);

                if (member != null)
                {
                    book.IsIssued = true;
                    Loans.Add(new Loan
                    {
                        LoanId = loanIdCounter++,
                        BookId = bookId,
                        MemberId = memberId,
                        IssueDate = DateTime.Now
                    });
                    Console.WriteLine("Book issued successfully!");
                }
                else
                {
                    Console.WriteLine("Member not found!");
                }
            }
            else
            {
                Console.WriteLine("Book not available or already issued.");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        // Method to return a book
        static void ReturnBook()
        {
            Console.Clear();
            Console.Write("Enter Book ID to return: ");
            int bookId = Convert.ToInt32(Console.ReadLine());
            var loan = Loans.FirstOrDefault(l => l.BookId == bookId && l.ReturnDate == null);

            if (loan != null)
            {
                var book = Books.First(b => b.BookId == bookId);
                book.IsIssued = false;
                loan.ReturnDate = DateTime.Now;

                Console.WriteLine("Book returned successfully!");
            }
            else
            {
                Console.WriteLine("Loan record not found!");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        // Method to view all loans
        static void ViewLoans()
        {
            Console.Clear();
            Console.WriteLine("Loan Records");
            foreach (var loan in Loans)
            {
                string returnDate = loan.ReturnDate?.ToString("dd/MM/yyyy") ?? "Not returned";
                Console.WriteLine($"Loan ID: {loan.LoanId}, Book ID: {loan.BookId}, Member ID: {loan.MemberId}, Issued: {loan.IssueDate.ToString("dd/MM/yyyy")}, Returned: {returnDate}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
