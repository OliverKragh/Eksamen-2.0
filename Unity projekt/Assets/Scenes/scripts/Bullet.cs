using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
private int bulletSpeed = 10;
private Rigidbody BulletRB;


private float yrot;
private float xrot;



public float rotx, roty, rotz;
  
    // Start is called before the first frame update
    void Start()
    {
      
    }
    // Update is called once per frame
    void Update()
    {
      
     // if (GameObject.Find("MaleFree1").GetComponent<Transform>().Quaternion.eulerAngles)
     // {
    //    transform.Rotate(rotx, roty, rotz, Space.Self);
     // }
      

     //Slet bullet hvis langt væk
      if (transform.position.x > 200 || transform.position.y > 200 || transform.position.z > 200)
        {
            Destroy(gameObject);
        }

  
    
    }
}


