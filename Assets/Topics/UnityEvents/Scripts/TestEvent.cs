using UnityEngine;
using UnityEngine.Events;

public class TestEvent : MonoBehaviour
{
    [SerializeField]
    private UnityEvent MyEvent;

    private void OnMouseDown()
    {
        MyEvent?.Invoke();
    }
}
