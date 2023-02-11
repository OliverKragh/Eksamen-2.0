using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
private int bulletSpeed = 10;
private Rigidbody BulletRB;



private float yrot;
private float xrot;

  
    // Start is called before the first frame update
    void Start()
    {
      
    }
    // Update is called once per frame
    void Update()
    {

      //YROT-----------SIDE / SIDE---------MaleFree1---------------------------------------------------------------------
    if (GameObject.Find("MaleFree1").GetComponent<Transform>().eulerAngles.y > 180)
    {
      yrot = GameObject.Find("MaleFree1").GetComponent<Transform>().eulerAngles.y -360;
    }
    else 
    {
      yrot = GameObject.Find("MaleFree1").GetComponent<Transform>().eulerAngles.y;
    }



      //XROT---------OP / NED------------PlayerView--------------------------------------------------------------------
    if (GameObject.Find("PlayerView").GetComponent<Transform>().eulerAngles.x > 180)
    {
      xrot = GameObject.Find("PlayerView").GetComponent<Transform>().eulerAngles.x -360;
    }
    else 
    {
      xrot = GameObject.Find("PlayerView").GetComponent<Transform>().eulerAngles.x;
    }
    
    
     transform.Rotate(xrot, yrot, 0);
      





        BulletRB.AddForce(-transform.up * bulletSpeed, ForceMode.Impulse);


     //Slet bullet hvis langt væk
      if (transform.position.x > 200 || transform.position.y > 200 || transform.position.z > 200)
        {
            Destroy(gameObject);
        }
  
    
    }
}


