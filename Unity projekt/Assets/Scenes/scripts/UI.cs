using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Button startKnap;
    public Button indstillingerKnap;
    
    public GameObject indstillingerMenu;
    public GameObject StartMenu;
    public Button indstillingerMenuBack;
    
    public int difficulty;

    // Start is called before the first frame update
    void Start()
    {
       



       
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
        
        StartMenu.gameObject.SetActive(false);
        indstillingerMenu.gameObject.SetActive(true);
        indstillingerMenuBack.gameObject.SetActive(true);

    }

    public void indstillingerMenuBackClicked()
    {
        StartMenu.gameObject.SetActive(true);
        indstillingerMenu.gameObject.SetActive(false);
    }
}
