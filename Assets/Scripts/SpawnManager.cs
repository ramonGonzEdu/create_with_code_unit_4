using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public GameObject enemyPrefab;
	private void Start()
	{
		var copy = Instantiate(enemyPrefab, new Vector3(0, 0, 6), enemyPrefab.transform.rotation);
		var EnemyScript = copy.GetComponent<Enemy>();
		EnemyScript.speed = Random.Range(5, 15);
	}

	private void Update()
	{

	}
}
