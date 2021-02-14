using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Pathfinding
{
    public class AStarMap : MonoBehaviour
    {
        [SerializeField]
        private Vector2 mapOrigin = Vector2.zero;
        [SerializeField]
        private int width = 10;
        [SerializeField]
        private int height = 10;
        [SerializeField]
        private float pointRadius = 0.4f;

        private Camera mainCamera;

        private AStarMapNode[,] mapNodes;

        private AStarMapNode selectedNode = null;
        private AStarMapNode selectedNode2 = null;

        private List<AStarMapNode> path = null;


        [SerializeField]
        private bool drawTiles = false;
        [SerializeField]
        private bool drawLines = false;
        [SerializeField]
        private float tileGap = 0.05f;

        private void Start()
        {
            mainCamera = Camera.main;

            Init();
        }

        private void Init()
        {
            mapNodes = new AStarMapNode[width, height];

            CreateMapNodes();
            CreateNeighborMapping();
        }

        private void CreateMapNodes()
        {
            Vector2 topLeft = mapOrigin - new Vector2(width * pointRadius, height * pointRadius);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Vector2 positionToScan = new Vector2(x * pointRadius * 2, y * pointRadius * 2) + topLeft;
                    RaycastHit2D hit = Physics2D.CircleCast(positionToScan, pointRadius, Vector2.one, 0.0f);
                    if (!hit.collider)
                    {
                        AStarMapNode node = new AStarMapNode();
                        node.Init(x, y, positionToScan);
                        mapNodes[x, y] = node;
                    }
                }
            }
        }

        private void CreateNeighborMapping()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    AStarMapNode current = mapNodes[x, y];
                    if (current != null)
                    {
                        // North y + 1
                        if (y < height - 1)
                        {
                            current.SetNeighbor(AStarDirection.NORTH, mapNodes[x, y + 1]);
                            // North East x + 1, y + 1
                            if (x < width - 1)
                            {
                                current.SetNeighbor(AStarDirection.NORTH_EAST, mapNodes[x + 1, y + 1]);
                            }

                            // North West x - 1 , y + 1
                            if (x > 0)
                            {
                                current.SetNeighbor(AStarDirection.NORTH_WEST, mapNodes[x - 1, y + 1]);
                            }
                        }

                        // South y - 1
                        if (y > 0)
                        {
                            current.SetNeighbor(AStarDirection.SOUTH, mapNodes[x, y - 1]);
                            // South East x + 1, y - 1
                            if (x < width - 1)
                            {
                                current.SetNeighbor(AStarDirection.SOUTH_EAST, mapNodes[x + 1, y - 1]);
                            }

                            // South West x - 1, y - 1
                            if (x > 0)
                            {
                                current.SetNeighbor(AStarDirection.SOUTH_WEST, mapNodes[x - 1, y - 1]);
                            }
                        }

                        // East x + 1
                        if (x < width - 1)
                        {
                            current.SetNeighbor(AStarDirection.EAST, mapNodes[x + 1, y]);
                        }

                        // West x - 1
                        if (x > 0)
                        {
                            current.SetNeighbor(AStarDirection.WEST, mapNodes[x - 1, y]);
                        }
                    }
                }
            }
        }

        private void OnDrawGizmos()
        {
            if (!drawTiles)
            {
                return;
            }

            if (mapNodes == null)
            {
                Init();
            }
            else if (mapNodes.GetLength(0) != width ||
                     mapNodes.GetLength(1) != height)
            {
                Init();
            }

            foreach (AStarMapNode node in mapNodes)
            {
                if (node != null)
                {
                    if (selectedNode != null && selectedNode.GetPositionInGrid() == node.GetPositionInGrid())
                    {
                        Gizmos.color = Color.red;
                    }
                    else if (selectedNode2 != null && selectedNode2.GetPositionInGrid() == node.GetPositionInGrid())
                    {
                        Gizmos.color = Color.blue;
                    }
                    else if (path != null)
                    {
                        Gizmos.color = Color.gray;
                        foreach (AStarMapNode pathNode in path)
                        {
                            if (pathNode.GetPositionInGrid() == node.GetPositionInGrid())
                            {
                                Gizmos.color = Color.green;
                            }
                        }
                    }
                    else
                    {
                        Gizmos.color = Color.gray;
                    }

                    Vector2 pos = node.GetPositionWorld();
                    Gizmos.DrawCube(pos, new Vector2(
                        pointRadius * 2 - tileGap,
                        pointRadius * 2 - tileGap
                    ));

                    if (drawLines)
                    {
                        foreach (AStarMapNode neighbor in node.GetNeighbors().Values)
                        {
                            if (neighbor != null)
                            {
                                Gizmos.color = Color.white;
                                Vector2 pos2 = neighbor.GetPositionWorld();
                                Gizmos.DrawLine(pos, pos2);
                            }
                        }
                    }
                }
            }
        }

        private void Update()
        {
            if (Mouse.current.leftButton.isPressed)
            {
                Vector2 worldPoint = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
                Vector2Int point = WorldSpaceToGraphSpace(worldPoint);

                AStarMapNode node = GetNode(point);
                if (node != null)
                {
                    selectedNode = node;
                    path = null;
                }
            }
            else if (Mouse.current.rightButton.isPressed)
            {
                Vector2 worldPoint = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
                Vector2Int point = WorldSpaceToGraphSpace(worldPoint);

                AStarMapNode node = GetNode(point);
                if (node != null)
                {
                    selectedNode2 = node;
                    path = null;
                }
            }

            if (path == null)
            {
                path = AStarPathFinder.GetPath(this, selectedNode, selectedNode2);
            }
        }

        public Vector2Int WorldSpaceToGraphSpace(Vector2 worldSpace)
        {
            Vector2 topLeft = mapOrigin - new Vector2(width * pointRadius, height * pointRadius);
            Vector2 offsetWorldSpace = (worldSpace - topLeft) / (pointRadius * 2);

            return new Vector2Int(
                Mathf.RoundToInt(offsetWorldSpace.x),
                Mathf.RoundToInt(offsetWorldSpace.y)
            );
        }

        public AStarMapNode GetNodeFromWorldSpace(Vector2 worldSpace)
        {
            Vector2Int graphSpace = WorldSpaceToGraphSpace(worldSpace);
            return GetNode(graphSpace);
        }

        public AStarMapNode GetNode(Vector2Int graphSpace)
        {
            if (
                graphSpace.x >= 0 && graphSpace.y >= 0 &&
                graphSpace.x < width && graphSpace.y < height
            )
            {
                AStarMapNode node = mapNodes[graphSpace.x, graphSpace.y];
                return node;
            }

            return null;
        }

        public float Cost(AStarMapNode current, AStarMapNode next)
        {
            return 1.0f;
        }
    }
}