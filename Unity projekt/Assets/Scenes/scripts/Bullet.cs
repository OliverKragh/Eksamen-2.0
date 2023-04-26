using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
private int bulletSpeed = 20;
private Rigidbody BulletRB;

private GameObject player;

private float playerViewY;
private float playerViewX;



  
    // Start is called before the first frame update
    void Start()
    {
        playerViewX = GameObject.Find("PlayerView").GetComponent<Transform>().eulerAngles.x;
        playerViewY = GameObject.Find("MaleFree1").GetComponent<Transform>().eulerAngles.y;
        
        transform.eulerAngles = new Vector3(playerViewX, playerViewY, transform.eulerAngles.z);


        BulletRB = GetComponent<Rigidbody>();
        BulletRB.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);

      

      
    }

    



    // Update is called once per frame
    void Update()
    {
     //Slet bullet hvis langt væk
      if (transform.position.x > 200 || transform.position.y > 200 || transform.position.z > 200 || transform.position.x < -200 || transform.position.y < -200 || transform.position.z < -200)
        {
            Destroy(gameObject);
        }

    }
    void OnCollisionEnter(Collision other)
    {
    if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

}


