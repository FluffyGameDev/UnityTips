using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float m_MaxHealth = 100.0f;
    [SerializeField]
    private UnityEvent<Health> m_OnHealthChanged;
    [SerializeField]
    private UnityEvent m_OnDead;

    private float m_CurrentHealth = 100.0f;


    public float MaxHealth => m_MaxHealth;
    public float CurrentHealth => m_CurrentHealth;


    private void Start()
    {
        m_CurrentHealth = m_MaxHealth;
    }

    public void ApplyDamage(float amount)
    {
        m_CurrentHealth -= amount;
        if (m_CurrentHealth <= 0.0f)
        {
            m_CurrentHealth = 0.0f;
            m_OnDead?.Invoke();
        }

        m_OnHealthChanged?.Invoke(this);
    }
}
