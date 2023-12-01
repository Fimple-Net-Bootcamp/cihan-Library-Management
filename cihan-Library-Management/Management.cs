using Library_Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cihan_Library_Management
{
    internal abstract class Management
    {
        public virtual void LendBook(Book b, Member m)
        {
            Console.WriteLine("Inside parent class. Implemented for the sake of polymorphism.\n");
        }

        public virtual void ReturnBook(Book book, Member member)
        {
            Console.WriteLine("Inside parent class. Implemented for the sake of polymorphism.\n");
        }
    }
}
