using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //player
    public GameObject player;
    // offset position
    private Vector3 offset = new Vector3(0,0.9f,0);

    
    public float maxRotation = 53f; 
    public float minRotation = -47f;
    private float currentRotation;

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
     

        //Sætter kam position samme som spiller + offset
        transform.position = player.transform.position + offset;


        //MAX KIG ---------------------------------------------------------------
        currentRotation = transform.localRotation.x;
        //fucking virker ik
    }

    
}