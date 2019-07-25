// This file contains the solution of CodeJam 2018 Qualifiers Problem - Trouble Sort

using System;
using System.Collections.Generic;

namespace CodeJam
{
    class Program
    {
        static int GetTroubleSortStatus(int[] integers)
        {
            List<int> odd = new List<int>();
            List<int> even = new List<int>();
            for (int i = 0; i < integers.Length; i = i + 2)
            {
                even.Add(integers[i]);
                if (!(i == integers.Length - 1)) odd.Add(integers[i + 1]);
            }
            odd.Sort();
            even.Sort();
            int[] finalList = new int[integers.Length];
            for (int i = 0; i < integers.Length; i = i + 2)
            {
                finalList[i] = even[i / 2];
                if (!(i == integers.Length - 1)) finalList[i + 1] = odd[i / 2];
            }
            for (int i = 0; i < finalList.Length - 1; i++)
            {
                if (finalList[i] > finalList[i + 1]) return i;
            }
            return -1;
        }

        static void Main(string[] args)
        {
            int testCases = int.Parse(Console.ReadLine());
            for (int i = 0; i < testCases; i++)
            {
                int x = 0;
                String arrayLength = Console.ReadLine();
                int[] integers = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), int.Parse);
                if ((x = GetTroubleSortStatus(integers)) == -1) Console.WriteLine("Case #" + (i + 1) + ": OK");
                else Console.WriteLine("Case #" + (i + 1) + ": " + x);
            }
        }
    }
}
