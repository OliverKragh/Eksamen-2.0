using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //MOUSE SENS
    
    public float mouseVerticalSpeed = 2.0F;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //MUS
        
        float v = mouseVerticalSpeed * Input.GetAxis("Mouse Y");
        transform.Rotate(-v, 0, 0);
    }
}
