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

        public static void Draw(Grue grue)
        {
            string espacementsInitiaux = "";
            for (int i = 0; i < grue.position; i++)
            {
                espacementsInitiaux += ESPACEMENT;
            }
            
            espacementsInitiaux += (grue.IsGrabbing ? GRUE_GRAB : GRUE_VIDE);


            
            Console.WriteLine()
        }
    }
}
