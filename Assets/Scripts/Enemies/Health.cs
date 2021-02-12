using System;
using UnityEngine;

namespace Enemies
{
    public class Health : MonoBehaviour
    {
        public event Action<Health> OnDie;
        public event Action<float> OnTakeDamage;
        
        [SerializeField] private int maxHealth = 100;

        private int currentHealth;

        private void Awake()
        {
            currentHealth = maxHealth;
        }

        public void DealDamage(int amount)
        {
            currentHealth -= amount;
            OnTakeDamage?.Invoke(GetHealthPercent());

            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }

        public float GetHealthPercent()
        {
            return currentHealth / (float) maxHealth;
        }

        private void OnDestroy()
        {
            OnDie?.Invoke(this);
        }
    }
}