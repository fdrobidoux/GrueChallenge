using System;
using System.Collections.Generic;
using System.Text;

namespace GrueChallenge.Models
{
    public class Usine
    {
        public Grue Grue { get; private set; }
        public int[] Stacks { get; private set; }

        public Usine(Grue grue, int[] stacks)
        {
            Grue = grue;
            Stacks = stacks;
        }

        public void ExecuterAction(string action)
        {
            switch (action)
            {
                case "PLACE":
                    FaireDeposer();
                    break;
                case "PICK":
                    EnleverDuDessus();
                    break;
                case "LEFT":
                    VersLaGauche();
                    break;
                case "RIGHT":
                    VersLaDroite();
                    break;
                case default(string):
                    Console.WriteLine("GG WP");
                    Console.ReadKey();
                    System.Threading.Thread.CurrentThread.Abort();
                    break;
                default:
                    Console.WriteLine("ERROR: ACTION NOT FOUND: {0}", action);
                    break;
            }
        }

        private void FaireDeposer()
        {
            if (Grue.IsGrabbing)
            {
                Grue.IsGrabbing = false;
                Stacks[Grue.Position] += 1;
            }
        }

        private void EnleverDuDessus()
        {
            if (!Grue.IsGrabbing && Stacks[Grue.Position] > 0)
            {
                Grue.IsGrabbing = true;
                Stacks[Grue.Position] -= 1;
            }
        }

        private void VersLaGauche()
        {
            if (Grue.Position > 0)
            {
                Grue.Position -= 1;
            }
        }

        private void VersLaDroite()
        {
            if (Grue.Position < Stacks.Length - 1)
            {
                Grue.Position += 1;
            }
        }
    }
}
