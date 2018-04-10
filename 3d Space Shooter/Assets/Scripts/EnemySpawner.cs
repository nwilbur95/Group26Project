using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public static int activeEnemies;
	public GameObject enemyShip;

	private Transform[] spawnPoints;
	private int randomSpawn;

	// Use this for initialization
	void Start () 
	{
		spawnPoints = GetComponentsInChildren<Transform> ();
		randomSpawn = Random.Range (0, spawnPoints.Length);
		Transform spawnPoint = spawnPoints [randomSpawn];
		Instantiate (enemyShip, spawnPoint);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
