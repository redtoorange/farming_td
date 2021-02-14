using System;
using Enemies.AI;
using Pathfinding;
using UnityEngine;

namespace Enemies
{
    public class MobMover2D : MonoBehaviour
    {
        public static event Action<MobMover2D> OnNeedWaypoint;

        [SerializeField] private AStarAgent aStarAgent = null;
        [SerializeField] private float cutoffDistance = 0.25f;

        private WayPoint currentWaypoint = null;

        public WayPoint GetWayPoint()
        {
            return currentWaypoint;
        }

        public void SetWaypoint(WayPoint newWayPoint)
        {
            currentWaypoint = newWayPoint;
            aStarAgent.SetDestination(currentWaypoint.transform.position);
        }

        private void Update()
        {
            if (currentWaypoint == null || aStarAgent.GetRemainingDistance() < cutoffDistance)
            {
                OnNeedWaypoint?.Invoke(this);
            }
        }
    }
}