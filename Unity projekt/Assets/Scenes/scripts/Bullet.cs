using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
private int bulletSpeed = 10;
private Rigidbody BulletRB;

private GameObject player;

private float playerViewY;
private float playerViewX;
private float xrot;
private float yrot;


  
    // Start is called before the first frame update
    void Start()
    {
        playerViewX = GameObject.Find("PlayerView").GetComponent<Transform>().eulerAngles.x;
        playerViewY = GameObject.Find("MaleFree1").GetComponent<Transform>().eulerAngles.y;

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, playerViewY, playerViewX);
    


      

      
    }

    



    // Update is called once per frame
    void Update()
    {
        
      
     // if (GameObject.Find("MaleFree1").GetComponent<Transform>().Quaternion.eulerAngles)
     // {
    //    transform.Rotate(rotx, roty, rotz, Space.Self);
     // }
      
//YROT-----------SIDE / SIDE---------MaleFree1---------------------------------------------------------------------
    

     //Slet bullet hvis langt væk
      if (transform.position.x > 200 || transform.position.y > 200 || transform.position.z > 200)
        {
            Destroy(gameObject);
        }

  
    
    }
}


