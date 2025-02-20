using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace BitLabyrinth.Recipe
{
    internal class Categories<ID>
    {
        Dictionary<ID, List<ID>> categoryDict;

        
        public Categories(string path)
        {
            initiliaze(path);
        }

        void initiliaze(string path)
        {
            //TODO !...!
            string file = File.ReadAllText(path);

            //JsonDocument json = JsonDocument.Parse(file);

            //JsonElement root = json.RootElement;
            //foreach()
            

            // für parent -> add to category dict

        }

        //void add(string path)

    }
}
