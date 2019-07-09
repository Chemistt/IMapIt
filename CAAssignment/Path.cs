using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAAssignment
{
    public class Path<T> : IComparable
    {
        NodeList<T> pathList;
        int weight;

        public Path()   // Default Constructor
        {
            pathList = new NodeList<T>();
            weight = 0;
        }

        public Path(NodeList<T> newList)    // Constructor
        {
            pathList = new NodeList<T>();
            weight = 0;

            foreach (Node<T> node in newList)
            {
                pathList.Add(node);
                weight++;
            }//end of foreach
        }

        public void Add(Node<T> newNode)    //Add nodes
        {
            pathList.Add(newNode);
            weight++;
        }

        public Node<T> GetFirst()           //Get first node from list
        {
            return pathList.GetFirst();
        }

        public Node<T> GetLast()           //Get last node from list
        {
            return pathList.GetLast();
        }

        public void RemoveLast()            //Remove last node from list
        {
            pathList.RemoveLast();
            weight--;
        }

        public bool Contains(string value)
        {
            return pathList.Contains(value);
        }

        public bool Contains(Node<T> node)
        {
            return pathList.Contains(node.Value);
        }

        public NodeList<T> PathList
        {
            get { return pathList; }
        }

        public int Weight
        {
            get { return weight; }
        }
        public int CompareTo(Object obj)
        {
            Path<T> newPath = (Path<T>)obj;
            return this.weight.CompareTo(newPath.weight);
        }
    }
}
