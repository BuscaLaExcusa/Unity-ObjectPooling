using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D _rigidbody;
    [SerializeField] protected AnimatorController _animatorController;

	protected InputAction _moveAction;

	void Start()
    {
		_moveAction = GameMaster.Input.Player.Move;
	}

    private void Update()
    {
		Vector2 direction = _moveAction.ReadValue<Vector2>();
		float magnitude = direction.sqrMagnitude;

		_animatorController.SetMoving(magnitude > 0);
		if (magnitude > 0)
        {
			_animatorController.SetDirection(direction);
        }
		_rigidbody.linearVelocity = direction;
	}
}
