using System;
using System.Linq;
using GrueChallenge.Models;

namespace GrueChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Grue grue = new Grue();
            Usine usine = new Usine(grue, new[] { 4, 2, 5, 0, 2, 6 });

            do {
                Console.Clear();
                if (usine.ExecuterAction(Solve(grue.Position, usine.Stacks, grue.IsGrabbing)))
                {
                    break;
                }
                Vue.Draw(grue, usine);
            }
            while (Console.ReadKey().KeyChar != 'q');
        }

        public static string Solve(int clawPos, int[] stacks, bool clawIsGrabbing)
        {
            var max = stacks.Max();
            var min = stacks.Min();
            var posMin = Array.IndexOf(stacks, min);
            var posMax = Array.IndexOf(stacks, max);

            if (EstNiveau(stacks) && !clawIsGrabbing)
            {
                return default(string);
            }
            else if (UtiliserModeOrdonner(stacks))
            {
                if (EstEnOrdreDecroissant(stacks) && !clawIsGrabbing)
                {
                    return default(string);
                }
                else
                {
                    var lastPosMin = Array.LastIndexOf(stacks, min);
                    var lastPosMax = Array.LastIndexOf(stacks, max);

                    if (clawIsGrabbing)
                    {
                        if (clawPos == posMin) return "PLACE";
                        return (clawPos > posMin ? "LEFT" : "RIGHT");
                    }
                    else
                    {
                        if (clawPos == lastPosMax) return "PICK";
                        return (clawPos > lastPosMax ? "LEFT" : "RIGHT");
                    }
                }
            }

            // Pas à niveau; Mettre à niveau.
            if (clawIsGrabbing)
            {
                if (clawPos == posMin) return "PLACE";
                return (clawPos > posMin ? "LEFT" : "RIGHT");
            }
            else
            {
                if (clawPos == posMax) return "PICK";
                return (clawPos > posMax ? "LEFT" : "RIGHT");
            }
        }

        private static bool EstNiveau(int[] stacks) => stacks.Max() == stacks.Min();

        private static bool UtiliserModeOrdonner(int[] stacks) => stacks.Max() == stacks.Min() + 1;

        private static bool EstEnOrdreDecroissant(int[] stacks)
        {
            int precedent = stacks.Max();

            for (int i = 0; i < stacks.Length; i++)
            {
                if (stacks[i] <= precedent)
                {
                    precedent = stacks[i];
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
