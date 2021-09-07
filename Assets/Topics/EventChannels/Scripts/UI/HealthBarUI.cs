using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField]
    private HealthChannel m_HealthChannel;
    [SerializeField]
    private Image m_HealthBar;
    [SerializeField]
    private Color m_FullHealthColor;
    [SerializeField]
    private Color m_LowHealthColor;

    private void Start()
    {
        m_HealthChannel.OnHealthChanged += OnHealthChanged;
    }

    private void OnDestroy()
    {
        m_HealthChannel.OnHealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(Health health)
    {
        float healthRatio = health.CurrentHealth / health.MaxHealth;
        m_HealthBar.transform.localScale = new Vector3(healthRatio, 1.0f, 1.0f);
        m_HealthBar.color = Color.Lerp(m_LowHealthColor, m_FullHealthColor, healthRatio);
    }
}
