using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public int magazineSize;
    public int ammoLeft;
    public bool reloading;
    public GameObject bullet;
    public TextMeshProUGUI ammoLeftText;
    // Start is called before the first frame update
    void Start()
    {
        ammoLeft = magazineSize;
        ammoLeftText = GameObject.Find("AmmoLeft").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
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
        if (Input.GetKeyDown(KeyCode.R) && ammoLeft == 0  && reloading == false) 
        {
            reloading = true;
            StartCoroutine(ReloadWaitEmpty());
            Debug.Log("RELOADING");
        }

        

         //shoot
        if (Input.GetMouseButtonDown(0) && reloading == false && ammoLeft > 0)
        {
            ammoLeft = ammoLeft - 1;
            Shoot();
            Debug.Log("SHOOTING");
        } 
        
        if (Input.GetMouseButtonDown(0) && ammoLeft == 0)
        {
            Debug.Log("OUT OF AMMO");
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

    public void Shoot()
    {
        
        Instantiate(bullet, transform.position, bullet.transform.rotation);
    }
    
    public void Reload()
    {
        
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

}
