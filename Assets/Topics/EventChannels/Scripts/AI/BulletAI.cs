using UnityEngine;

public class BulletAI : MonoBehaviour
{
    [SerializeField]
    private float m_LifeTime = 10.0f;
    [SerializeField]
    private float m_Damage = 10.0f;

    private float m_CreationTime = 0;

    private void Start()
    {
        m_CreationTime = Time.time;
    }

    private void Update()
    {
        if (Time.time > m_CreationTime + m_LifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);

        Affinity myAffinity = GetComponent<Affinity>();
        Affinity otherAffinity = collision.gameObject.GetComponent<Affinity>();
        if (myAffinity != null && otherAffinity != null)
        {

            if (myAffinity.Faction.IsEnemyFaction(otherAffinity.Faction))
            {
                Health health = otherAffinity.GetComponent<Health>();
                if (health != null)
                {
                    health.ApplyDamage(m_Damage);
                }
            }
        }
    }
}
