using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CESParcelDeliverySystem.BusinessLogic.RoutePlanner
{
    public class SearchNode
    {
        private List<Edge> _route;
        private int[] _visited;
        private double _cost;
        private double _time;
        private int _currentLocation;

        public SearchNode(List<Edge> route, int[] visited, double cost, double time, int currentLocation)
        {
            this._route = route;
            this._visited = visited;
            this._cost = cost;
            this._time = time;
            this._currentLocation = currentLocation;
        }

        public List<Edge> Route()
        {
            return _route;
        }

        public int[] Visited()
        {
            return _visited;
        }

        public double Cost()
        {
            return _cost;
        }

        public double Time()
        {
            return _time;
        }
        public int Location()
        {
            return _currentLocation;
        }

        public SearchNode CreateChild(Edge edge, int currentNode)
        {
            List<Edge> route = this._route.ToList(); //this might not work, clone the list, not the elements please.
            route.Add(edge);
            int[] visited = (int[])this._visited.Clone();
            visited[currentNode] = 1;
            return new SearchNode(route, visited, this.Cost()+edge.Cost(), this.Time()+edge.Time(), edge.Target(currentNode));
        }
    }
}
