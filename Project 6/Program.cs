///////////////////////////////////////////////////////////////////////////////
//
// Author: William Roe, roew01@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project 6
// Description: Main method that runs the logic for the program.
// (I'm sorry for the scuffed solution but it works)
//
///////////////////////////////////////////////////////////////////////////////
namespace Project_6
{
    internal class Program
    {
        static void Main()
        {
            //Ask user what they want to sort on and then validate that input
            Console.WriteLine("Do you want to sort by Title, Publisher, or Author?");
            string sort = string.Empty;
            bool check = false;
            while (!check)
            {
                string userInput = Console.ReadLine().ToLower();
                string[] validInputs = { "title", "publisher", "author" };
                if (validInputs.Contains(userInput))
                {
                    sort = userInput;
                    check = true;
                }
                else
                {
                    Console.WriteLine("Invalid Input. Try again.");
                }
            }

            AVLTree tree = new();
            //Reads in the data from the .csv file and creates the books with that data
            using (StreamReader sr = new StreamReader("books.csv"))
            {
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    int pages = 0;
                    //Formatting input
                    line = line.Replace("\"", string.Empty);
                    String[] bookData = line.Split(",");

                    //Case for if the title and author have a ',' (6 total entries from split)
                    if (bookData.Length == 6)
                    {
                        //Creates the book and adds it to the tree based on the sort
                        pages = Convert.ToInt32(bookData[4]);
                        switch (sort)
                        {
                            case "title": { tree.TitleAdd(new Book(bookData[0] + ',' + bookData[1], bookData[2] + ',' + bookData[3], pages, bookData[5])); }
                                break;
                            case "publisher": { tree.PublisherAdd(new Book(bookData[0] + ',' + bookData[1], bookData[2] + ',' + bookData[3], pages, bookData[5])); }
                                break;
                            case "author": { tree.AuthorAdd(new Book(bookData[0] + ',' + bookData[1], bookData[2] + ',' + bookData[3], pages, bookData[5])); }
                                break;
                        }
                    }
                    //Case for if only one of either the title or author have a ',' (5 total entries from split)
                    else if (bookData.Length == 5)
                    {
                        //Comma only in the title
                        pages = Convert.ToInt32(bookData[3]);
                        string[] edgeCases = { " The", " vol 106 No 3", " Vol 39 No. 1" };
                        if (edgeCases.Contains(bookData[1]))
                        {
                            //Creates the book and adds it to the tree based on the sort
                            switch (sort)
                            {
                                case "title": { tree.TitleAdd(new Book(bookData[0] + ',' + bookData[1], bookData[2], pages, bookData[4])); }
                                    break;
                                case "publisher": { tree.PublisherAdd(new Book(bookData[0] + ',' + bookData[1], bookData[2], pages, bookData[4])); }
                                    break;
                                case "author": { tree.AuthorAdd(new Book(bookData[0] + ',' + bookData[1], bookData[2], pages, bookData[4])); }
                                    break;
                            }
                        }
                        //Comma only in the author
                        else
                        {
                            //Creates the book and adds it to the tree based on the sort
                            switch (sort)
                            {
                                case "title": { tree.TitleAdd(new Book(bookData[0], bookData[1] + ',' + bookData[2], pages, bookData[4])); }
                                    break;
                                case "publisher": { tree.PublisherAdd(new Book(bookData[0], bookData[1] + ',' + bookData[2], pages, bookData[4])); }
                                    break;
                                case "author": { tree.AuthorAdd(new Book(bookData[0], bookData[1] + ',' + bookData[2], pages, bookData[4])); }
                                    break;
                            }
                        }
                    }
                    //No commas in either the title or author (4 total entries from split)
                    else
                    {
                        //Creates the book and adds it to the tree based on the sort
                        pages = Convert.ToInt32(bookData[2]);
                        switch (sort)
                        {
                            case "title": { tree.TitleAdd(new Book(bookData[0], bookData[1], pages, bookData[3])); }
                                break;
                            case "publisher": { tree.PublisherAdd(new Book(bookData[0], bookData[1], pages, bookData[3])); }
                                break;
                            case "author": { tree.AuthorAdd(new Book(bookData[0], bookData[1], pages, bookData[3])); }
                                break;
                        }
                    }
                }
            }
            /**
             * Displays the tree based on the sorted parameter
             * A book without the current parameter being sorted is sorted at the top of the list
             */
            tree.DisplayTree();
        }
    }
}