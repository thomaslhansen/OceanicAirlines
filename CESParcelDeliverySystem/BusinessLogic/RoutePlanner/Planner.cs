using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CESParcelDeliverySystem.BusinessLogic.RoutePlanner
{
	public class Planner
	{
        private List<Tuple<double, double>>[,] _tabuMatrix;
		private Graph _graph;
		private Queue<SearchNode> _openNodes;
		private List<SearchNode> _solutions;
		private int _noOfVertices;
		private int _location;
		private int _destination;

		public Planner(int noOfVertices, int network, int location, int destination) //network should not be a var
		{
			this._location = location;
			this._destination = destination;
			this._noOfVertices = noOfVertices;
			this._tabuMatrix = new List<Tuple<double, double>>[noOfVertices, noOfVertices];
			for (int i = 0; i < noOfVertices; i++)
            {
				for (int j = 0; j < noOfVertices; j++)
				{
					this._tabuMatrix[i, j] = new List<Tuple<double, double>>();
				}
			}
			//i[0, 0].Add((4, 2));
			this._graph = CreateGraph(noOfVertices, network);
			this._openNodes = new Queue<SearchNode>();
			this._solutions = new List<SearchNode>();
		}

        public List<SearchNode> Plan()
        {
			int[] visited = new int[_noOfVertices];
			visited[_location] = 1;
			SearchNode initialNode = new SearchNode(new List<Edge>(), visited, 0, 0, _location);
			_openNodes.Enqueue(initialNode);
			while (_openNodes.Any())
            {
				SearchNode currentNode = _openNodes.Dequeue();
				List<SearchNode> children = CreateChildren(currentNode);
				foreach (SearchNode child in children)
                {
					_openNodes.Enqueue(child);
				}
			}
			return _solutions;
		}

        private List<SearchNode> CreateChildren(SearchNode currentNode)
        {
			List<SearchNode> children = new List<SearchNode>();
			List<Edge> relevantAdjacent = GetRelevantAdjacent(currentNode);
			foreach (Edge edge in relevantAdjacent)
            {
				SearchNode child = currentNode.CreateChild(edge, currentNode.Location());
				if (Prune2(child))
                {
					continue;
                }
				if (child.Location() == _destination)
                {
					_solutions.Add(child);
					continue;
                }
				children.Add(child);
            }
			return children;
		}

        private bool Prune(SearchNode child)
        {
			return false;
        }

		private bool Prune2(SearchNode child)
		{
			int loc1 = 0;
			int loc2 = 0;
			if (_location < child.Location()) {
				loc1 = _location;
				loc2 = child.Location();
			} else
            {
				loc1 = child.Location();
				loc2 = _location;
			}
			foreach (Tuple<double,double> tuple in _tabuMatrix[loc1, loc2])
            {
				if (child.IsDominatedBy(tuple.Item1, tuple.Item2)) {
					return true;
                }
				//potential cleanup of dominate list.
			}
			_tabuMatrix[loc1, loc2].Add(new Tuple<double, double>(child.Cost(), child.Time()));
			return false;
		}

		private Graph CreateGraph(int noOfVertices, int network)
        {
			return GetDummyGraphPlaneTruck(noOfVertices);
		}

		public List<Edge> GetRelevantAdjacent(SearchNode currentNode)
        {
			int currentLocation = currentNode.Location();
			List<Edge> unfilteredAdj = this._graph.Adj(currentLocation);
			List<Edge> filteredAdj = new List<Edge>();
			foreach (Edge edge in unfilteredAdj)
			{
				if (currentNode.Visited()[edge.Target(currentLocation)] == 0)
				{
					filteredAdj.Add(edge);
				}
			}
			return filteredAdj;
		}

		public Graph GetDummyGraphExample()
		{
			Graph graph = new Graph(4);
			graph.AddEdge(new Edge(0, 1, 3, 2, 0));
			graph.AddEdge(new Edge(1, 2, 2, 3, 0));
			graph.AddEdge(new Edge(0, 2, 7, 4, 0));
			graph.AddEdge(new Edge(0, 3, 2, 2, 0));
			graph.AddEdge(new Edge(3, 2, 4, 4, 0));
			return graph;
		}

		public Graph GetDummyGraphPlane(int noOfVertices)
		{
			Graph graph = new Graph(noOfVertices);
			graph.AddEdge(new Edge(24, 26, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(24, 16, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(16, 20, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(16, 9, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(26, 9, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(26, 6, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(20, 22, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(9, 15, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(9, 10, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(22, 14, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(14, 10, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(14, 11, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(14, 8, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(14, 1, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(14, 13, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(10, 15, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(11, 6, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(6, 23, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(23, 3, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(23, 29, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(29, 12, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(29, 8, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(12, 1, 68, 8, Edge.Type.Plane));

			return graph;
		}

		public Graph GetDummyGraphPlaneTruck(int noOfVertices)
		{
			Graph graph = new Graph(noOfVertices);
			graph.AddEdge(new Edge(24, 26, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(24, 16, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(16, 20, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(16, 9, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(26, 9, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(26, 6, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(20, 22, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(9, 15, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(9, 10, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(22, 14, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(14, 10, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(14, 11, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(14, 8, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(14, 1, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(14, 13, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(10, 15, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(11, 6, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(6, 23, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(23, 3, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(23, 29, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(29, 12, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(29, 8, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(12, 1, 68, 8, Edge.Type.Plane));
			graph.AddEdge(new Edge(24, 27, 15, 20, Edge.Type.Truck));
			graph.AddEdge(new Edge(24, 16, 6, 8, Edge.Type.Truck));
			graph.AddEdge(new Edge(24, 19, 15, 20, Edge.Type.Truck));
			graph.AddEdge(new Edge(27, 26, 9, 12, Edge.Type.Truck));
			graph.AddEdge(new Edge(26, 18, 18, 24, Edge.Type.Truck));
			graph.AddEdge(new Edge(18, 3, 12, 16, Edge.Type.Truck));
			graph.AddEdge(new Edge(18, 6, 9, 12, Edge.Type.Truck));
			graph.AddEdge(new Edge(6, 19, 24, 32, Edge.Type.Truck));
			graph.AddEdge(new Edge(6, 23, 12, 16, Edge.Type.Truck));
			graph.AddEdge(new Edge(6, 2, 6, 8, Edge.Type.Truck));
			graph.AddEdge(new Edge(6, 30, 12, 16, Edge.Type.Truck));
			graph.AddEdge(new Edge(6, 21, 21, 28, Edge.Type.Truck));
			graph.AddEdge(new Edge(23, 0, 9, 12, Edge.Type.Truck));
			graph.AddEdge(new Edge(0, 12, 9, 12, Edge.Type.Truck));
			graph.AddEdge(new Edge(0, 29, 9, 12, Edge.Type.Truck));
			graph.AddEdge(new Edge(12, 31, 18, 24, Edge.Type.Truck));
			graph.AddEdge(new Edge(31, 17, 9, 12, Edge.Type.Truck));
			graph.AddEdge(new Edge(31, 29, 15, 20, Edge.Type.Truck));
			graph.AddEdge(new Edge(29, 17, 18, 24, Edge.Type.Truck));
			graph.AddEdge(new Edge(29, 2, 6, 8, Edge.Type.Truck));
			graph.AddEdge(new Edge(29, 11, 12, 16, Edge.Type.Truck));
			graph.AddEdge(new Edge(11, 15, 12, 16, Edge.Type.Truck));
			graph.AddEdge(new Edge(15, 4, 9, 12, Edge.Type.Truck));
			graph.AddEdge(new Edge(15, 17, 30, 40, Edge.Type.Truck));
			graph.AddEdge(new Edge(15, 28, 33, 44, Edge.Type.Truck));
			graph.AddEdge(new Edge(15, 8, 33, 44, Edge.Type.Truck));
			graph.AddEdge(new Edge(4, 30, 18, 24, Edge.Type.Truck));
			graph.AddEdge(new Edge(4, 21, 15, 20, Edge.Type.Truck));
			graph.AddEdge(new Edge(4, 6, 18, 24, Edge.Type.Truck));
			graph.AddEdge(new Edge(30, 21, 21, 28, Edge.Type.Truck));
			graph.AddEdge(new Edge(21, 25, 15, 20, Edge.Type.Truck));
			graph.AddEdge(new Edge(25, 9, 12, 16, Edge.Type.Truck));
			graph.AddEdge(new Edge(25, 20, 15, 20, Edge.Type.Truck));
			graph.AddEdge(new Edge(9, 20, 15, 20, Edge.Type.Truck));
			graph.AddEdge(new Edge(20, 5, 12, 16, Edge.Type.Truck));
			graph.AddEdge(new Edge(5, 16, 24, 32, Edge.Type.Truck));
			graph.AddEdge(new Edge(16, 19, 15, 20, Edge.Type.Truck));
			graph.AddEdge(new Edge(10, 28, 12, 16, Edge.Type.Truck));
			graph.AddEdge(new Edge(10, 14, 12, 16, Edge.Type.Truck));
			graph.AddEdge(new Edge(28, 17, 15, 20, Edge.Type.Truck));
			graph.AddEdge(new Edge(28, 8, 9, 12, Edge.Type.Truck));
			graph.AddEdge(new Edge(8, 17, 12, 16, Edge.Type.Truck));
			return graph;
		}
	}
}
