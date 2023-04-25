using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysOnTop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.sortingOrder = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
