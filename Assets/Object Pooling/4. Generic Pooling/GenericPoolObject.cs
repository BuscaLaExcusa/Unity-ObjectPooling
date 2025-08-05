using UnityEngine;
using UnityEngine.Events;

public class GenericPoolObject : MonoBehaviour
{
    [SerializeField] public UnityEvent<GenericPoolObject> OnPooledObjectDisabled = new UnityEvent<GenericPoolObject>();

    protected void OnDisable()
    {
        OnPooledObjectDisabled?.Invoke(this);
    }
}
