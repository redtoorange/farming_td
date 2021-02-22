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

        public void SetTarget(Targetable newTarget)
        {
            if (newTarget != null)
            {
                target = newTarget;
                target.OnTargetDestroyed += HandleOnTargetDestroyed;

                Vector2 moveDirection = transform.position - newTarget.GetAimPoint().position;
                if (moveDirection != Vector2.zero)
                {
                    float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.AngleAxis(angle, Vector2.right);
                }
            }
            else
            {
                Debug.LogError("Projectile spawned without a target");
                Destroy(gameObject);
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

        private void HandleOnTargetDestroyed()
        {
            target = null;
            DestroySelf();
        }

        private void Start()
        {
            Invoke(nameof(DestroySelf), 1.5f);
        }

        private void DestroySelf()
        {
            // Remove self from the target's event
            if (target != null)
            {
                target.OnTargetDestroyed -= HandleOnTargetDestroyed;
            }

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