using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
private int bulletSpeed = 5;
private Rigidbody bulletRB;

    // Start is called before the first frame update
    void Start()
    {
      BulletRB = GetComponent<Rigidbody>();  
    }

    // Update is called once per frame
    void Update()
    {
    //ved ikke om virker, har ikke testet det
        BulletRB.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
    
    }
}
