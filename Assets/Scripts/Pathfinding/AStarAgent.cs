using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
    public class AStarAgent : MonoBehaviour
    {
        [SerializeField] private float stoppingDistance = 0.1f;
        [SerializeField] private float movementSpeed = 1.0f;

        private AStarMap aStarMap = null;

        private List<AStarMapNode> currentPath = null;
        private Vector2 finalDestination = Vector2.zero;

        private Vector2 branchStartPosition = Vector2.zero;
        private Vector2 branchDestination = Vector2.zero;

        private int pathIndex = -1;
        private float lerpedAmount = 0.0f;
        private float pointDistance = 0.0f;


        private void Start()
        {
            aStarMap = FindObjectOfType<AStarMap>();
        }

        private void Update()
        {
            if (currentPath != null)
            {
                // Are we within stoppingDistance of the current branch destination?
                if (GetRemainingBranchDistance() < stoppingDistance)
                {
                    pathIndex++;
                    lerpedAmount = 0.0f;

                    // There are more nodes in the path
                    if (pathIndex < currentPath.Count)
                    {
                        branchStartPosition = transform.position;
                        branchDestination = currentPath[pathIndex].GetPositionWorld();
                        pointDistance = Vector2.Distance(branchStartPosition, branchDestination);
                    }
                    // We have reached the end of the path
                    else
                    {
                        currentPath = null;
                        pathIndex = -1;
                    }
                }
                // We are still outside the stoppingDistance
                else
                {
                    lerpedAmount = Mathf.Clamp(lerpedAmount + Time.deltaTime * movementSpeed, 0.0f, 1.0f);
                    transform.position = Vector2.Lerp(
                        branchStartPosition,
                        branchDestination,
                        lerpedAmount / pointDistance
                    );
                }
            }
        }

        public void SetDestination(Vector2 worldPositionDestination)
        {
            finalDestination = worldPositionDestination;
            CalculatePath();
        }

        public float GetRemainingDistance()
        {
            return Vector2.Distance(transform.position, finalDestination);
        }

        public float GetRemainingBranchDistance()
        {
            return Vector2.Distance(transform.position, branchDestination);
        }

        private void CalculatePath()
        {
            currentPath = null;
            pathIndex = -1;

            AStarMapNode start = aStarMap.GetNodeFromWorldSpace(transform.position);
            AStarMapNode goal = aStarMap.GetNodeFromWorldSpace(finalDestination);

            if (start != null && goal != null)
            {
                currentPath = AStarPathFinder.GetPath(aStarMap, start, goal);
            }

            if (currentPath != null && currentPath.Count > 0)
            {
                lerpedAmount = 0.0f;
                pathIndex = 0;
                branchStartPosition = transform.position;
                branchDestination = currentPath[pathIndex].GetPositionWorld();
                pointDistance = Vector2.Distance(branchStartPosition, branchDestination);
            }
        }

        public void Reset()
        {
            currentPath = null;
        }
    }
}