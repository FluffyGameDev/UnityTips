using UnityEngine;

public class FollowEntity : MonoBehaviour
{
    [SerializeField]
    private Transform m_Target;
    [SerializeField]
    private float m_Speed;
    [SerializeField]
    private Vector3 m_Offset;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, m_Target.position + m_Offset, m_Speed * Time.deltaTime);
    }
}
