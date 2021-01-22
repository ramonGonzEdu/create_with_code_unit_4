using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed = 5.0f;
	private Rigidbody playerRb;


	private void Start()
	{
		playerRb = GetComponent<Rigidbody>();

	}

	private void Update()
	{
		float forwardInput = Input.GetAxis("Vertical");
		playerRb.AddForce(Vector3.forward * speed * forwardInput);
	}
}