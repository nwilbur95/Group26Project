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

   SpriteRenderer spriteRend;


    void Start()
    {
        correctLayer = gameObject.layer;

        //Note this only gets the renderer on the parent objects
        //In other words, It doesnt work for children
        spriteRend = GetComponent<SpriteRenderer>();

        if (spriteRend == null)
        {
            spriteRend = transform.GetComponentInChildren<SpriteRenderer>();

            if (spriteRend == null)
            {
                Debug.LogError("Object " + gameObject.name + "has no sprite renderer");
            }

        }

    }

    void OnTriggerEnter2D()
    {
        health--;
        if (invulnPeriod > 0)
        {
            invulnTime = invulnPeriod;
            gameObject.layer = 10;
        }
        
       
    }

    void Update()
    {
        if (invulnTime > 0)
        {
            invulnTime -= Time.deltaTime;

            if (invulnTime <= 0)
            {
                gameObject.layer = correctLayer;

                if(spriteRend != null)
                {
                    spriteRend.enabled = true;
                }
            }
            else
            {
                if(spriteRend != null)
                {
                    spriteRend.enabled = !spriteRend.enabled;
                }
            }
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
