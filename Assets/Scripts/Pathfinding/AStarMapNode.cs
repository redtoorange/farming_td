using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
    public class AStarMapNode
    {
        private static AStarDirection[] Directions =
        {
            AStarDirection.NORTH,
            AStarDirection.SOUTH,
            AStarDirection.EAST, 
            AStarDirection.WEST,
            
            AStarDirection.NORTH_EAST, AStarDirection.NORTH_WEST,
            AStarDirection.SOUTH_EAST, AStarDirection.SOUTH_WEST,
        };

        private int x;
        private int y;
        private Vector2 worldPosition;
        private Dictionary<AStarDirection, AStarMapNode> neighbors;


        public void Init(int x, int y, Vector2 worldPosition)
        {
            this.x = x;
            this.y = y;
            this.worldPosition = worldPosition;

            neighbors = new Dictionary<AStarDirection, AStarMapNode>(8);
            foreach (AStarDirection direction in Directions)
            {
                neighbors[direction] = null;
            }
        }

        public AStarMapNode GetNeighbor(AStarDirection direction)
        {
            return neighbors[direction];
        }

        public void SetNeighbor(AStarDirection direction, AStarMapNode neighbor)
        {
            neighbors[direction] = neighbor;
        }

        public Vector2Int GetPositionInGrid()
        {
            return new Vector2Int(x, y);
        }

        public Vector2 GetPositionWorld()
        {
            return worldPosition;
        }

        public Dictionary<AStarDirection, AStarMapNode> GetNeighbors()
        {
            return neighbors;
        }
    }
}