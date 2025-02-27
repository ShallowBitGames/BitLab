using BitLabyrinth.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Tests;

//string projectFiles = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory);

//Categories<string> cat = new (projectFiles + "recipes\categories.json");


//TODO: clean path calculation
string pathRecipeDir = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory) + "..\\..\\..\\Recipe\\recipes\\";

RecipeTest.path = pathRecipeDir;
RecipeTest.Run();


