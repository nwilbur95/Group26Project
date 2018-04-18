using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Destroy_By_COntact : MonoBehaviour {


    public GameObject explosion;
    public GameObject playerExplosion;
    public int health = 100;
    public Text playerHealth;

    void OnTriggerEnter(Collider other)
    {
        //take no damage when colliding with pickup/station
        if (other.tag == "scrap" || other.tag == "Station" || other.tag == "coin")
        {
            return;
        }

        // If it was a boundry collision, just shrug and move on. 
        if (other.tag == "Boundry")
        {
            return;
        }
        // Lasers have no explosion, and thus should not instantiate one. 
        if(explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            health--;
            if (health == 0)    //object dead
            {
                Destroy(gameObject);

                if(gameObject.tag == "Enemy")       //enemy drop 
                {
                    int choice = Random.Range(0,101);       //probability generation

                    if(choice <= 30)    //just gold
                        Instantiate(Resources.Load("goldCoins"), transform.position, Quaternion.Euler(90,0,0));
                    else if(choice > 30 && choice <= 70)    //just scrap
                        Instantiate(Resources.Load("Mus_2"), transform.position, transform.rotation);
                    else if (choice > 70 && choice <= 90)   //1 gold + 2 scrap
                    {
                        Instantiate(Resources.Load("goldCoins"), transform.position, Quaternion.Euler(90, 0, 0));
                        Instantiate(Resources.Load("Mus_2"), transform.position + Vector3.left *3, transform.rotation);
                        Instantiate(Resources.Load("Mus_1"), transform.position + Vector3.right *3, transform.rotation);
                    }
                    else    //2 gold + 4 scrap
                    {
                        Instantiate(Resources.Load("goldCoins"), transform.position, Quaternion.Euler(90, 0, 0));
                        Instantiate(Resources.Load("goldCoins"), transform.position, Quaternion.Euler(90, 0, 0));
                        Instantiate(Resources.Load("Mus_1"), transform.position + Vector3.left *3, transform.rotation);
                        Instantiate(Resources.Load("Mus_2"), transform.position + Vector3.right * 3, transform.rotation);
                        Instantiate(Resources.Load("Mus_3"), transform.position + Vector3.forward *3, transform.rotation);
                        Instantiate(Resources.Load("Mus_4"), transform.position + Vector3.back * 3, transform.rotation);
                    }
                }
            }
            playerHealth.text = "Health: " + health.ToString();     //update health UI (make sure UI attached to player ship health variable)
        }
        // If contact was with player, add the unique player explosion effect, destroy object.
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            health--;
            if (health == 0)    //object dead
            {
                Destroy(gameObject);
            }
        }

        //Player collide with the enemy ship
        if (other.tag == "Enemy")
        {
            Instantiate(playerExplosion, transform.position, transform.rotation);
            health--;
            if (health == 0)    //object dead
            {
                Destroy(gameObject);
            }
        }

        if (other.tag == "asteroid")     //if contact hit with an asteroid, we want the asteroid to explode
        {
            Destroy(other.gameObject);
        }

    }
}
