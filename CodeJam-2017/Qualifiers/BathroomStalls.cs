// This file contains the solution of CodeJam 2017 Qualifiers Problem - Bathroom Stalls

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeJam
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream stream = new FileStream("C-large-practice.in", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(new FileStream("output.txt", FileMode.Create, FileAccess.Write));
            int T = Convert.ToInt32(reader.ReadLine());
            for (int i = 0; i < T; i++)
            {
                String[] data = reader.ReadLine().Trim().Split(' ');
                long N = long.Parse(data[0]);
                long K = long.Parse(data[1]);
                long minLsRs = 0, maxLsRs = 0;
                if (N != K)
                {
                    Dictionary<long, long> C = new Dictionary<long, long>();
                    C.Add(N, 1);
                    List<long> stallPosition = new List<long>();                    
                    stallPosition.Add(N);
                    long P = 0;
                    while(P < K)
                    {
                        long max = stallPosition.Max();
                        if(max % 2 == 0)
                        {
                            maxLsRs = max / 2;
                            minLsRs = maxLsRs - 1;
                        }
                        else minLsRs = maxLsRs = max / 2;
                        stallPosition.RemoveAll(x => x == max);
                        stallPosition.Add(maxLsRs);
                        stallPosition.Add(minLsRs);
                        if (C.ContainsKey(maxLsRs)) C[maxLsRs] += C[max];
                        else C.Add(maxLsRs, C[max]);
                        if (C.ContainsKey(minLsRs)) C[minLsRs] += C[max];
                        else C.Add(minLsRs, C[max]);
                        P += C[max];
                    }
                }
                Console.WriteLine("Case #" + (i + 1) + ": " + maxLsRs + " " + minLsRs);
                writer.WriteLine("Case #" + (i + 1) + ": " + maxLsRs + " " + minLsRs);
            }
            writer.Close();
            Console.ReadKey();
        }
    }
}
