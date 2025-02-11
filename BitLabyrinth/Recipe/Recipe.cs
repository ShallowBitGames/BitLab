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

        internal bool includes(Requirement<ID> searched)
        {

            foreach (Requirement<ID> req in Requirements)
            {

                if (req.fulfils_required(searched.ingredient, searched.min_required))
                {
                    return true;
                }

            }


            return false;

        }

        internal bool subtract(Requirement<ID> req)
        {
            var ownreq = Requirements.Find(r => EqualityComparer<ID>.Default.Equals(r.ingredient, req.ingredient));
            if (Object.ReferenceEquals(ownreq, null)) return false;

            ownreq.max_optional -= req.min_required;
            ownreq.min_required -= req.min_required;
            return true;

        }



        public static bool operator <(Recipe<ID> lh, Recipe<ID> rh)
        {

            Recipe<ID> reqs_left = rh;

            foreach (Requirement<ID> req in lh.Requirements)
            {
                if (reqs_left.includes(req))
                    reqs_left.subtract(req);
                else
                    return false;
            }
            return true;
        }

        public static bool operator >(Recipe<ID> lh, Recipe<ID> rh)
        {
            Recipe<ID> reqs_left = lh;

            foreach(Requirement<ID> req in rh.Requirements)
                if(reqs_left.includes(req))
                    reqs_left.subtract(req); 
                else
                    return false;
        
            return true;
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
