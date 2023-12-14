using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 5f;
	private CharacterController characterController;

	void Start()
	{
		characterController = GetComponent<CharacterController>();
	}

	void Update()
	{
		MovePlayer();
	}

	void MovePlayer()
	{
		float verticalInput = Input.GetAxis("Vertical");
		float horizontalInput = Input.GetAxis("Horizontal");

		// Calculate the movement direction
		Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

		// Normalize the movement vector to ensure constant speed in all directions
		movement.Normalize();

		// Move the player using CharacterController
		characterController.SimpleMove(movement * speed);
		

		// Optionally, you can also rotate the player based on the movement direction
		if (movement != Vector3.zero)
		{
			Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, Time.deltaTime * 500f);
		}
	}
}
