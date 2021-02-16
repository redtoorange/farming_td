using System;
using UnityEngine;

namespace Enemies
{
    public class Mob : MonoBehaviour
    {
        public static event Action<Mob> OnMobSpawned;
        public static event Action<Mob> OnMobDestroyed;

        [SerializeField] private Health mobHealth = null;
        [SerializeField] private Animator animation = null;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("EndZone"))
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            mobHealth.OnDie += HandleOnDeath;
            OnMobSpawned?.Invoke(this);
        }

        private void OnDestroy()
        {
            mobHealth.OnDie -= HandleOnDeath;
            OnMobDestroyed?.Invoke(this);
        }

        private void HandleOnDeath(Health health)
        {
            animation.SetTrigger("Die");
        }

        private void DeathAnimationComplete()
        {
            Destroy(gameObject);
        }
    }
}