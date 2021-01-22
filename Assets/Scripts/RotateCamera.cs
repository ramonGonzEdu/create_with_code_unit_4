using UnityEngine;

public class RotateCamera : MonoBehaviour
{
	private void Start()
	{

	}

	public float rotationSpeed;
	private void Update()
	{
		float horizontalInput = Input.GetAxis("Horizontal");
		transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
	}
}