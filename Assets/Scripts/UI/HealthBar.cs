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
        [SerializeField] private GameObject healthBarContainer = null;

        private void Start()
        {
            UpdateHealthBar();
        }

        private void OnEnable()
        {
            health.OnTakeDamage += HandleOnDamage;
        }

        private void OnDisable()
        {
            health.OnTakeDamage -= HandleOnDamage;
        }

        private void HandleOnDamage()
        {
            UpdateHealthBar();
        }

        private void UpdateHealthBar()
        {
            float fillPercent = health.GetHealthPercent();
            
            healthBarImage.color = healthGradient.Evaluate(fillPercent);
            healthBarImage.fillAmount = fillPercent;
            healthBarContainer.SetActive(fillPercent  > 0 && fillPercent < 1);
        }
    }
}