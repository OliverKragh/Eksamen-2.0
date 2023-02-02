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
        if (Input.GetKeyDown(KeyCode.R) && ammoLeft < magazineSize && reloading == false) 
        {
            reloading = true;
            StartCoroutine(ReloadWait());
            Debug.Log("RELOADING");
        }

        
    }
    IEnumerator ReloadWait()
    {
        yield return new WaitForSeconds(2);
        ammoLeft = magazineSize;
    }

}
