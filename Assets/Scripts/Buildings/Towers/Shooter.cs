using UnityEngine;

namespace Buildings.Towers
{
    public class Shooter : MonoBehaviour
    {
        [Tooltip("Shots per second")]
        [SerializeField] private float fireRate = 1.0f;

        [SerializeField] private Transform firePoint = null;
        [SerializeField] private Projectile projectilePrefab = null;

        [SerializeField] private Targeter targeter = null;

        private float coolDown = 0.0f;
        private float currentCooldown = 0.0f;

        private void Start()
        {
            coolDown = 1.0f / fireRate;
        }

        private void LateUpdate()
        {
            if (currentCooldown > 0.0f)
            {
                currentCooldown -= Time.deltaTime;
            }
            else if (targeter.HasTarget())
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            Vector3 firePointPosition = firePoint.position;

            Projectile projectile = Instantiate(
                projectilePrefab,
                firePointPosition,
                Quaternion.identity,
                transform
            );

            projectile.SetTarget(targeter.GetTarget());
            currentCooldown = coolDown;
        }
    }
}