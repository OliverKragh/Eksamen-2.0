using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private int magazineSize = 30;
    public int ammoLeft;
    public bool reloading;
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
        if (Input.GetMouseButton(0))
        {
            ammoLeft = ammoLeft - 1;
            //Instantiate
        }



    }

    private void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R)) //ammoLeft < magazineSize && reloading = false) 
        {
            reloading = true;

            ammoLeft = magazineSize;
            reloading = false;
            Debug.Log("RELOADING");
        }

        
    }
}
