using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseUI : MonoBehaviour {

	public void closeClick()
    {
        GameObject storeParent = GameObject.Find("StoreUI");
        GameObject storeUI = storeParent.transform.Find("Panel").gameObject;
        storeUI.SetActive(false);
    }
}
