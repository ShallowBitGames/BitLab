using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitLabyrinth.RecipeTree
{

    internal struct Requirement<ID> where ID : IEquatable<ID>
    {
        ID ingredient;
        int min_required;
        int max_optional;

        public Requirement(ID ingredient, int min_required, int max_optional)
        {
            this.ingredient = ingredient;
            this.min_required = min_required;
            this.max_optional = max_optional;
        }

        bool isOptional() { return min_required == 0; }

        bool fulfils_required(ID ing, int amount) { return Equals(ing, ingredient) && amount >= min_required; }

        bool fulfils_optional(ID ing, int amount) { return Equals(ing, ingredient) && (max_optional == -1 || amount < max_optional); }

    }

    public class Recipe<ID> where ID : IEquatable<ID> {
        
    //    Requirement<ID>[] requirements = [];

    
    }

    bool operator<(Recipe lh, Recipe rh) 
    {
            bool smaller_reqs = false;
            bool larger_reqs = false;
            bool inconclusive = false;
            
            for()
    }

        public static bool operator <(Recipe lh, Recipe rh)
        {

        }
    }
