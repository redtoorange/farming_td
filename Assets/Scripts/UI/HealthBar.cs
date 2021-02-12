using Enemies;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Health health = null;
        [SerializeField] private Gradient healthGradient = new Gradient();
        [SerializeField] private Image healthBarImage = null;

        private void Start()
        {
            UpdateHealthBar(health.GetHealthPercent());
        }

        private void OnEnable()
        {
            health.OnTakeDamage += HandleOnDamage;
        }

        private void OnDisable()
        {
            health.OnTakeDamage -= HandleOnDamage;
        }

        private void HandleOnDamage(float percentRemaining)
        {
            UpdateHealthBar(percentRemaining);
        }

        private void UpdateHealthBar(float percentRemaining)
        {
            healthBarImage.fillAmount = percentRemaining;
            healthBarImage.color = healthGradient.Evaluate(percentRemaining);
        }
    }
}