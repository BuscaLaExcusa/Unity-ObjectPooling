using System.Collections.Generic;
using UnityEngine;

public class ShurikenSpawner_AdvancedPooling : MonoBehaviour
{
    [SerializeField] protected ShurikenPool _pool;
    [SerializeField] protected Transform _fieldCenter;
    [SerializeField] protected int _framesCooldown = 5;

    protected int _cooldown = 0;

    private void Awake()
    {
        _cooldown = Random.Range(0, _framesCooldown); 
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

    private void SpawnShuriken()
    {
        Shuriken_AdvancedPooling shuriken = _pool.GetPooledShuriken();
        shuriken.Init(transform.position, _fieldCenter);
    }

}
