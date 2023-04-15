using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{

    public double startingHealth = 100;
    public double currentHealth;
    private Rigidbody zombieRB;
     private Transform playerRB;
    private GameObject player;  
    private float zombieSpeed = 1;

    public int chance = 100;
    private int number;

    private bool isGameActive;
    private double difficulty;
    private int killedZombiesValue;
    

    // Start is called before the first frame update
    void Start()
    {
        
        zombieRB = GetComponent<Rigidbody>();
        player = GameObject.Find("MaleFree1");
        difficulty = GameObject.Find("UItomt").GetComponent<UI>().difficulty;
        currentHealth = startingHealth * difficulty;
    }
    
    // Update is called once per frame
    void Update()
    {
        
        isGameActive = GameObject.Find("UItomt").GetComponent<UI>().isGameActive;
        if (isGameActive == true)
        {
        //Zombier følger spiller
        Vector3 targetDirection = (player.transform.position - transform.position).normalized;
       
        transform.LookAt(player.transform);
        transform.Translate(Vector3.forward * Time.deltaTime * zombieSpeed );
        }
    }

    void OnTriggerEnter(Collider other)
    {
        currentHealth = currentHealth - 50;
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
        GameObject.Find("UItomt").GetComponent<UI>().killedZombies += 1;
        WaveSpawner spawner = FindObjectOfType<WaveSpawner>();
        spawner.spawnedEnemies.Remove(gameObject);

        number = Random.Range(1, chance);
        if (number == 1)
        {
            Debug.Log("POWERUP");
        }

    }
}


