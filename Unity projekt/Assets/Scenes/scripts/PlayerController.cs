using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRB;
   
    //KEYBOARD MOVEMENT
    public float horizontalInput;
    public float verticalInput;
    private float speed = 3;
    //SPRINT 
    private float sprintMultiplier = 1.4F;

    //HOP
    private float jumpForce = 400;
    private bool jumpCooldown;

    //MUS SENS
    public float mouseHorizontalSpeed = 2.0F;

    public TextMeshProUGUI hPText;
    
    public double healthPoints = 100;
    public double currentHealth;
    public bool touchingTerrain ;

    private bool gameActive;
    private bool isGameActive;
   private double difficulty;

   public bool alive;



    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        playerRB = GetComponent<Rigidbody>();

        //hPText = GameObject.Find("HPUI").GetComponent<TextMeshProUGUI>();
        
        //
        jumpCooldown = false;
       
    }

    public void GameStart()
    {
        difficulty = GameObject.Find("UItomt").GetComponent<UI>().difficulty;
        Debug.Log("player start");
        currentHealth = healthPoints / difficulty;

    }

    // Update is called once per frame
    void Update()
    {

     if (transform.position.y < -6)
    {
        transform.position = new Vector3(35.811f, 12.6f, 38.9f);
    }       
        
        isGameActive = GameObject.Find("UItomt").GetComponent<UI>().isGameActive;
        
       if (isGameActive == true) 
       {

        Cursor.lockState = CursorLockMode.Locked;
        //KEYBOARD MOVEMENT
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
      
        //SPRINT FRONT - BACK
        verticalInput = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.LeftShift))
        {
           transform.Translate(Vector3.forward * Time.deltaTime * (speed * sprintMultiplier) * verticalInput  ); 
           
        }   
        else  
        {
           transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
           
        }
       
        
    //HOP
        if (Input.GetKeyDown(KeyCode.Space) && jumpCooldown == false)
        {
             playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
             StartCoroutine(JumpWait());
             jumpCooldown = true;
        }

    
        //CAMERA

        float h = mouseHorizontalSpeed * Input.GetAxis("Mouse X");
        transform.Rotate(0, h, 0);

        //HP
        hPText.text = "HP: " + currentHealth;
        if (currentHealth <= 0 && alive == true)
        {
            PlayerDie();
        }
       }

    }

   IEnumerator JumpWait()
    {
        yield return new WaitForSeconds(1);
        jumpCooldown = false;
    }

    void OnCollisionEnter(Collision other)
    {
    if (other.gameObject.CompareTag("Enemy"))
        {
        currentHealth = currentHealth - 15 * difficulty;
        }
        
        while (currentHealth <= (healthPoints / difficulty) - 5)
        {
            StartCoroutine(RegenHealth())
        }
        
    }
    
    IEnumerator RegenHealth()
    {
        yield return new WaitForSeconds(5);
        currentHealth = currentHealth + 5;
    }
    

    void PlayerDie()
    {
        alive = false;
        GameObject.Find("UItomt").GetComponent<UI>().isGameActive = false;
      

        
    }
    
}
 



