using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float maxSpeed = 3f;
    public float rotationSpeed = 180f;

    //below is for camera things commented out
    //float ship_boundary_Radius = .5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //rotate the ship

        //grab the rotation quarternion
        Quaternion rot = transform.rotation;

        //grab the Z Euluer Angle
        float z = rot.eulerAngles.z;

        //change the angle based on input
        z -= Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        //recreate Quaternion
        rot = Quaternion.Euler(0, 0, z);

        //Tell transform what to do
        transform.rotation = rot;
        

        
        //movement in the y direction
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") *maxSpeed * Time.deltaTime,0);
        pos -= rot * velocity; 
        

        /* debate on if we want to do this
		//Restrict player to camera's boundries
        //vertical boundries
        if(pos.y + ship_boundary_Radius > Camera.main.orthographicSize)
        {
            pos.y = Camera.main.orthographicSize - ship_boundary_Radius;
        }
        if (pos.y - ship_boundary_Radius < -Camera.main.orthographicSize)
        {
            pos.y = -Camera.main.orthographicSize + ship_boundary_Radius;
        }
        

        //now width
        //need to use screen for width
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;

        if (pos.x + ship_boundary_Radius > widthOrtho)
        {
            pos.x = widthOrtho - ship_boundary_Radius;
        }
        if (pos.x - ship_boundary_Radius < -widthOrtho)
        {
            pos.x = -widthOrtho + ship_boundary_Radius;
        }

        //finally update position
        */

        transform.position = pos;
    }
}
