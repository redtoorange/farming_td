using UnityEngine;

namespace Enemies.AI
{
    public class WayPointController : MonoBehaviour
    {
        private WayPoint[] wayPoints;

        private void Start()
        {
            wayPoints = GetComponentsInChildren<WayPoint>();
            for (int i = 0; i < wayPoints.Length; i++)
            {
                wayPoints[i].SetOrder(i);
            }
        }

        private void OnDrawGizmos()
        {
            WayPoint[] wayPoints = GetComponentsInChildren<WayPoint>();

            Gizmos.color = Color.white;
            for (int i = 0; i < wayPoints.Length - 1; i++)
            {
                Gizmos.DrawLine(
                    wayPoints[i].transform.position,
                    wayPoints[i + 1].transform.position
                );
            }
        }

        public WayPoint GetNextWaypoint(WayPoint currentWaypoint)
        {
            if (currentWaypoint == null)
            {
                return wayPoints[0];
            }

            int nextWaypoint = currentWaypoint.GetOrder() + 1;
            if (nextWaypoint >= wayPoints.Length)
            {
                return null;
            }

            return wayPoints[nextWaypoint];
        }
    }
}