using System;
using Enemies.AI;
using Pathfinding;
using UnityEngine;

namespace Enemies
{
    public class MobMover2D : MonoBehaviour
    {
        public static event Action<MobMover2D> OnNeedWaypoint;

        [SerializeField] private Health health = null;
        [SerializeField] private AStarAgent aStarAgent = null;
        [SerializeField] private float cutoffDistance = 0.25f;

        private WayPoint currentWaypoint = null;
        private bool shouldMove = true;

        private void Start()
        {
            health.OnDie += HandleOnDeath;
        }

        private void OnDestroy()
        {
            health.OnDie -= HandleOnDeath;
        }

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
            if (shouldMove && (currentWaypoint == null || aStarAgent.GetRemainingDistance() < cutoffDistance))
            {
                OnNeedWaypoint?.Invoke(this);
            }
        }

        private void HandleOnDeath(Health health)
        {
            shouldMove = false;
            aStarAgent.Reset();
        }
    }
}