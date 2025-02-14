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

        override public string ToString()
        {
            string min = min_required > 0 ? min_required.ToString() : "0";
            string max = max_optional > 0 ? "-" + max_optional : "";
            string str = "[" + ingredient.ToString() + ": " + min + max + "]";
            return str;
        }

    }

    public class Recipe<ID> where ID : IEquatable<ID>
    {

        ID Name;
        internal List<Requirement<ID>> Requirements = [];

        public Recipe(ID name) { Name = name;}

        public void AddRequirement(ID ingredient, int min_required, int max_optional)
        {
            Requirements.Add(new Requirement<ID>(ingredient, min_required, max_optional));
        }


        // a is smaller than b iff
        // requirements of a fulfilled => requirements of b fulfilled
        public static bool operator <(Recipe<ID> lh, Recipe<ID> rh)
        {

            List<Requirement<ID>> remainingRH = new(rh.Requirements);

            foreach (Requirement<ID> requiredLH in lh.Requirements) {

                Requirement<ID>? potential_match = remainingRH.Find(requiredRH => EqualityComparer<ID>.Default.Equals(requiredLH.ingredient, requiredRH.ingredient));
                if (potential_match is null)
                    return false;

                Requirement<ID> match = (Requirement<ID>) potential_match;

                if (match.min_required > requiredLH.min_required)
                    return false;

                match.min_required += requiredLH.min_required;

                }

            return true;
                        
        }

        public static bool operator >(Recipe<ID> lh, Recipe<ID> rh)
        {
            return rh < lh;
        }


        public override string ToString()
        {
            string s = Name +": {";

            foreach(var req in Requirements)
                s += req.ToString();

            s += "}";

            return s;
        }

    }

}
