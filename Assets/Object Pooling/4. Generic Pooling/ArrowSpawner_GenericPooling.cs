using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner_GenericPooling : MonoBehaviour
{
    [SerializeField] protected Pool _arrowPool;
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

        SpawnArrow();
        _cooldown = _framesCooldown;
    }

    private void SpawnArrow()
    {
        PoolObject arrowPO = _arrowPool.GetPooledObject();
        Arrow_GenericPooling arrow = arrowPO.GetComponent<Arrow_GenericPooling>();
        arrow.Init(transform.position, _fieldCenter);
    }

}
