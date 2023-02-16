using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private Button startKnap;
    private Button indstillingerKnap;

    // Start is called before the first frame update
    void Start()
    {
       // startKnap = GetComponent<Button>();

       // startKnap.onClick.AddListener(StartButtonClicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void StartButtonClicked()
    {
        Debug.Log("Spil startet");
        //Load Spil Scene
       SceneManager.LoadScene("Spil Scenen", LoadSceneMode.Single);
       //Unload UI Scene
        SceneManager.UnloadSceneAsync("UI Scene");
    }
   
   public void IndstillingerButtonClicked()
    {
        Debug.Log("Indstillinger din nød");
        startKnap.gameObject.SetActive(false);
       // indstillingerKnap.gameObject.SetActive(false);
    }
}
