using Enemies;
using UnityEngine;

namespace Buildings.Towers
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float speed = 10.0f;
        [SerializeField] private Rigidbody rigidbody = null;
        [SerializeField] private int damage = 10;

        private bool updateThisFrame = true;
        private Targetable target = null;

        public int GetDamage()
        {
            return damage;
        }

        public void SetTarget(Targetable target)
        {
            this.target = target;
        }

        private void FixedUpdate()
        {
            if (target != null)
            {
                if (updateThisFrame)
                {
                    Vector3 direction = target.GetAimPoint().position - transform.position;
                    rigidbody.velocity = direction.normalized * speed;
                    updateThisFrame = false;
                }
                else
                {
                    updateThisFrame = true;
                }
            }
        }

        private void Start()
        {
            Invoke(nameof(DestroySelf), 1.5f);
        }

        private void DestroySelf()
        {
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            Health health = other.GetComponent<Health>();
            if (health)
            {
                health.DealDamage(damage);
            }

            DestroySelf();
        }
    }
}