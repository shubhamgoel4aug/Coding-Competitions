// This file contains the solution of CodeJam 2017 Qualifiers Problem - Tidy Numbers

using System;
using System.IO;

namespace CodeJam
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream stream = new FileStream("B-large.in", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(new FileStream("output.txt", FileMode.Create, FileAccess.Write));
            int T = Convert.ToInt32(reader.ReadLine());
            for (int i = 0; i < T; i++)
            {
                Boolean found = false;
                long data = long.Parse(reader.ReadLine());
                while (!found)
                {
                    char[] dataChar = data.ToString().ToCharArray();
                    int[] dataInt = new int[dataChar.Length];
                    dataInt[0] = Convert.ToInt32(dataChar[0].ToString());
                    Boolean inspector = false;
                    for (int j = 1; j < dataChar.Length; j++)
                    {
                        dataInt[j] = Convert.ToInt32(dataChar[j].ToString());
                        if (dataInt[j - 1] > dataInt[j])
                        {
                            dataInt[j] = 0;
                            data = long.Parse(String.Join("", dataInt));
                            inspector = true;
                            break;
                        }
                    }
                    if (!inspector)
                        found = true;
                    else
                        data--;
                }
                writer.WriteLine("Case #" + (i + 1) + ": " + data);
            }
            writer.Close();
            Console.ReadKey();
        }
    }
}
