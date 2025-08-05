using System.Collections.Generic;
using UnityEngine;

public class GenericPool : MonoBehaviour
{
    [SerializeField] protected PoolObject _prefab;
    [SerializeField] protected Transform _parent;
    [SerializeField] protected int _warmUpPrefabs = 5;

    private Queue<GenericPoolObject> _pool = new Queue<GenericPoolObject>();

    public int Amount { get => _pool.Count; }

    private void Awake()
    {
        WarmUpPool();
    }

    private void WarmUpPool()
    {
        _pool = new Queue<GenericPoolObject>();
        for (int i = 0; i < _warmUpPrefabs; ++i)
        {
            _pool.Enqueue(SpawnPrefab());
        }
    }

    private GenericPoolObject SpawnPrefab()
    {
        GameObject go = Instantiate(_prefab.gameObject, _parent);
        go.SetActive(false);
        return go.GetComponent<GenericPoolObject>();
    }

    public GenericPoolObject GetPooledObject()
    {
        GenericPoolObject poolObject = _pool.Count > 0 ? _pool.Dequeue()
                                               : SpawnPrefab();
        poolObject.gameObject.SetActive(true);
        poolObject.OnPooledObjectDisabled.AddListener(StorePooledObject);
        return poolObject;
    }

    private void StorePooledObject(GenericPoolObject po)
    {
        po.OnPooledObjectDisabled.RemoveListener(StorePooledObject);
        _pool.Enqueue(po);
    }
}