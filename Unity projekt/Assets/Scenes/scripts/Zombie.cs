using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{

    public int startingHealth = 100;
    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {currentHealth -= 20;
            Debug.Log("RAMT");

            if (currentHealth <= 0)
            {
                Destroy(gameObject);
                //Die();
            }
        if (other.CompareTag("Bullet"))
        {
    
            
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}


