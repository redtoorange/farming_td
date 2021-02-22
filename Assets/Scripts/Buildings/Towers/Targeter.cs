using Enemies;
using UnityEngine;

namespace Buildings.Towers
{
    public class Targeter : MonoBehaviour
    {
        [SerializeField] private float range = 10.0f;
        [SerializeField] private LayerMask targetMask = new LayerMask();

        private Targetable currentTarget = null;

        public bool HasTarget()
        {
            return currentTarget != null;
        }

        public Targetable GetTarget()
        {
            return currentTarget;
        }

        private void FixedUpdate()
        {
            if (currentTarget != null)
            {
                // Verify Still In Range
                if (Mathf.Abs(Vector2.Distance(transform.position, currentTarget.transform.position)) > range)
                {
                    Debug.Log("Target out of range");
                    currentTarget.OnTargetDestroyed -= HandleOnTargetDestroyed;
                    currentTarget = null;
                }
            }

            // Target is out of range or dead?
            if (currentTarget == null)
            {
                FindTarget();
            }
        }

        private void FindTarget()
        {
            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, range, Vector2.one, 0, targetMask);
            if (hits.Length > 0)
            {
                // Find closest
                Vector2 pos = transform.position;
                float min = Mathf.Infinity;
                int minIndex = -1;
                for (int i = 0; i < hits.Length; i++)
                {
                    float dist = Vector2.SqrMagnitude(hits[i].point - pos);
                    if (dist < min)
                    {
                        min = dist;
                        minIndex = i;
                    }
                }

                if (minIndex >= 0)
                {
                    currentTarget = hits[minIndex].collider.GetComponent<Targetable>();
                    currentTarget.OnTargetDestroyed += HandleOnTargetDestroyed;
                }
            }
        }

        private void HandleOnTargetDestroyed()
        {
            currentTarget.OnTargetDestroyed -= HandleOnTargetDestroyed;
            currentTarget = null;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, range);
        }
    }
}