using Enemies;
using UnityEngine;

namespace Buildings.Towers
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float speed = 10.0f;
        [SerializeField] private Rigidbody2D rigidbody = null;
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
            Vector2 moveDirection = transform.position - target.GetAimPoint().position;
            if (moveDirection != Vector2.zero)
            {
                float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector2.right);
            }
        }

        private void FixedUpdate()
        {
            if (target != null)
            {
                if (updateThisFrame)
                {
                    Vector2 dir = target.GetAimPoint().position - transform.position;
                    if (dir != Vector2.zero)
                    {
                        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                    }
                    
                    
                    rigidbody.velocity = dir.normalized * speed;
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

        private void OnTriggerEnter2D(Collider2D other)
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