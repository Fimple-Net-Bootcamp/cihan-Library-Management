using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management
{
    internal class Library : IPrintable
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
    }
}
