using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management
{
    internal class Book : Text, IPrintable
    {
        public int BookID { get; set; }
        public bool isRented { get; set; }

        public Book() 
        {
            this.BookID = 0;
            this.Author = string.Empty;
            this.Title = string.Empty;
            this.isRented = false;
        }

        public Book(int id, string author, string title, int publishYear)
        {
            this.BookID = id;
            this.Title = title;
            this.Author = author;
            this.PublishYear = publishYear;
            this.isRented = false;
        }

        public void Print()
        {
            Console.WriteLine("Author: {0}, Book name: {1}, Year of publication: {2}\n", this.Author, this.Title, this.PublishYear);
        }
    }
}
