using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management
{
    internal class Member : IPrintable
    {
        internal string Name { get; set; }
        internal string Surname { get; set; }
        internal int Number { get; set; }
        internal List<Book> Books { get; set; } = new List<Book>();

        public Member()
        {
            this.Name = string.Empty;
            this.Surname = string.Empty;
            this.Books = new List<Book>();
            this.Number = 0;
        }
        public Member(string name, string surname, int number)
        {
            Name = name;
            Surname = surname;
            Number = number;
        }

        public void Print()
        {
            Console.WriteLine("Member name:{0}-{1}\nMembership number: {2}", Name, Surname, Number);

            if (Books.Count > 0)
            {
                Console.WriteLine("Books currently owned by the member:\n");
                foreach (var book in Books) { book.Print(); }
            }
            else
            {
                Console.WriteLine("Member has no books.\n");
            }
            
        }
    }
}
