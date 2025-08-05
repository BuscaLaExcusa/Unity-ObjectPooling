using UnityEngine;

public class GameMaster : MonoBehaviour
{
	public static InputActions Input { get; protected set; }
	private static GameMaster _this;

	private void Awake()
	{
		if (_this != null)
		{
			Destroy(this.gameObject);
			return;
		}

		_this = this;

		Input = new InputActions();
		Input.Enable();
	}


}
