using Library_Management;
using System;

class Program
{
    static void Main()
    {
        string[] data = {
            "Frank Herbert_Dune_1965"
        };

        Library library = new Library();

        Console.WriteLine("Before we begin, let's populate the library with some books. Please enter author name, book name, and the year of publication" +
                          " in a single line and separate with '-'.\n" +
                          "ex: Frank Herbert-Dune-1965\n");

        //begin adding books to the library.
        int bookID = 1;
        while (true)
        {
            string bookDetails = Console.ReadLine();

            if (bookDetails?.ToLower() == "exit") break;

            string[] detailsList = bookDetails?.Split("-");

            if (detailsList != null && detailsList.Length == 3 && int.TryParse(detailsList[2], out int year))
            {
                Book book = new Book(bookID, detailsList[0], detailsList[1], year);
                library.AddBook(book);
                bookID++;
                Console.WriteLine("Book added\n");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter details in the correct format.\n");
            }
        }
        //end adding books.

        Console.WriteLine("**********************************************");

        Console.WriteLine("Now let's add members for our library\n" +
            "Add members in the format Name-Surname. Type exit to exit.\n");

        //begin adding members to the library.
        int membershipNo = 1;
        while (true)
        {
            string memberDetails = Console.ReadLine();

            if (memberDetails?.ToLower() == "exit") break;
            string[] detailsList = memberDetails?.Split("-");

            if (detailsList != null && detailsList.Length == 2 && detailsList[1] != string.Empty)
            {
                Member member = new Member(detailsList[0], detailsList[1], membershipNo);
                membershipNo++;
                library.AddMember(member);
                Console.WriteLine("Member added\n");
            }
            else Console.WriteLine("Invalid input. Please enter details in the correct format.\n");
        }
        //end adding members.

        Console.WriteLine("**********************************************\n");

        //simulation begins
        Console.WriteLine("Ready to begin!\n");

        //THE MENU
        while (true)
        {
            Console.WriteLine(
            "What would you like to do now?\n" +
            "Options:\n" +
            "- A member can rent a book (type 'rent book')\n" +
            "- A member can return a book (type 'return book')\n" +
            "- Print library members (type 'print members')\n" +
            "- Print library books (type 'print books')\n" +
            "- See who owns which book(s) (type 'silmarillion')\n" +
            "- exit\n");
            string command = Console.ReadLine();

            if (command?.ToLower() == "exit")
            {
                break;
            }
            else if (command?.ToLower() == "rent book")
            {
                Console.WriteLine("to be implemented\n");
            }
            else if (command?.ToLower() == "return book")
            {
                Console.WriteLine("to be implemented\n");
            }
            else if (command?.ToLower() == "print members")
            {
                library.PrintMembers();
            }
            else if ((command?.ToLower() == "print books"))
            {
                library.Print();
            }
            else if (command?.ToLower() == "silmarillion")
            {
                Console.WriteLine("to be implemented\n");
            }
            else if (command?.ToLower() == "exit")
            {
                Console.WriteLine("exiting...\n");
                break;
            }
            else
            {
                Console.WriteLine("put your mind into it.\n");
            }
        }//while end

        Console.WriteLine(
            "*******************************\n" +
            "See you later I guess.\n"
            );
    }
}

