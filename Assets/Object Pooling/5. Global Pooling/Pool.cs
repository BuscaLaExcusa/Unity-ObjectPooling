using System.Collections.Generic;
using UnityEngine;

public class Pool
{
    protected PoolObject _prefab;
    protected Transform _poolParent;

    private Queue<PoolObject> _pool = new Queue<PoolObject>();

    public int Amount { get => _pool.Count; }

    public Pool(int amount, PoolObject prefab, Transform poolParent)
    {
        _prefab = prefab;
        _poolParent = poolParent;
        InitPool(amount);
    }

    private void InitPool(int amount)
    {
        _pool = new Queue<PoolObject>();
        for (int i = 0; i < amount; ++i)
        {
            _pool.Enqueue(SpawnPrefab());
        }
    }

    private PoolObject SpawnPrefab()
    {
        GameObject go = MonoBehaviour.Instantiate(_prefab.gameObject, _poolParent);
        go.SetActive(false);
        return go.GetComponent<PoolObject>();
    }

    public PoolObject GetPooledObject()
    {
        PoolObject poolObject = _pool.Count > 0 ? _pool.Dequeue()
                                               : SpawnPrefab();
        poolObject.gameObject.SetActive(true);
        poolObject.OnPooledObjectDisabled.AddListener(StorePooledObject);
        return poolObject;
    }

    private void StorePooledObject(PoolObject po)
    {
        po.OnPooledObjectDisabled.RemoveListener(StorePooledObject);
        _pool.Enqueue(po);
    }
}