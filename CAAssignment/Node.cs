using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAAssignment
{
    public class Node<T>
    {
        private string _id;
        private T data;
        private NodeList<T> neighbour;

        public Node()
        {
            _id = "";
            neighbour = new NodeList<T>();
        }

        public Node(string id, T item)
        {
            _id = id;
            data = item;
            neighbour = new NodeList<T>();
        }

        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public T Value
        {
            get { return data; }
            set { data = value; }
        }

        public NodeList<T> Neighbour
        {
            get { return neighbour; }
        }

        public override string ToString()
        {
            return data.ToString();
        }

        public void AddNeighbour(Node<T> neighbourNode)
        {
            //Check if neighbour already in list
            if (!neighbour.Contains(neighbourNode.ID))
            {
                neighbour.Add(neighbourNode);
            }
        }

    }
}
