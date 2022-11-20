///////////////////////////////////////////////////////////////////////////////
//
// Author: William Roe, roew01@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project 6
// Description: Book object that represents a book with a 
// title, author, number of pages, and publisher
//
///////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_6
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public string Publisher { get; set; }

        /// <summary>
        /// Book class constructor that takes in 4 paramaters
        /// representing a book's title, author, number of pages, and publisher
        /// </summary>
        /// <param name="Title">The book's title</param>
        /// <param name="Author">The book's author</param>
        /// <param name="Pages">The book's number of pages</param>
        /// <param name="Publisher">The book's publisher</param>
        public Book(string Title, string Author, int Pages, string Publisher)
        {
            this.Title = Title;
            this.Author = Author;
            this.Pages = Pages;
            this.Publisher = Publisher;
        }

        /// <summary>
        /// Print method that outputs a string representation of a book
        /// </summary>
        /// <returns>A string representation of a book</returns>
        public string Print()
        {
            string output = "";
            string publisher = this.Publisher;
            string author = this.Author;

            //Check if the book doesn't have a publisher or author
            if (publisher.Equals(string.Empty)) { publisher = "N/A"; }
            if (author.Equals(string.Empty)) { author = "N/A"; }

            output += "Title: " + this.Title + ", " 
                      + "Author: " + author + ", " 
                      + "Pages: " + this.Pages + ", " 
                      + "Publisher: " + publisher;
            return output;
        }
    }
}
