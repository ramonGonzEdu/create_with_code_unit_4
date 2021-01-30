using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public GameObject enemyPrefab;
	private float spawnRange = 9;
	private void Start()
	{
		Vector3 spawnPos = GenerateSpawnPosition();
		var copy = Instantiate(enemyPrefab, spawnPos, enemyPrefab.transform.rotation);
		var EnemyScript = copy.GetComponent<Enemy>();
		EnemyScript.speed = Random.Range(5, 15);
	}

	private Vector3 GenerateSpawnPosition()
	{
		return new Vector3(Random.Range(-spawnRange, spawnRange), 0, Random.Range(-spawnRange, spawnRange));
	}

	private void Update()
	{

	}
}
