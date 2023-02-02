using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //player
    public GameObject player;
    // offset position
    private Vector3 offset = new Vector3(0,0.9f,0);

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

        //kam position samme som spiller + offset
        transform.position = player.transform.position + offset;
    }
}
