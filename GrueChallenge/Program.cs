﻿using System;
using GrueChallenge.Models;

namespace GrueChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Grue grue = new Grue();
            Usine usine = new Usine(grue, new[] { 2, 1, 2, 2 });

            do
            {
                Console.Clear();
                Solve(grue.Position, usine.Stacks, grue.IsGrabbing);
                Vue.Draw(grue, usine);
            }
            while (Console.ReadKey().KeyChar != 'q');
        }

        public static string Solve(int clawPos, int[] stacks, bool clawIsGrabbing)
        {


            return default(string);
        }
    }
}