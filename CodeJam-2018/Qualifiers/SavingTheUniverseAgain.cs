// This file contains the solution of CodeJam 2018 Qualifiers Problem - Saving The Universe Again

using System;

namespace CodeJam
{
    class Program
    {
        static int GetTotalShootingPower(String Pattern)
        {
            int currentPower = 1;
            int totalShoot = 0;
            int C = 0;
            for (int i = 0; i < Pattern.Length; i++)
            {
                if (Pattern[i] == 'C')
                {
                    if (C == 0) currentPower = 2;
                    else currentPower *= 2;
                    C++;
                }
                if (Pattern[i] == 'S')
                {
                    totalShoot += currentPower;
                }
            }
            return totalShoot;
        }

        static void Main(string[] args)
        {
            int testCases = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < testCases; i++)
            {
                String power = Console.ReadLine();
                int minimumPower = Convert.ToInt32(power.Trim().Split(' ')[0]);
                String pattern = power.Trim().Split(' ')[1];
                int totalAttempts = 0;
                while (GetTotalShootingPower(pattern) > minimumPower)
                {
                    if (pattern.Contains("CS"))
                    {
                        pattern = pattern.Substring(0, pattern.LastIndexOf("CS")) + "SC" + pattern.Substring(pattern.LastIndexOf("CS") + 2);
                        totalAttempts++;
                    }
                    else
                    {
                        totalAttempts = -1;
                        break;
                    }
                }
                if (totalAttempts != -1) Console.Write("Case #" + (i + 1) + ": " + totalAttempts);
                else Console.Write("Case #" + (i + 1) + ": IMPOSSIBLE");
            }
        }
    }
}
