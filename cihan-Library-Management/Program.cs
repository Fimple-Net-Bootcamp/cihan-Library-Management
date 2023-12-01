using Library_Management;
using System;

class Program
{
    static void Main()
    {
        Library library = new Library();
        Console.WriteLine("if you wish to populate your library with default books and members type 'default', anything else will lead you to a different process.\n");
        string initialChoice = Console.ReadLine();

        if (initialChoice == "default")
        {
            string[] booksData = 
            {
                "Frank Herbert_Dune_1965",
                "Frank Herbert_Dune Messiah_1969",
                "Frank Herbert_Children of Dune_1976",
                "Frank Herbert_God Emperor of Dune_1981",
                "Frank Herbert_Heretics of Dune_1984",
                "Frank Herbert_Chapterhouse:Dune_1985",
                "Christopher Tolkien_The Hobbit_1937",
                "Christopher Tolkien_The Fellowship of the Ring_1954",
                "Christopher Tolkien_The Two Towers_1954",
                "Christopher Tolkien_The Return of the King_1955",
                "Christopher Tolkien_Silmarillion_1977",
            };

            string[] membersData =
            {
                "Cihan-Nesvat",
                "Billie-Eilish",
                "Jensen-Ackles",
                "Dua-Lipa"
            };

            int bookID = 1;
            foreach (string s in booksData)
            {
                string[] data = s.Split('_');
                Book book = new Book(bookID, data[0], data[1], Int32.Parse(data[2]));
                bookID++;
                library.AddBook(book);
            }

            int membershipNO = 1;
            foreach(string s in membersData)
            {
                string[] data = s.Split("-");
                Member member = new Member(data[0], data[1], membershipNO);
                membershipNO++; 
                library.AddMember(member);
            }
        }

        else
        {
            Console.WriteLine("Let's first populate the library with some books. Please enter author name, book name, and the year of publication" +
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
        }


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
                Console.WriteLine("Who are you?: ");
                string memberName = Console.ReadLine();
                Member m = library.FindMemberByName(memberName);

                if (m == null)
                {
                    Console.WriteLine("No such member.\n");
                    continue;      
                }

                Console.WriteLine("Which book do you want?: ");
                string bookName = Console.ReadLine();
                Book b = library.FindBookByTitle(bookName);

                if(b == null)
                {
                    Console.WriteLine("No such book.\n");
                    continue;
                }

                library.LendBook(b, m);
            }
            else if (command?.ToLower() == "return book")
            {
                Console.WriteLine("Who are you?: ");
                string memberName = Console.ReadLine();
                Member m = library.FindMemberByName(memberName);

                if (m == null)
                {
                    Console.WriteLine("No such member.\n");
                    continue;
                }

                Console.WriteLine("Which book do you want to return?: ");
                string bookName = Console.ReadLine();
                Book b = library.FindBookByTitle(bookName);

                if (b == null)
                {
                    Console.WriteLine("No such book.\n");
                    continue;
                }

                library.ReturnBook(b, m);
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
                library.PrintMembersAndTheirBooks();
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

