using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Faces_Player : MonoBehaviour {
    public float rotSpeed = 90f;

    Transform player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (player == null)
        {
            //find the players ship
            GameObject go =GameObject.FindWithTag("Player");

            if (go != null)
            {
                player = go.transform;
            }
        }

        //at this point we've either found the player or they dont exist
        if(player == null)
        {
            return; //try again next frame
        }

        //Here --- we know we have a player so let's turn to it

        Vector3 dir = player.position - transform.position;
        dir.Normalize();

        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        Quaternion desiredRotation = Quaternion.Euler(0, 0, zAngle);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, rotSpeed * Time.deltaTime);

		
	}
}
