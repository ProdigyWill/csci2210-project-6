///////////////////////////////////////////////////////////////////////////////
//
// Author: William Roe, roew01@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project 6
// Description: Node class that stores book objects on an AVLTree
//
///////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_6
{
    public class Node
    {
        public Book data;
        public Node left;
        public Node right;
        /// <summary>
        /// Default Node constructor
        /// </summary>
        /// <param name="data">Book object being stored inside the node</param>
        public Node(Book data)
        {
            this.data = data;
        }  
    }
}
