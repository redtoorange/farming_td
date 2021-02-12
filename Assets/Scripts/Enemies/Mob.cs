using System;
using UnityEngine;

namespace Enemies
{
    public class Mob : MonoBehaviour
    {
        public static event Action<Mob> OnMobSpawned;
        public static event Action<Mob> OnMobDestroyed;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("EndZone"))
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            OnMobSpawned?.Invoke(this);
        }

        private void OnDestroy()
        {
            OnMobDestroyed?.Invoke(this);
        }
    }
}