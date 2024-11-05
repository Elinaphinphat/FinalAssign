using System;
using System.Diagnostics;
using FinalAssignment;

namespace FinalAssignment {
    class Program{
        static void Main(String [] args) {
            if (args.Length == 0)
            {
                Console.WriteLine("Input filepath.");
                return;
            }
            string filePath = args[0];
            Solver.RunObject(new string[] {filePath});
        }
    }
}