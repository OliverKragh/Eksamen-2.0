using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private int magazineSize = 30;
    public int ammoLeft;
    public bool reloading;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        ammoLeft = magazineSize;
    }

    // Update is called once per frame
    void Update()
    {
        

        
    }

    public void Shoot()
    {
        if (Input.GetMouseButton(0) && reloading == false && ammoLeft > 0)
        {
            ammoLeft = ammoLeft - 1;
            Instantiate(bullet, transform.position, bullet.transform.rotation);
            Debug.Log("SHOOTING");
        }



    }

    
    public void Reload()
    {
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

        
    }
    IEnumerator ReloadWait()
    {
        yield return new WaitForSeconds(1);
        ammoLeft = magazineSize;
        Debug.Log("RELOAD COMPLETE")
    }
    IEnumerator ReloadWaitEmpty()
    {
        yield return new WaitForSeconds(2);
        ammoLeft = magazineSize;
        Debug.Log("RELOAD COMPLETE")
    }

}
