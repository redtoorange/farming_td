using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
    public class AStarPathFinder
    {
        public static List<AStarMapNode> GetPath(AStarMap map, AStarMapNode start, AStarMapNode destination)
        {
            if (map == null || start == null || destination == null)
            {
                return null;
            }

            Dictionary<AStarMapNode, AStarMapNode> cameFrom = new Dictionary<AStarMapNode, AStarMapNode>();
            Dictionary<AStarMapNode, float> costSoFar = new Dictionary<AStarMapNode, float>();

            var frontier = new PriorityQueue<AStarMapNode>();
            frontier.Enqueue(start, 0);

            cameFrom[start] = start;
            costSoFar[start] = 0;

            while (frontier.Count > 0)
            {
                var current = frontier.Dequeue();

                if (current.Equals(destination))
                {
                    break;
                }

                foreach (var next in current.GetNeighbors().Values)
                {
                    if (next != null)
                    {
                        float newCost = costSoFar[current] + map.Cost(current, next);
                        if (!costSoFar.ContainsKey(next)
                            || newCost < costSoFar[next])
                        {
                            costSoFar[next] = newCost;
                            float priority = newCost + Heuristic(next, destination);
                            frontier.Enqueue(next, priority);
                            cameFrom[next] = current;
                        }
                    }
                }
            }

            if (cameFrom.ContainsKey(destination))
            {
                List<AStarMapNode> path = new List<AStarMapNode>();
                path.Add(destination);

                AStarMapNode currentNode = destination;
                while (currentNode != start)
                {
                    currentNode = cameFrom[currentNode];
                    path.Add(currentNode);
                }

                path.Reverse();
                return path;
            }

            return null;
        }

        private static float Heuristic(AStarMapNode a, AStarMapNode b)
        {
            Vector2Int aPos = a.GetPositionInGrid();
            Vector2Int bPos = b.GetPositionInGrid();
            
            return Mathf.Abs(aPos.x - bPos.x) + Mathf.Abs(aPos.y - bPos.y);
        }
    }
}