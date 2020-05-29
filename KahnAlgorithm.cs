
using System.Collections.Generic;
using System.Linq;

namespace Graph
    {
        public class Kahn
        {
            public static List<Node> KahnAlgorithm(Graph graph)
            {
                var topSort = new List<Node>();
                var nodes = graph.Nodes.ToList();
                while (nodes.Count != 0)
                {
                    var nodeToDelete = nodes
                        .Where(node => !node.IncidentEdges.Any(edge => edge.To == node))
                        .FirstOrDefault();

                    if (nodeToDelete == null) return null;
                    nodes.Remove(nodeToDelete);
                    topSort.Add(nodeToDelete);
                    foreach (var edge in nodeToDelete.IncidentEdges.ToList())
                        graph.Delete(edge);
                }
                return topSort;
            }
        }
    }
