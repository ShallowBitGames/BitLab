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

//RecipeTest.Run();

string pathCategories = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory) + "..\\..\\..\\Recipe\\recipes\\categories.xml";

RecipeTest.path = pathCategories;
RecipeTest.Run();

//TODO: clean path calculation
Console.WriteLine(pathCategories);
