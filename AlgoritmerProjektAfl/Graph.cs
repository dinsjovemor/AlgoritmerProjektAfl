using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoritmerProjektAfl
{
    public class Graph<T>
    {
        private Dictionary<T, Node<T>> nodes;

        public Graph()
        {
            nodes = new Dictionary<T, Node<T>>();
        }

        public void AddNode(T value)
        {
            if (!nodes.ContainsKey(value))
            {
                nodes[value] = new Node<T>(value);
            }
        }

        public void AddDirectedEdge(T from, T to)
        {
            if (nodes.ContainsKey(from) && nodes.ContainsKey(to))
            {
                nodes[from].AddEdge(nodes[to]);
            }
        }

        public void AddEdge(T from, T to)
        {
            AddDirectedEdge(from, to);
            AddDirectedEdge(to, from);
        }

        public Node<T> GetNode(T value)
        {
            if (nodes.ContainsKey(value))
            {
                return nodes[value];
            }
            else
            {
                return null;
            }
        }


        public void DFS()
        {

        }

        public void BFS()
        {

        }

    }

}
