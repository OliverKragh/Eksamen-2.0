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
    public bool jumpCool;


    //MUS SENS
    public float mouseHorizontalSpeed = 2.0F;

    public TextMeshProUGUI hPText;
    public int healthPoints = 100;
    public bool touchingTerrain ;

    // Start is called before the first frame update
    void Start()
    {
        //SKAL AKTIVERES NÅR SPILLET BEGYNDER IKKE NÅR VI ER I UI
        Cursor.lockState = CursorLockMode.Locked;
        playerRB = GetComponent<Rigidbody>();

        hPText = GameObject.Find("HPUI").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        if (Input.GetKeyDown(KeyCode.Space) && jumpCool==false)
        {
             playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            StartCoroutine(Jumpcooldown());
        }

        


        //CAMERA
        float h = mouseHorizontalSpeed * Input.GetAxis("Mouse X");
        transform.Rotate(0, h, 0);

        //HP
        hPText.text = "HP: " + healthPoints;

    }



    // Jump cooldown
    IEnumerator Jumpcooldown()
    {
        jumpCool = true;
        yield return new WaitForSeconds(1);
        jumpCool = false;
    }

} 

