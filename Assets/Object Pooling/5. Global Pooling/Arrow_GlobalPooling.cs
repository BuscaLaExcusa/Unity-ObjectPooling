using UnityEngine;
using UnityEngine.Events;

public class Arrow_GlobalPooling : Projectile
{
    public override void Init(Vector2 startPoint, Transform aimAt)
    {
		base.Init(startPoint, aimAt);
		transform.up = _direction;
	}
}
