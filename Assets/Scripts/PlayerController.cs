using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
	public float speed = 5.0f;
	private Rigidbody playerRb;
	private GameObject focalPoint;

	private void Start()
	{
		playerRb = GetComponent<Rigidbody>();
		focalPoint = GameObject.Find("Focal Point");
	}

	private void Update()
	{
		float forwardInput = Input.GetAxis("Vertical");
		playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
	}

	public bool hasPowerup;
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Powerup"))
		{
			hasPowerup = true;
			Destroy(other.gameObject);
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Enemy") && hasPowerup)
		{
			Debug.Log("Collision with: " + other.gameObject.name + " with powerup: " + hasPowerup);
		}
	}
}