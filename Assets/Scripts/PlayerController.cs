using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
	public float speed = 5.0f;
	private Rigidbody playerRb;
	private GameObject focalPoint;
	public GameObject powerupIndicator;

	private void Start()
	{
		playerRb = GetComponent<Rigidbody>();
		focalPoint = GameObject.Find("Focal Point");
	}

	private void Update()
	{
		float forwardInput = Input.GetAxis("Vertical");
		playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
		powerupIndicator.transform.position = transform.position;
	}

	public bool hasPowerup;
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Powerup"))
		{
			hasPowerup = true;
			Destroy(other.gameObject);
			StartCoroutine(PowerupCountdownRoutine());
			powerupIndicator.gameObject.SetActive(true);
		}
	}

	IEnumerator PowerupCountdownRoutine()
	{
		yield return new WaitForSeconds(7);
		hasPowerup = false;
		powerupIndicator.gameObject.SetActive(false);
	}

	private float powerupStrength = 15.0f;

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Enemy") && hasPowerup)
		{
			Rigidbody erb = other.gameObject.GetComponent<Rigidbody>();
			Vector3 awayFromPlayer = (other.gameObject.transform.position - transform.position);
			Debug.Log("Collision with: " + other.gameObject.name + " with powerup: " + hasPowerup);
			erb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
		}
	}
}