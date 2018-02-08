using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Fixate_Player : MonoBehaviour {

    public Transform myTarget;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        //follow spaceship with camera
        if(myTarget != null)
        {
            Vector3 targPos = myTarget.position;
            targPos.z = transform.position.z;
            //possible lerp
            transform.position = targPos;
        }
	}
}
