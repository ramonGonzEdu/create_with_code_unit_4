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
		enemyRb.AddForce((player.transform.position - transform.position).normalized * speed);
	}
}