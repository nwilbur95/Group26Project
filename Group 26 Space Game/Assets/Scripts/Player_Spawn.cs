using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Spawn : MonoBehaviour {

    public GameObject playerPrefab;
    GameObject playerInstance;
    float respawnTimer;

	// Use this for initialization
	void Start () {
        respawnTimer = 3;
        SpawnPlayer();
		
	}
	
	// Update is called once per frame
	void Update () {

		if(playerInstance == null)
        {
            respawnTimer -= Time.deltaTime;

            if (respawnTimer <= 0)
            {
                SpawnPlayer();
            }
        }

	}


    void SpawnPlayer()
    {
        playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }
}
