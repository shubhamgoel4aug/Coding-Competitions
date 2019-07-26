// This file contains the solution of CodeJam 2017 Qualifiers Problem - Oversized Pancake Flipper

using System;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeJam
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream stream = new FileStream("A-small-practice.in", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(new FileStream("output.txt", FileMode.Create, FileAccess.Write));
            int T = Convert.ToInt32(reader.ReadLine());
            for (int i = 0; i < T; i++)
            {
                String[] data = reader.ReadLine().Trim().Split(' ');
                String formula = data[0];
                int flipperSize = Convert.ToInt32(data[1]);
                int count = 0;
                Boolean impossible = false;
                while (formula.Count(x => x == '+') != formula.Length && !impossible)
                {
                    try
                    {
                        int index = formula.IndexOf('-');
                        StringBuilder builder = new StringBuilder(formula);
                        builder.Replace('+', '*', index, flipperSize).Replace('-', '+', index, flipperSize).Replace('*', '-', index, flipperSize);
                        formula = builder.ToString();
                        count++;
                    }
                    catch (Exception)
                    {
                        writer.WriteLine("Case #" + (i + 1) + ": IMPOSSIBLE");
                        impossible = true;
                        continue;
                    }
                }
                if (!impossible)
                    writer.WriteLine("Case #" + (i + 1) + ": " + count);
            }
            writer.Close();
            Console.ReadKey();
        }
    }
}
