using System;
using UnityEngine;

namespace Enemies
{
    public class Targetable : MonoBehaviour
    {
        public event Action OnTargetDestroyed;
        
        [SerializeField] private Transform aimPoint;
        [SerializeField] private Health health;
        [SerializeField] private Collider2D collider2D;
        private void OnEnable()
        {
            health.OnDie += HandleOnDie;
        }

        private void OnDisable()
        {
            health.OnDie -= HandleOnDie;
        }

        public Transform GetAimPoint()
        {
            return aimPoint;
        }

        private void HandleOnDie(Health health)
        {
            collider2D.enabled = false;
            OnTargetDestroyed?.Invoke();
        }
    }
}