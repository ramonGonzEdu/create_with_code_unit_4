using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public GameObject enemyPrefab;
	public GameObject powerupPrefab;
	public int enemyCount;
	private float spawnRange = 9;
	public int waveNumber = 1;
	private void Start()
	{
		SpawnEnemyWave(waveNumber);
		Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
	}

	private void SpawnEnemyWave(int enemiesToSpawn)
	{
		for (int i = 0; i < enemiesToSpawn; i++)
		{
			Vector3 spawnPos = GenerateSpawnPosition();
			var copy = Instantiate(enemyPrefab, spawnPos, enemyPrefab.transform.rotation);
			var EnemyScript = copy.GetComponent<Enemy>();
			EnemyScript.speed = Random.Range(5, 15);
		}
	}

	private Vector3 GenerateSpawnPosition()
	{
		return new Vector3(Random.Range(-spawnRange, spawnRange), 0, Random.Range(-spawnRange, spawnRange));
	}

	private void Update()
	{
		enemyCount = FindObjectsOfType<Enemy>().Length;
		if (enemyCount == 0)
		{
			SpawnEnemyWave(++waveNumber);
			Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);

		}
	}
}
