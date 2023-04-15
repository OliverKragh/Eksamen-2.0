using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public GameObject player;
    public int magazineSize;
    public int ammoLeft;
    public bool reloading;
    public float firerate;
    
    public bool shootCooldown;
    public GameObject bullet;
    public TextMeshProUGUI ammoLeftText;
    public GameObject AK47;
    public GameObject M1911;
    Vector3 newPlayerPos;
    private bool isGameActive;
    

    // Start is called before the first frame update
    void Start()
    {
        
        shootCooldown = false;
        ammoLeft = magazineSize;
        //ammoLeftText = GameObject.Find("AmmoLeft").GetComponent<TextMeshProUGUI>();
       
    }

    // Update is called once per frame
    void Update()
    {
        isGameActive = GameObject.Find("UItomt").GetComponent<UI>().isGameActive;
        if (isGameActive == true)
        {
       newPlayerPos = player.transform.position;
       newPlayerPos.y = newPlayerPos.y + 0.8999996f;
       
        
       
        
        //reload
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

         //shoot
        if (Input.GetMouseButton(0) )
        {
            Shoot();
        } 
        
        

        // TEXT ----------------------------------------------
        if (ammoLeft > 0)
        {
            ammoLeftText.text = "Ammo Left: " + ammoLeft;
        }
        if (ammoLeft == 0)
        {
            ammoLeftText.text = "Out of Ammo";
        }

        if  (reloading == true)
        {
            ammoLeftText.text ="Reloading";
        }
        }

    }

     void Shoot()
    {
        if (ammoLeft == 0 )
        {
            Debug.Log("OUT OF AMMO");
        }
      
       
        if (AK47.activeSelf && ammoLeft > 0 && reloading == false && shootCooldown == false )
        {
            shootCooldown = true;
            StartCoroutine(ShotCooldown());
            ammoLeft = ammoLeft - 1;
            Instantiate(bullet, newPlayerPos, bullet.transform.rotation);
            Debug.Log("SHOOTING"); 
        }

       
        if (M1911.activeSelf && ammoLeft > 0 && reloading == false && Input.GetMouseButtonDown(0))
        {
            shootCooldown = false;
            ammoLeft = ammoLeft - 1;
            Instantiate(bullet, newPlayerPos, bullet.transform.rotation);
            Debug.Log("SHOOTING"); 
        }
      
        
    
      


        
        
    }
    
    void Reload()
    {
         //reload
        //RELOAD UDEN TOMT MAG
        if (Input.GetKeyDown(KeyCode.R) && ammoLeft < magazineSize && ammoLeft > 0 && reloading == false) 
        {
            reloading = true;
            StartCoroutine(ReloadWait());
            Debug.Log("RELOADING");
        }

        //RELOAD TOMT MAG
        if (ammoLeft == 0  && reloading == false) 
        {
            reloading = true;
            StartCoroutine(ReloadWaitEmpty());
            Debug.Log("RELOADING");
        }
    }



    IEnumerator ReloadWait()
    {
        yield return new WaitForSeconds(1);
        ammoLeft = magazineSize;
        reloading = false;
        Debug.Log("RELOAD COMPLETE");
        
    }
    IEnumerator ReloadWaitEmpty()
    {
        yield return new WaitForSeconds(2);
        ammoLeft = magazineSize;
        reloading = false;
        Debug.Log("RELOAD COMPLETE");
    }
    IEnumerator ShotCooldown()
    {
        yield return new WaitForSeconds((60/firerate));
        shootCooldown = false;
        Debug.Log("fucking skyd");
        
    }

    
}

