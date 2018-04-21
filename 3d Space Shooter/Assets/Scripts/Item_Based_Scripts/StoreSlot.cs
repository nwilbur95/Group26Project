using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreSlot : MonoBehaviour {

    public Image icon;
    Inventory inventory;
    public Item item; 
    public GameObject player;
    Player_Controller cont;

    public void Start()
    {
        cont = player.GetComponent<Player_Controller>();
        inventory = Inventory.instance;
        icon.sprite = item.icon;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }

    public void UseItem()
    {
        if (cont.getCoins() >= item.price)
        {
            cont.setCoins(-item.price);
            inventory.Add(item);
            this.ClearSlot();
        }
        else
        {
            Debug.Log("Failed to purchase.");
        }
    }
        

}
