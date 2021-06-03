using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackTracking.Helper
{
    internal class SumOfSubsetsProblem
    {
        int count;
        int reqWeight;
        int[] weight;
        int[] subset;

        internal void SolveSubset(int[] weight, int itemCount, int reqWeight)
        {
            count = itemCount;
            this.reqWeight = reqWeight;
            this.weight = weight;

            subset = new int[itemCount];

            if (!SolveSubsetUntil(0, 0, reqWeight))
            {
                Console.WriteLine("Solution does not exist");
            }
        }

        private bool SolveSubsetUntil(int idx, int currentWeight, int remWeight)
        {
            if (currentWeight == reqWeight)
            {
                Console.WriteLine();
                PrintSubset();
                return true;
            }

            bool res = false;

            for (int i = idx; i < count; i++)
            {
                if (currentWeight > reqWeight || (currentWeight + remWeight) < reqWeight)
                {
                    return false;
                }

                subset[i] = 1;
                res = SolveSubsetUntil(i + 1, currentWeight + weight[i], remWeight - weight[i]) || res;

                subset[i] = 0;
                res = SolveSubsetUntil(i + 1, currentWeight, remWeight - weight[i]) || res;
            }

            return res;
        }

        private void PrintSubset()
        {
            for (int i = 0; i < count; i++)
            {
                if (subset[i] != 0)
                {
                    Console.WriteLine($"Item {i + 1} : Included");
                }
            }
        }
    }
}
