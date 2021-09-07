using UnityEngine;

public class Affinity : MonoBehaviour
{
    [SerializeField]
    private Faction m_Faction;

    public Faction Faction => m_Faction;
}
