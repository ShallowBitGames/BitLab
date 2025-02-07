using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace BitLabyrinth.RecipeTree
{

    internal struct Requirement<ID> where ID : IEquatable<ID>
    {
        internal ID ingredient { get; }
        internal int min_required { get; set; }
        internal int max_optional { get; set; }

        public Requirement(ID ingredient, int min_required, int max_optional)
        {
            this.ingredient = ingredient;
            this.min_required = min_required;
            this.max_optional = max_optional;
        }

        internal bool isOptional() { return min_required == 0; }

        internal bool fulfils_required(ID ing, int amount) { return Equals(ing, ingredient) && amount >= min_required; }

        internal bool fulfils_optional(ID ing, int amount) { return Equals(ing, ingredient) && (max_optional == -1 || amount < max_optional); }

    }

    public class Recipe<ID> where ID : IEquatable<ID> {
    
    
        Requirement<ID>[] requirements = [];

    
        bool includes(Requirement<ID> searched)
    
        {
        
            foreach (Requirement<ID> req in requirements)
        
            {

                if (req.fulfils_required(searched.ingredient, searched.min_required))
                {
                    return true;
                }
        
            }

        
            return false;
    
        }
    }

    bool subtract(Requirement<ID> reqs)
    {
        return true;
    } 
    
    }

    public static bool operator <(Recipe<ID> lh, Recipe<ID> rh)
        {
            bool smaller_reqs = false;
            bool larger_reqs = false;

            Recipe<ID> reqs_left = rh.requirements;

            foreach (Requirement<ID> req in lh.requirements)
            {
                if (reqs_left.includes(req))
                {
                    smaller_reqs = true;
                    reqs_left.subtract(req);
                }
            }
        }

        public static bool operator >(Recipe<ID> lh, Recipe<ID> rh)
        {
            return false;
        }

    }
}
