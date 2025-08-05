using System;
using System.Collections.Generic;
using UnityEngine;


public class PoolManager : MonoBehaviour
{
    [Serializable]
    public struct PoolDefinition
    {
        public string key;
        public PoolObject prefab;
        public int prewarmAmount;
    }

    [SerializeField] protected List<PoolDefinition> _poolDefinitions = new List<PoolDefinition>(); 
    protected static Dictionary<string, Pool> _pools = new Dictionary<string, Pool>();
    private static PoolManager _this = null;

    private void Awake()
    {
        if (_this)
        {
            Debug.LogError("[PoolManager] Already exists - destroying instance");
            Destroy(this.gameObject);
            return;
        }

        _this = this;
        InitPools();
        DontDestroyOnLoad(this);
    }

    protected void InitPools()
    {
        for (int i = 0; i < _poolDefinitions.Count; ++i)
        {
            PoolDefinition def = _poolDefinitions[i];

            GameObject prefabParent = new GameObject(def.key + "_PoolParent");
            prefabParent.transform.SetParent(this.transform);

            _pools.Add(def.key, new Pool(def.prewarmAmount, def.prefab, prefabParent.transform));
        }
    }

    public static PoolObject GetPooledObject(string key)
    {
        if (!_pools.ContainsKey(key))
        {
            Debug.LogError("[PoolManager] Pool with key '" + key + "' does not exist.");
            return null;
        }

        return _pools[key].GetPooledObject();
    }
}
