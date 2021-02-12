using UnityEngine;

namespace Enemies.AI
{
    public class WayPoint : MonoBehaviour
    {
        [SerializeField] private int order = -1;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, 0.25f);
        }

        public void SetOrder(int newOrder)
        {
            order = newOrder;
        }

        public int GetOrder()
        {
            return order;
        }
    }
}