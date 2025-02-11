namespace BitLabyrinth.RecipeTree
{
    internal class RecipeTree<ID> where ID : IEquatable<ID>
    {

        //

        //

        public bool AddNode(Recipe<ID> rec)
        {
            return false;
            // exact match ==: return false

            // if < than some node: 

            // if > than some node: gather

            // if sameSpot as some node: return false

            // if 

            // gather nodes of current level that are either
            // <, >, <>

            // < recipes: become children of new node
            // >

        }

    }
}
