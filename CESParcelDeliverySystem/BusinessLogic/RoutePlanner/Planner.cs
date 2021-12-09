using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CESParcelDeliverySystem.BusinessLogic.RoutePlanner
{
	public class Planner
	{
        private List<(double, double)>[,] _tabuMatrix;
		private Graph _graph;
		private Queue<SearchNode> _openNodes;
		private List<SearchNode> _solutions;
		private int _noOfVertices;

		public Planner(int noOfVertices, int network) //network should not be a var
		{
			this._noOfVertices = noOfVertices;
			this._tabuMatrix = new List<(double, double)>[noOfVertices, noOfVertices];
			for (int i = 0; i < noOfVertices; i++)
            {
				for (int j = 0; j < noOfVertices; j++)
				{
					this._tabuMatrix[i, j] = new List<(double, double)>();
				}
			}
			//i[0, 0].Add((4, 2));
			this._graph = CreateGraph(network);
			this._openNodes = new Queue<SearchNode>();
			this._solutions = new List<SearchNode>();
		}

        public List<SearchNode> Plan(int location, int destination)
        {
			int[] visited = new int[_noOfVertices];
			visited[location] = 1;
			SearchNode initialNode = new SearchNode(new List<Edge>(), visited, 0, 0, location);
			_openNodes.Enqueue(initialNode);
			while (_openNodes.Any())
            {
				SearchNode currentNode = _openNodes.Dequeue();
				List<SearchNode> children = CreateChildren(currentNode, destination);
				foreach (SearchNode child in children)
                {
					_openNodes.Enqueue(child);
				}
			}
			return _solutions;
		}

        private List<SearchNode> CreateChildren(SearchNode currentNode, int destination)
        {
			List<SearchNode> children = new List<SearchNode>();
			List<Edge> relevantAdjacent = GetRelevantAdjacent(currentNode);
			foreach (Edge edge in relevantAdjacent)
            {
				SearchNode child = currentNode.CreateChild(edge, currentNode.Location());
				if (child.Location() == destination)
                {
					_solutions.Add(child);
                } else if (!Prune(child))
                {
					children.Add(child);
                }
            }
			return children;
		}

        private bool Prune(SearchNode child)
        {
			return false; //no pruning atm
        }

        private Graph CreateGraph(int network)
        {
			return GetDummyGraph();
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

		public Graph GetDummyGraph()
		{
			Graph graph = new Graph(4);
			graph.AddEdge(new Edge(0, 1, 3, 2, 0));
			graph.AddEdge(new Edge(1, 2, 2, 3, 0));
			graph.AddEdge(new Edge(0, 2, 7, 4, 0));
			graph.AddEdge(new Edge(0, 3, 2, 2, 0));
			graph.AddEdge(new Edge(3, 2, 4, 4, 0));
			return graph;
		}
	}
}
