using BackTracking.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine(
                    Environment.NewLine + "1. N Queens Problem" + //Time Complexity(n!) ~ Time Complexity(O(n^n))
                    Environment.NewLine + "2. Sum Of Subset Problem" + //Time Complexity(2^n)
                    Environment.NewLine + "3. Graph Coloring Problem" + //Time Complexity(n^n)
                    Environment.NewLine + "4. Hamiltonian Cycle" + //Time Complexity(n!) ~ Time Complexity(O(n^n))
                    Environment.NewLine + "0. Exit\n"
                );

                Console.Write("Please select an option : ");

                if (!int.TryParse(Console.ReadLine(), out int i))
                {
                    Console.WriteLine(Environment.NewLine + "Input format is not valid. Please try again." + Environment.NewLine);
                }

                if (i == 0)
                {
                    Environment.Exit(0);
                }
                else if (i == 1)
                {
                    NQueensProblem nQueensProblem = new NQueensProblem();
                    nQueensProblem.SolveNQ();
                }
                else if (i == 2)
                {
                    Console.Write("\nEnter the count of items : ");
                    int count = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter the weight of items(comma separated) : "); //5,10,12,13,15,18
                    int[] weights = Console.ReadLine().Split(',', (char)StringSplitOptions.RemoveEmptyEntries).Select(x => Convert.ToInt32(x)).ToArray();

                    Console.Write("Enter the required weigth : ");
                    int reqWeight = Convert.ToInt32(Console.ReadLine());

                    SumOfSubsetsProblem sumOfSubsetsProblem = new SumOfSubsetsProblem();
                    sumOfSubsetsProblem.SolveSubset(weights, count, reqWeight);
                }
                else if (i == 3)
                {
                    GraphColoringProblem graphColoringProblem = new GraphColoringProblem();
                    graphColoringProblem.SolveGCP();
                }
                else if (i == 4)
                {
                    HamiltonianCycle hamiltonianCycle = new HamiltonianCycle();
                    hamiltonianCycle.SolveHC();
                }
                else
                {
                    Console.WriteLine("Please select a valid option.");
                }
            }
        }
    }
}
