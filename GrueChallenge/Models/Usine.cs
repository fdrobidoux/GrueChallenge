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

        public void FaireDeposer()
        {
            if (Grue.IsGrabbing)
            {
                Grue.IsGrabbing = false;
                Stacks[Grue.Position] += 1;
            }
        }

        public void EnleverDuDessus()
        {
            if (!Grue.IsGrabbing && Stacks[Grue.Position] > 0)
            {
                Grue.IsGrabbing = true;
                Stacks[Grue.Position] -= 1;
            }
        }

        public void VersLaGauche()
        {
            if (Grue.Position > 0)
            {
                Grue.Position -= 1;
            }
        }

        public void VersLaDroite()
        {
            if (Grue.Position < Stacks.Length - 1)
            {
                Grue.Position += 1;
            }
        }
    }
}
