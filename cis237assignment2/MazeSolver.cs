// Alyssa Strand (Mahler)
// CIS 237 Advanced C# Assignment 2 Due: 10-4-16
// This assignment uses recursion to traverse an input maze.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    /// <summary>
    /// This class is used for solving a char array maze.
    /// You might want to add other methods to help you out.
    /// A print maze method would be very useful, and probably necessary to print the solution.
    /// If you are real ambitious, you could make a seperate class to handle that.
    /// </summary>
    class MazeSolver
    {
        /// <summary>
        /// Class level member variable for the mazesolver class
        /// </summary>
        char[,] maze;
        int xStart;
        int yStart;

        /// <summary>
        /// Default Constuctor to setup a new maze solver.
        /// </summary>
        public MazeSolver()
        {}

        /// <summary>
        /// This is the public method that will allow someone to use this class to solve the maze.
        /// Feel free to change the return type, or add more parameters if you like, but it can be done
        /// exactly as it is here without adding anything other than code in the body.
        /// </summary>
        public void SolveMaze(char[,] maze, int xStart, int yStart)
        {
            //Assign passed in variables to the class level ones. It was not done in the constuctor so that
            //a new maze could be passed into this solve method without having to create a new instance.
            //The variables are assigned so they can be used anywhere they are needed within this class. 
            this.maze = maze;
            this.xStart = xStart;
            this.yStart = yStart;

            //Do work needed to use mazeTraversal recursive call and solve the maze.

                // Send in the starting coordinates:
            mazeTraversal(xStart, yStart);
        }

        /// <summary>
        /// This should be the recursive method that gets called to solve the maze.
        /// Feel free to change the return type if you like, or pass in parameters that you might need.
        /// This is only a very small starting point.
        /// </summary>
        private void mazeTraversal(int xCoord, int yCoord)
        {
            while (xCoord < maze.GetLength(0) && yCoord < maze.GetLength(1))
            {
                    //Implement maze traversal recursive call
                if (maze[xCoord, yCoord] == '.')
                {
                        // "Move to the new spot" (make it an X): 
                    maze[xCoord, yCoord] = 'X';
                        // Print the current maze:
                    printMaze();

                        // Try going down:
                    mazeTraversal(xCoord + 1, yCoord);
                        // Try going right:
                    mazeTraversal(xCoord, yCoord + 1);
                        // Try going up:
                    mazeTraversal(xCoord - 1, yCoord);
                        // Try going left:
                    mazeTraversal(xCoord, yCoord - 1);
                }
                else
                {
                   
                }
            }
            // Maze has been completed!  Print a message to the user:
            Console.WriteLine("Maze complete!");
        }

        private void printMaze()
        {
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0;  y < maze.GetLength(1); y++)
                {
                    Console.Write(maze[x, y]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
