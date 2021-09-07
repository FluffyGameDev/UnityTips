using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/AI/Affinity/Faction")]
public class Faction : ScriptableObject
{
    [SerializeField]
    private Faction[] m_EnemyFactions;

    public bool IsEnemyFaction(Faction faction)
    {
        return m_EnemyFactions != null && m_EnemyFactions.Contains(faction);
    }
}
