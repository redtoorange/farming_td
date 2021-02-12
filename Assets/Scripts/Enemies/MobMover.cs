using System;
using Enemies.AI;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    public class MobMover : MonoBehaviour
    {
        public static event Action<MobMover> OnNeedWaypoint;

        [SerializeField] private NavMeshAgent navMeshAgent = null;
        [SerializeField] private float cutoffDistance = 0.25f;
        
        private WayPoint currentWaypoint = null;

        public WayPoint GetWayPoint()
        {
            return currentWaypoint;
        }

        public void SetWaypoint(WayPoint newWayPoint)
        {
            currentWaypoint = newWayPoint;
            navMeshAgent.SetDestination(newWayPoint.transform.position);
        }

        private void Update()
        {
            if (currentWaypoint == null || navMeshAgent.remainingDistance < cutoffDistance)
            {
                OnNeedWaypoint?.Invoke(this);
            }
        }
    }
}