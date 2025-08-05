using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] protected float _speed = 5f;
    protected Vector3 _direction = new Vector3(0, 0, 1);

    void Update()
    {
        transform.Rotate(_direction * _speed * Time.deltaTime);
    }
}
