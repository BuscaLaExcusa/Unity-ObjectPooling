using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenPool : MonoBehaviour
{
    [SerializeField] protected GameObject _shurikenPrefab;
    [SerializeField] protected Transform _shurikensParent;
    [SerializeField] protected int _warmUpShurikens = 5;

    private Queue<GameObject> _pooledShurikens = new Queue<GameObject>();

    public int Amount { get => _pooledShurikens.Count; }

    private void Awake()
    {
        WarmUpPool();
    }

    private void WarmUpPool()
    {
        _pooledShurikens = new Queue<GameObject>();
        for (int i = 0; i < _warmUpShurikens; i++)
        {
            _pooledShurikens.Enqueue(SpawnShuriken());
        }
    }

    private GameObject SpawnShuriken()
    {
        GameObject shurikenGO = Instantiate(_shurikenPrefab, _shurikensParent);
        shurikenGO.SetActive(false);
        return shurikenGO;
    }

    public Shuriken_AdvancedPooling GetPooledShuriken()
    {
        GameObject shurikenGO = _pooledShurikens.Count > 0 ? _pooledShurikens.Dequeue()
                                                            : SpawnShuriken();
        shurikenGO.SetActive(true);

        Shuriken_AdvancedPooling shuriken = shurikenGO.GetComponent<Shuriken_AdvancedPooling>();
        shuriken.OnShurikenDisabled.AddListener(OnShurikenDisabled_StoreShuriken);
        return shuriken;
    }
    private void OnShurikenDisabled_StoreShuriken(GameObject shurikenGO)
    {
        Shuriken_AdvancedPooling shuriken = shurikenGO.GetComponent<Shuriken_AdvancedPooling>();
        shuriken.OnShurikenDisabled.RemoveListener(OnShurikenDisabled_StoreShuriken);

        _pooledShurikens.Enqueue(shurikenGO);
    }
}