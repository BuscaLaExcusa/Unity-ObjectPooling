using System.Collections.Generic;
using UnityEngine;

public class ShurikenSpawner_BasicPooling : MonoBehaviour
{
    [SerializeField] protected GameObject _shurikenPrefab;
    [SerializeField] protected Transform _fieldCenter;
    [SerializeField] protected Transform _shurikensParent;
    [SerializeField] protected int _framesCooldown = 5;
    [SerializeField] protected int _warmUpShurikens = 5;

    protected int _cooldown = 0;
    protected Queue<GameObject> _pooledShurikens = new Queue<GameObject>();

    private void Awake()
    {
        _cooldown = Random.Range(0, _framesCooldown); // Aleatoreizamos cuándo empieza a disparar para que parezca más orgánico
        WarmUpPool();
    }

    private void FixedUpdate()
    {
        if (_cooldown > 0)
        {
            --_cooldown;
            return;
        }

        SpawnShuriken();
        _cooldown = _framesCooldown;
    }

    private void WarmUpPool()
    {
        for (int i = 0; i < _warmUpShurikens; ++i)
        {
            GameObject shurikenGO = Instantiate(_shurikenPrefab, _shurikensParent);
            shurikenGO.SetActive(false);    // Los shurikens que guardamos deben estar siempre deshabilitados
            _pooledShurikens.Enqueue(shurikenGO);
        }
    }

    private void SpawnShuriken()
    {
        GameObject shurikenGO = GetPooledShuriken() ?? Instantiate(_shurikenPrefab, _shurikensParent);
        Shuriken_BasicPooling shuriken = shurikenGO.GetComponent<Shuriken_BasicPooling>();
        shuriken.Init(transform.position, _fieldCenter);
        shuriken.OnShurikenDisabled.AddListener(OnShurikenDisabled_StoreShuriken);
    }

    private GameObject GetPooledShuriken()
    {
        if (_pooledShurikens.Count <= 0)
        {
            return null;
        }

        GameObject shurikenGO = _pooledShurikens.Dequeue();
        shurikenGO.SetActive(true); // Habilitamos el objeto antes de devolverlo para que todo funcione igual
        return shurikenGO;
    }

    private void OnShurikenDisabled_StoreShuriken(GameObject shurikenGO)
    {
        Shuriken_BasicPooling shuriken = shurikenGO.GetComponent<Shuriken_BasicPooling>();
        shuriken.OnShurikenDisabled.RemoveListener(OnShurikenDisabled_StoreShuriken);
        
        _pooledShurikens.Enqueue(shurikenGO);
    }
}
