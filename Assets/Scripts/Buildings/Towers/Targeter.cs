﻿using Enemies;
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

        private void Update()
        {
            if (currentTarget != null)
            {
                // Verify Still In Range
                if (Vector3.Distance(transform.position, currentTarget.transform.position) > range)
                {
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
            RaycastHit[] hits = Physics.SphereCastAll(transform.position, range, Vector3.forward, 0, targetMask);
            if (hits.Length > 0)
            {
                // Find closest
                Vector3 pos = transform.position;
                float min = Mathf.Infinity;
                int minIndex = -1;
                for (int i = 0; i < hits.Length; i++)
                {
                    if (Vector3.SqrMagnitude(hits[i].point - pos) < min)
                    {
                        minIndex = i;
                    }
                }

                if (minIndex >= 0)
                {
                    currentTarget = hits[minIndex].collider.GetComponent<Targetable>();
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, range);
        }
    }
}