using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using BitLabyrinth.RecipeTree;

namespace Tests
{
    public static class RecipeTest
    {
        public static void Run()
        {

            Recipe<string> factea = new("FACTea");
            factea.AddRequirement("Fennel", 1, 4);
            factea.AddRequirement("Anise", 1, 3);
            factea.AddRequirement("Cumin", 1, 2);
            factea.AddRequirement("Water", 1, 0);
            factea.AddRequirement("Herb", 0, 2);


            foreach (var r in factea.Requirements)
                Console.WriteLine(r);
        }
    }
}