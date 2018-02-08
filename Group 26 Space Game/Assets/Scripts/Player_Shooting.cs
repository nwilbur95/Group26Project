using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shooting : MonoBehaviour {
    public GameObject bulletPrefab;
    //create a cooldown for shooting
    float cooldownTimer = 0;
    public float fireDelay = 5f;

    //make adjustable where bullets come from ship
    public Vector3 bulletOffset = new Vector3(0, .5f, 0);


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        cooldownTimer -= Time.deltaTime;

	    if( Input.GetButtonDown("Fire1") && cooldownTimer <= 0)
        {
            //shoot stuff
            Debug.Log("SHOOTING!");
            cooldownTimer = fireDelay;

            Vector3 offset = transform.rotation * bulletOffset;

            Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
        }
	}
}
