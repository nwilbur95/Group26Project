using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseUI : MonoBehaviour {
	public GameObject storeParent;

	public void Update()
    {
        GameObject storeUI = storeParent.transform.Find("Panel").gameObject;
        if(Input.GetKeyDown(KeyCode.T))
        {
            storeUI.SetActive(false);
        }
    }
}
