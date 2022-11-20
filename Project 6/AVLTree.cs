///////////////////////////////////////////////////////////////////////////////
//
// Author: William Roe, roew01@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project 6
// Description: AVLTree class taken from here: https://simpledevcode.wordpress.com/2014/09/16/avl-tree-in-c/
// then modified by me to be used to store Book objects. Any method unchanged by me is indicated below.
//
///////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_6
{
    public class AVLTree
    {
        Node root;
        public AVLTree()
        {
        }

        /// <summary>
        /// Add method the adds a book to the tree sorted based on the book's title
        /// </summary>
        /// <param name="data">The book being added to the tree</param>
        public void TitleAdd(Book data)
        {
            Node newItem = new Node(data);
            if (root == null)
            {
                root = newItem;
            }
            else
            {
                root = TitleRecursiveInsert(root, newItem);
            }
        }

        /// <summary>
        /// Recursive insert method that is used by add to 
        /// make sure that the book is added into the correct
        /// spot in the AVLTree based on the Book object's title
        /// </summary>
        /// <param name="current">The node currently being compared to the node being inserted</param>
        /// <param name="n">The node being inserted</param>
        /// <returns>The new root node</returns>
        private Node TitleRecursiveInsert(Node current, Node n)
        {
            if (current == null)
            {
                current = n;
                return current;
            }
            else if (n.data.Title.CompareTo(current.data.Title) < 0)
            {
                current.left = TitleRecursiveInsert(current.left, n);
                current = balance_tree(current);
            }
            else if (n.data.Title.CompareTo(current.data.Title) > 0)
            {
                current.right = TitleRecursiveInsert(current.right, n);
                current = balance_tree(current);
            }
            return current;
        }
        /// <summary>
        /// Add method the adds a book to the tree sorted based on the book's publisher
        /// </summary>
        /// <param name="data">The book being added to the tree</param>
        public void PublisherAdd(Book data)
        {
            Node newItem = new Node(data);
            if (root == null)
            {
                root = newItem;
            }
            else
            {
                root = PublisherRecursiveInsert(root, newItem);
            }
        }
        /// <summary>
        /// Recursive insert method that is used by add to 
        /// make sure that the book is added into the correct
        /// spot in the AVLTree based on the Book object's publisher
        /// </summary>
        /// <param name="current">The node currently being compared to the node being inserted</param>
        /// <param name="n">The node being inserted</param>
        /// <returns>The new root node</returns>
        private Node PublisherRecursiveInsert(Node current, Node n)
        {
            if (current == null)
            {
                current = n;
                return current;
            }
            else if (n.data.Publisher.CompareTo(current.data.Publisher) <= 0)
            {
                current.left = PublisherRecursiveInsert(current.left, n);
                current = balance_tree(current);
            }
            else if (n.data.Publisher.CompareTo(current.data.Publisher) > 0)
            {
                current.right = PublisherRecursiveInsert(current.right, n);
                current = balance_tree(current);
            }
            return current;
        }
        /// <summary>
        /// Add method the adds a book to the tree sorted based on the book's author
        /// </summary>
        /// <param name="data">The book being added to the tree</param>
        public void AuthorAdd(Book data)
        {
            Node newItem = new Node(data);
            if (root == null)
            {
                root = newItem;
            }
            else
            {
                root = AuthorRecursiveInsert(root, newItem);
            }
        }
        /// <summary>
        /// Recursive insert method that is used by add to 
        /// make sure that the book is added into the correct
        /// spot in the AVLTree based on the Book object's author
        /// </summary>
        /// <param name="current">The node currently being compared to the node being inserted</param>
        /// <param name="n">The node being inserted</param>
        /// <returns>The new root node</returns>
        private Node AuthorRecursiveInsert(Node current, Node n)
        {
            if (current == null)
            {
                current = n;
                return current;
            }
            else if (n.data.Author.CompareTo(current.data.Author) <= 0)
            {
                current.left = AuthorRecursiveInsert(current.left, n);
                current = balance_tree(current);
            }
            else if (n.data.Author.CompareTo(current.data.Author) > 0)
            {
                current.right = AuthorRecursiveInsert(current.right, n);
                current = balance_tree(current);
            }
            return current;
        }

        //This method was unchanged from the original implementation found on the site
        private Node balance_tree(Node current)
        {
            int b_factor = balance_factor(current);
            if (b_factor > 1)
            {
                if (balance_factor(current.left) > 0)
                {
                    current = RotateLL(current);
                }
                else
                {
                    current = RotateLR(current);
                }
            }
            else if (b_factor < -1)
            {
                if (balance_factor(current.right) > 0)
                {
                    current = RotateRL(current);
                }
                else
                {
                    current = RotateRR(current);
                }
            }
            return current;
        }
        
        /// <summary>
        /// Prints the entire contents of the AVLTree
        /// </summary>
        public void DisplayTree()
        {
            if (root == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }
            InOrderDisplayTree(root);
            Console.WriteLine();
        }
        /// <summary>
        /// Recursive method that calls itself displaying to console
        /// all the nodes on the AVLTree
        /// </summary>
        /// <param name="current">The current node being printed</param>
        private void InOrderDisplayTree(Node current)
        {
            if (current != null)
            {
                InOrderDisplayTree(current.left);
                Console.WriteLine("{0} ", current.data.Print());
                InOrderDisplayTree(current.right);
            }
        }

        //This method was unchanged from the original implementation found on the site
        private int max(int l, int r)
        {
            return l > r ? l : r;
        }
        //This method was unchanged from the original implementation found on the site
        private int getHeight(Node current)
        {
            int height = 0;
            if (current != null)
            {
                int l = getHeight(current.left);
                int r = getHeight(current.right);
                int m = max(l, r);
                height = m + 1;
            }
            return height;
        }
        //This method was unchanged from the original implementation found on the site
        private int balance_factor(Node current)
        {
            int l = getHeight(current.left);
            int r = getHeight(current.right);
            int b_factor = l - r;
            return b_factor;
        }
        //This method was unchanged from the original implementation found on the site
        private Node RotateRR(Node parent)
        {
            Node pivot = parent.right;
            parent.right = pivot.left;
            pivot.left = parent;
            return pivot;
        }
        //This method was unchanged from the original implementation found on the site
        private Node RotateLL(Node parent)
        {
            Node pivot = parent.left;
            parent.left = pivot.right;
            pivot.right = parent;
            return pivot;
        }
        //This method was unchanged from the original implementation found on the site
        private Node RotateLR(Node parent)
        {
            Node pivot = parent.left;
            parent.left = RotateRR(pivot);
            return RotateLL(parent);
        }
        //This method was unchanged from the original implementation found on the site
        private Node RotateRL(Node parent)
        {
            Node pivot = parent.right;
            parent.right = RotateLL(pivot);
            return RotateRR(parent);
        }
    }
}
