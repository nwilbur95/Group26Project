using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_Control : MonoBehaviour {

   // set Health
   public int health = 1;

   //invulnerability 
   float invulnTime = 0;
   public float invulnPeriod = 0;

    //layer integer
    int correctLayer;
    void Start()
    {
        correctLayer = gameObject.layer;  
    }

    void OnTriggerEnter2D()
    {
        Debug.Log("Trigger");

        //check for invlun
        //if (invuln <= 0)
        
        health--;
        invulnTime = invulnPeriod;

        //set invulnerability time
        gameObject.layer = 10;       
    }

    void Update()
    {
        invulnTime -= Time.deltaTime;
        if (invulnTime <= 0)
        {
            gameObject.layer = correctLayer;
        }
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
