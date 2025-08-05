using UnityEngine;

public class ShurikenSpawner_NoPooling : MonoBehaviour
{
    [SerializeField] protected GameObject _shurikenPrefab;
    [SerializeField] protected Transform _fieldCenter;
    [SerializeField] protected Transform _shurikensParent;
    [SerializeField] protected int _framesCooldown = 5;

    protected int _cooldown = 0;

    private void Awake()
    {
        _cooldown = Random.Range(0, _framesCooldown); // Aleatoreizamos cu�ndo empieza a disparar para que parezca m�s org�nico
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
        GameObject shurikenGO = Instantiate(_shurikenPrefab, _shurikensParent);
        Shuriken_NoPooling shuriken = shurikenGO.GetComponent<Shuriken_NoPooling>();
        shuriken.Init(transform.position, _fieldCenter);
    }
}
