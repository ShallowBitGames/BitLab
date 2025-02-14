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
        // check if each of b's requirements fits into a's requirements
        public static bool operator <(Recipe<ID> lh, Recipe<ID> rh)
        {

            List<Requirement<ID>> remainingLH = new(lh.Requirements);

            foreach (Requirement<ID> required_rh in rh.Requirements) {

                int matchID = remainingLH.FindIndex(required_lh => EqualityComparer<ID>.Default.Equals(required_rh.ingredient, required_lh.ingredient));
                if ( matchID == -1 )
                {
                    if (required_rh.min_required > 0)
                        return false;

                    // add a new matching requirement
                    remainingLH.Add(required_rh);
                    matchID = remainingLH.IndexOf(required_rh);

                }

                var match = remainingLH[matchID];

                if (match.min_required < required_rh.min_required)
                    return false;

                // not quite correct yet
                // but working on constraint examples
                match.min_required += required_rh.min_required;
                match.max_optional -= required_rh.max_optional;

                remainingLH[matchID] = match;

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
