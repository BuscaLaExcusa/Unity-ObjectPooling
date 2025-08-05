using System.Collections.Generic;
using UnityEngine;

public class Spawner_GlobalPooling : MonoBehaviour
{
    [SerializeField] protected string _projectileId;
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

        SpawnProjectile();
        _cooldown = _framesCooldown;
    }

    private void SpawnProjectile()
    {
        PoolObject projectilePO = PoolManager.GetPooledObject(_projectileId);
        Projectile projectile = projectilePO.GetComponent<Projectile>();
        projectile.Init(transform.position, _fieldCenter);
    }

}
