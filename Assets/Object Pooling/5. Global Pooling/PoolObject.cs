using UnityEngine;
using UnityEngine.Events;

public class PoolObject : MonoBehaviour
{
    [SerializeField] public UnityEvent<PoolObject> OnPooledObjectDisabled = new UnityEvent<PoolObject>();

    protected void OnDisable()
    {
        OnPooledObjectDisabled?.Invoke(this);
    }
}
