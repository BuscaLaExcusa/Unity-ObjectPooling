using UnityEngine;
using UnityEngine.Events;

public class Shuriken_AdvancedPooling : MonoBehaviour
{
	[SerializeField] private float _moveSpeed = 10.0f;
	[SerializeField] public UnityEvent<GameObject> OnShurikenDisabled = new UnityEvent<GameObject>();
	protected Vector2 _direction;

    public void Init(Vector2 startPoint, Transform aimAt)
    {
		transform.position = startPoint;
		Vector2 direction = (Vector2)aimAt.position - startPoint;
		direction.x += Random.Range(-0.1f, 0.1f);
		direction.y += Random.Range(-0.1f, 0.1f);
		_direction = direction;
    }

    private void Update()
	{
		transform.position += (Vector3) _direction * _moveSpeed * Time.deltaTime;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		this.gameObject.SetActive(false);
		OnShurikenDisabled?.Invoke(this.gameObject);
	}
}
