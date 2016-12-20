using UnityEngine;

public class PhysicsCharacterController : MonoBehaviour
{
	public float Speed = 4f;

	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	void FixedUpdate()
	{
		float x = Input.GetAxisRaw("Horizontal");
		float z = Input.GetAxisRaw("Vertical");
		var move = new Vector3(x, 0, z);

		move = transform.TransformDirection(move) * Speed;
		GetComponent<Rigidbody>().velocity = move;
	}
}
