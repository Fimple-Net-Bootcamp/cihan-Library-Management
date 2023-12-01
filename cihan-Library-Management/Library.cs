using cihan_Library_Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library_Management
{
    internal class Library : Management, IPrintable
    {
        private List<Book> Books = new List<Book>();
        private List<Member> Members = new List<Member>();

        public Library()
        {
          
        }
        public void AddBook(Book book) { Books.Add(book); }
        public void DeleteBook(Book book) { Books.Remove(book); }
        public void AddMember(Member member) {  Members.Add(member); }
        public void RemoveMember(Member member) { Members.Remove(member); }

        public void Print()
        {
            Console.WriteLine("All library books:");
            foreach (Book book in Books) { book.Print(); }
            Console.WriteLine("**********************************");
        }
        public void PrintMembers()
        {
            Console.WriteLine("All library members:");
            foreach (Member member in Members) { member.Print(); }
            Console.WriteLine("**********************************");
        }

       public override void LendBook(Book book, Member member)
        {
            if(Books.Contains(book))
            {
                if(!book.isRented)
                {
                    member.TakeBook(book);
                    Console.WriteLine("Book borrowed successfully.\n");
                    book.isRented = true;
                }
                else
                {
                    Console.WriteLine("The book cannot be rented because it is currently rented.\n");
                }
                
            }
            else
            {
                Console.WriteLine("The book does not exist.\n");
            }
        }
        public override void ReturnBook(Book book, Member member)
        {
            if (member.Books.Contains(book))
            {
                member.Books.Remove(book);
                Console.WriteLine("Book returned successfully.\n");
                book.isRented = false;
            }
            else
            {
                Console.WriteLine("Book is not borrowed by the member.");
            }
        }

        public Member FindMemberByName(string memberName)
        {
            return Members.FirstOrDefault(member => member.Name.Equals(memberName, StringComparison.OrdinalIgnoreCase));
        }
        public Book FindBookByTitle(string bookTitle)
        {
            return Books.FirstOrDefault(book => book.Title.Equals(bookTitle, StringComparison.OrdinalIgnoreCase));
        }

        public void PrintMembersAndTheirBooks()
        {
            foreach (var member in Members)
            {
                Console.WriteLine($"Member: {member.Name} {member.Surname}, Membership Number: {member.Number}");

                if (member.Books.Count > 0)
                {
                    Console.WriteLine("Books Borrowed:");
                    foreach (var book in member.Books)
                    {
                        Console.WriteLine($"{book.Title} by {book.Author}");
                    }
                }
                else
                {
                    Console.WriteLine("No books borrowed.");
                }

                Console.WriteLine();
            }
        }
    }
}
