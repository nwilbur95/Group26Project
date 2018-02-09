using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shooting : MonoBehaviour {
    public GameObject bulletPrefab;
    //create a cooldown for shooting
    float cooldownTimer = 0;
    public float fireDelay = .5f;

    //make adjustable where bullets come from ship
    public Vector3 bulletOffset = new Vector3(0, .5f, 0);

    int bulletLayer;


    // Use this for initialization
    void Start()
    {
        bulletLayer = gameObject.layer;
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer <= 0)
        {
            //shoot stuff
            Debug.Log("ENEMY SHOOTING!");
            cooldownTimer = fireDelay;

            Vector3 offset = transform.rotation * bulletOffset;

            GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);

            bulletGo.layer = bulletLayer;
        }
    }
}
