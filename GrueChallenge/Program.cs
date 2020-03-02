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
            bool modeMettreEnOrdreDecroissant = false;

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
                    modeMettreEnOrdreDecroissant = true;
                }
            }

            // Pas à niveau; Mettre à niveau.
            if (clawIsGrabbing)
            {
                int posMin = Array.IndexOf(stacks, stacks.Min());

                if (clawPos == posMin) return "PLACE";
                return (clawPos > posMin ? "LEFT" : "RIGHT");
            }
            else
            {
                int max = stacks.Max();
                int posMax = (modeMettreEnOrdreDecroissant ? Array.LastIndexOf(stacks, max) : Array.IndexOf(stacks, max));

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
