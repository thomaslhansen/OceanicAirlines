using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CESParcelDeliverySystem.BusinessLogic.RoutePlanner
{
    public class Graph
    {
        private readonly int _v;
        private int _e;
        private List<Edge>[] _adj;

        public Graph(int V)
        {
            if (V < 0)
                throw new Exception("Number of vertices in a Graph must be nonnegative");

            this._v = V;

            this._e = 0;

            _adj = new List<Edge>[V];

            for (int v = 0; v < V; v++)
            {
                _adj[v] = new List<Edge>();
            }
        }

        public int V()
        {
            return _v;
        }

        public int E()
        {
            return _e;
        }
        public List<Edge> Adj(int v)
        {
            return _adj[v];
        }

        public void AddEdge(Edge e)
        {
            int v = e.Source();
            int w = e.Target(v);
            _adj[v].Add(e);
            _adj[w].Add(e);
            _e++;
        }

    }
}
