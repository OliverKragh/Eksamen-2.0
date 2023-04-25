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

    //active
    private bool isGameActive;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGameActive = GameObject.Find("UItomt").GetComponent<UI>().isGameActive;
        if (isGameActive == true)
        {
        isGameActive = GameObject.Find("UItomt").GetComponent<UI>().isGameActive;
        //MUS
        float v = mouseVerticalSpeed * Input.GetAxis("Mouse Y");
        transform.Rotate(-v, 0, 0); 
     

        //Sætter kam position samme som spiller + offset
        transform.position = player.transform.position + offset;


        //MAX KIG ---------------------------------------------------------------
       // currentRotation = transform.localRotation.eulerAngles.x;
       // currentRotation = Mathf.Clamp(currentRotation, minRotation, maxRotation);
       // transform.localRotation = Quaternion.Euler(currentRotation, 0, 0);

       float rotationAmount = -Input.GetAxis("Mouse Y") * mouseVerticalSpeed;
float newRotation = transform.localEulerAngles.x + rotationAmount;
if (newRotation > 180) newRotation -= 360;
newRotation = Mathf.Clamp(newRotation, minRotation, maxRotation);
transform.localEulerAngles = new Vector3(newRotation, 0f, 0f);
        //fucking virker ik
        }
    }

    
}