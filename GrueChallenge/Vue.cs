using System;
using System.Collections.Generic;
using System.Text;
using GrueChallenge.Models;

namespace GrueChallenge
{
    public static class Vue
    {
        private static readonly string ESPACEMENT = "     ";
        private static readonly string GRUE_GRAB  = "< 1 >";
        private static readonly string GRUE_VIDE  = "< _ >";
        private static readonly string STACK      = "[ {0} ]";

        public static void Draw(Grue grue, Usine usine)
        {
            DrawGrue(grue, usine);
            DrawBoxes(usine);
        }

        private static void DrawGrue(Grue grue, Usine usine)
        {
            string espacementsInitiaux = "";

            for (int i = 0; i < grue.Position; i++)
            {
                espacementsInitiaux += ESPACEMENT;
            }
            
            espacementsInitiaux += (grue.IsGrabbing ? GRUE_GRAB : GRUE_VIDE);

            for (int i = grue.Position; i < usine.Stacks.Length; i++)
            {
                espacementsInitiaux += ESPACEMENT;
            }

            Console.SetCursorPosition(0, 0);
            Console.Write(espacementsInitiaux);
        }

        private static void DrawBoxes(Usine usine)
        {
            string strview = "";

            foreach (int nbr in usine.Stacks)
            {
                strview += String.Format(STACK, nbr);
            }

            Console.SetCursorPosition(0, 1);
            Console.Write(strview);
        }
    }
}
