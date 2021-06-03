using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackTracking.Helper
{
    internal class NQueensProblem
    {
        private static int size = 4;
        int[,] board = new int[size, size];

        internal void SolveNQ()
        {
            if (!solveNQUtil(0))
            {
                Console.WriteLine("Solution does not exist");
            }
        }

        private bool solveNQUtil(int row)
        {
            if(row >= size)
            {
                PrintSolution();
                return true;
            }

            bool res = false;

            for (int i = 0; i < size; i++)
            {
                if (IsSafe(row, i))
                {
                    board[row, i] = 1;
                    res = solveNQUtil(row + 1) || res;
                    board[row, i] = 0;                   
                 }
            }

            return res;
        }

        private bool IsSafe(int row, int column)
        {
            int i, j;

            // Check upper rows
            for(i = 0; i < row; i++)
            {
                if(board[i, column] == 1)
                {
                    return false;
                }
            }

            //Check upper left diagonals
            for(i = row - 1, j = column - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i, j] == 1)
                {
                    return false;
                }
            }

            //Check upper right diagonals
            for (i = row - 1, j = column + 1; i >= 0 && j < size; i--, j++)
            {
                if (board[i, j] == 1)
                {
                    return false;
                }
            }

            return true;
        }

        private void PrintSolution()
        {
            Console.WriteLine();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(board[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
