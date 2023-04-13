using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{

    public int startingHealth = 100;
    private int currentHealth;
    private Rigidbody zombieRB;
     private Transform playerRB;
    private GameObject player;
    private float zombieSpeed = 1;

    public int chance = 100;
    private int number;

    // Start is called before the first frame update
    void Start()
    {
        zombieRB = GetComponent<Rigidbody>();
        player = GameObject.Find("MaleFree1");
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //Zombier følger spiller
        Vector3 targetDirection = (player.transform.position - transform.position).normalized;
       
        transform.LookAt(player.transform);
        transform.Translate(Vector3.forward * Time.deltaTime * zombieSpeed );
    }

    void OnTriggerEnter(Collider other)
    {
        currentHealth = currentHealth - startingHealth / 2;
            Debug.Log("RAMT");

            if (currentHealth <= 0)
            {
                Die();
            }
        Destroy(other);

        
        if (other.CompareTag("Bullet"))
        {
            Debug.Log("SKU DA RAMT AF EN DIMS");
        }
    }

    void Die()
    {
        Destroy(gameObject);


        WaveSpawner spawner = FindObjectOfType<WaveSpawner>();
        spawner.spawnedEnemies.Remove(gameObject);

        number = Random.Range(1, chance);
        if (number == 1)
        {
            Debug.Log("POWERUP");
        }

    }
}


