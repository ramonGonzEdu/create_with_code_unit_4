using UnityEngine;

public class Enemy : MonoBehaviour
{
	Rigidbody enemyRb;
	GameObject player;
	public float speed;

	private void Start()
	{
		enemyRb = GetComponent<Rigidbody>();
		player = GameObject.Find("Player");
	}

	private void Update()
	{
		Vector3 lookDirection = (player.transform.position - transform.position).normalized;

		enemyRb.AddForce(lookDirection * speed);
	}
}