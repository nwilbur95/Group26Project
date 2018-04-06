﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


[System.Serializable]

public class Player_Controller : MonoBehaviour {
    public float maxSpeed = 3f;
    public float rotationSpeed = 180f;

    //publics for the lasers
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;

    //publics for scrap/coim collecting
    public int scrap = 0;
    public Text playerScrap;

    public int coin = 0;
    public Text playerCoin;
	public Slider healthBar;
	public static CharacterStats myStats;


	void Start()
	{
		myStats = GetComponent<CharacterStats>();
	}

    // Use this for initialization
    void Update()
    {
		//Prevents shot from fireing while game is paused
		if (!Pause_Menu.GameIsPaused) 
		{
			if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
			{
				nextFire = Time.time + fireRate;
				//creates the shot at the shotspawn
				Instantiate(shot, shotSpawn.position, shotSpawn.rotation);          
			}
		}
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //grab the rotation quarternion
        Quaternion rot = transform.rotation;

        //grab the y Euluer Angle
        float y = rot.eulerAngles.y;

        //change the angle based on input
        y += Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        //recreate Quaternion
        rot = Quaternion.Euler(0, y, 0);

        //Tell transform what to do
        transform.rotation = rot;



        //movement in the z direction
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, 0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime);
        pos -= rot * velocity;

        transform.position = pos;
        
        healthBar.value = myStats.currentHealth;
    }


    //collecting scrap/coin
    void OnTriggerEnter(Collider other)
    {
        //take no damage when colliding with scrap
        if (other.tag == "scrap")
        {
            other.gameObject.SetActive(false);
            scrap++;
            playerScrap.text = "Scrap: " + scrap.ToString();     //update scrap UI (make sure UI attached to player ship scrap variable)
        }

        //take no damage when colliding with scrap
        if (other.tag == "coin")
        {
            other.gameObject.SetActive(false);
            coin++;
            playerCoin.text = "Coin: " + coin.ToString();     //update scrap UI (make sure UI attached to player ship scrap variable)
        }

        if (other.tag == "Station")
        {
            GameObject storeParent = GameObject.Find("StoreUI");
            GameObject storeUI = storeParent.transform.Find("Panel").gameObject;
            storeUI.SetActive(true);
        }
    }


}
