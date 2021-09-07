using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/AI/Health/HealthChannel")]
public class HealthChannel : ScriptableObject
{
    public delegate void HealthChangedCallback(Health health);
    public HealthChangedCallback OnHealthChanged;

    public void RaiseHealthChanged(Health health)
    {
        OnHealthChanged?.Invoke(health);
    }
}
