using UnityEngine;
using UnityEngine.Events;

public class Arrow_GenericPooling : GenericPoolObject
{
	[SerializeField] private float _moveSpeed = 10.0f;
	protected Vector2 _direction;

    public void Init(Vector2 startPoint, Transform aimAt)
    {
		Vector2 direction = (Vector2)aimAt.position - startPoint;
		direction.x += Random.Range(-0.1f, 0.1f);
		direction.y += Random.Range(-0.1f, 0.1f);

		_direction = direction;
		transform.position = startPoint;

		transform.up = _direction;
	}

    private void Update()
	{
		transform.position += (Vector3) _direction * _moveSpeed * Time.deltaTime;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		this.gameObject.SetActive(false);
	}
}
