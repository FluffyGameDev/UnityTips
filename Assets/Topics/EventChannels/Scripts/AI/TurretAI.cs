using UnityEngine;

public class TurretAI : MonoBehaviour
{
    [SerializeField]
    private float m_MaxSearchRadius = 10.0f;
    [SerializeField]
    private float m_ReloadDuration = 2.0f;
    [SerializeField]
    private float m_BulletSpawnDistance = 1.5f;
    [SerializeField]
    private float m_BulletImpulseForce = 10.0f;
    [SerializeField]
    private Rigidbody m_Bullet;

    private Faction m_Turretfaction = null;
    private float m_NextShotTime = 0.0f;

    private void Start()
    {
        Affinity affinity = GetComponent<Affinity>();
        if (affinity != null)
        {
            m_Turretfaction = affinity.Faction;
        }
    }

    private void FixedUpdate()
    {
        if (Time.time > m_NextShotTime)
        {
            m_NextShotTime = Time.time + m_ReloadDuration;

            Transform target = FindClosestTarget();
            if (target != null)
            {
                transform.LookAt(target);

                Vector3 direction = (target.position - transform.position).normalized;

                Rigidbody newBullet = Instantiate(m_Bullet);
                newBullet.transform.position = transform.position + direction * m_BulletSpawnDistance;
                newBullet.AddForce(direction * m_BulletImpulseForce, ForceMode.Impulse);
            }
        }
    }

    private Transform FindClosestTarget()
    {
        Transform bestCandidate = null;
        float bestCandidateDistance = float.MaxValue;

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, m_MaxSearchRadius);
        foreach (var hitCollider in hitColliders)
        {
            Affinity currentCandidate = hitCollider.GetComponent<Affinity>();
            if (currentCandidate != null)
            {
                if (m_Turretfaction != null && m_Turretfaction.IsEnemyFaction(currentCandidate.Faction))
                {
                    float distance = Vector3.Distance(transform.position, currentCandidate.transform.position);
                    if (distance < bestCandidateDistance)
                    {
                        bestCandidateDistance = distance;
                        bestCandidate = currentCandidate.transform;
                    }
                }
            }
        }

        return bestCandidate;
    }
}
