using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public static int activeEnemies;
	public static int enemiesKilled;

	public GameObject enemyShip;
	public GameObject playerShip;

	private Transform[] spawnPoints;
	private int randomSpawn;
	private int maxEnemies;

	// Use this for initialization
	void Start () 
	{
		activeEnemies = 0;
		enemiesKilled = 0;
		maxEnemies = 3;

		spawnPoints = GetComponentsInChildren<Transform> ();

		spawnShip ();
	}
		
	void spawnShip()
	{
		randomSpawn = Random.Range (0, (spawnPoints.Length - 1));
		Transform spawnPoint = spawnPoints [randomSpawn];

		GameObject spawnedShip = (GameObject) Instantiate (enemyShip, spawnPoint);
		spawnedShip.GetComponent<EnemyController> ().Player = playerShip.transform;
		activeEnemies++;
	}
		

	// Update is called once per frame
	void Update () 
	{
		Debug.Log (enemiesKilled);

		if ((enemiesKilled % 5 == 0) && (enemiesKilled != 0))
			maxEnemies++;

		if (activeEnemies < maxEnemies) 
			spawnShip ();

	}
}
