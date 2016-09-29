// Alyssa Strand (Mahler)
// CIS 237 Advanced C# Assignment 2 Due: 10-4-16

// This assignment uses recursion to traverse an input maze.
// This class handles the recursion work of solving the input maze,
// as well as printing each step to the user and noting when the maze is solved.

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
            if (mazeTraversal(xStart, yStart))
            {
                // If true - maze has been completed!  Print a message to the user:
                Console.WriteLine("Maze complete!");
                Console.WriteLine();
            }
            else
            {   // Error message if maze cannot be escaped:
                Console.WriteLine("It appears that was not a solvable maze.");
            }
        }

        /// <summary>
        /// This should be the recursive method that gets called to solve the maze.
        /// Feel free to change the return type if you like, or pass in parameters that you might need.
        /// This is only a very small starting point.
        /// </summary>
        /// 
        // Recursive method returns a bool depending on whether the maze is solvable.
        // Recursively, the boolean value controls whether the current path is successful.
        private bool mazeTraversal(int xCoord, int yCoord)
        {
            // If the current point is within the bounds of the maze, continue to testing:
            if (xCoord >= 0 && xCoord < maze.GetLength(0) && yCoord >= 0 && yCoord < maze.GetLength(1))
            {
                // If the current spot is a valid path, continue:
                if (maze[xCoord, yCoord] == '.')
                {
                    // "Move to the new spot" (make it an X): 
                    maze[xCoord, yCoord] = 'X';
                    // Print the current maze:
                    printMaze();

                    // Try going down:
                    if (mazeTraversal(xCoord + 1, yCoord))
                    {
                        return true;
                    }
                    // Try going right:
                    if (mazeTraversal(xCoord, yCoord + 1))
                    {
                        return true;
                    }
                    // Try going up:
                    if (mazeTraversal(xCoord - 1, yCoord))
                    {
                        return true;
                    }
                    // Try going left:
                    if (mazeTraversal(xCoord, yCoord - 1))
                    {
                        return true;
                    }

                    // If no direction is open, change the X to an O:
                    maze[xCoord, yCoord] = 'O';
                    // Print the maze with the O to show the step:
                    printMaze();
                    // Return false to show dead end:
                    return false;
                }
                else
                {
                    // If the spot is not a ".", it is not a valid path, so return false:
                    return false;
                }
            }
            else
            {
                // If the current spot is outside the bounds, the maze has been solved, so return true:
                return true;
            }
        }

        // Method to print what the maze currently looks like:
        private void printMaze()
        {   
            // For each x,
            for (int x = 0; x < maze.GetLength(0); x++)
            {   
                // For each y, 
                for (int y = 0;  y < maze.GetLength(1); y++)
                {   
                    // Print the character:
                    Console.Write(maze[x, y]);
                }
                // At the end of the line, go to the next line:
                Console.WriteLine();
            }
            // Leave some space at the end of each maze output:
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
