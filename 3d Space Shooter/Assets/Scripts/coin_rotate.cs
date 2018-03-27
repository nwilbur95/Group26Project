using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin_rotate : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0,Time.deltaTime)*10);
    }
}
