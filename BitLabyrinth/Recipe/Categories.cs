using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BitLabyrinth.Recipe
{
    internal class Categories<ID>
    {
        Dictionary<ID, List<ID>> categoryDict = new();

        
        public Categories(string path)
        {
            initiliaze(path);
        }

        void initiliaze(string path)
        {

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(path);

            XmlNode? root = xmlDocument.DocumentElement;

            if(root != null )
                readNode(root, new List<ID>());

        }

        // adds hierarchy information
        // avoids double entries
        void addToCategories(ID id, List<ID> parentCategories) 
        {
            if (!categoryDict.ContainsKey(id))
                categoryDict.Add(id, parentCategories);
            else
            {
                foreach (ID category in parentCategories)
                    if(!categoryDict[id].Contains(category))
                        categoryDict[id].Add(category);
            }
        }

        void readNode(XmlNode node, List<ID> parentCategories)
        {

            // !!!
            // For this to work, the type of ID must be something
            // that can internally be constructed from a string
            string idAttr = ((XmlElement)node).GetAttribute("id");
            ID id = (ID)Convert.ChangeType(idAttr, typeof(ID));

            
            addToCategories(id, parentCategories);

            List<ID> newParents = new List<ID>(parentCategories);
            newParents.Add(id);
            if(node.HasChildNodes)
                foreach (XmlNode childNode in node.ChildNodes)
                    readNode(childNode, newParents);

            
        }

        override public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(var pair in categoryDict)
            {
                sb.Append(pair.Key.ToString() + " is a: ");
                foreach(ID parent_category in pair.Value)
                    sb.Append(parent_category + ", ");
                
                sb.Remove(sb.Length - 2, 2);
                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }

        //void add(string path)


        // TODO
        // 
        //bool validateHierarchy()

    }
}
