using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField] protected Animator _animator;

    protected const string HORIZONTAL_KEY = "Horizontal";
    protected const string VERTICAL_KEY = "Vertical";
    protected const string MOVING_KEY = "Moving";

	public void SetDirection(Vector2 direction)
    {
        _animator.SetFloat(HORIZONTAL_KEY, direction.x);
        _animator.SetFloat(VERTICAL_KEY, direction.y);
    }

    public void SetMoving(bool moving)
    {
        _animator.SetBool(MOVING_KEY, moving);
    }

    
}
