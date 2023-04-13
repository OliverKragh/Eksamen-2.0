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
    public Button indstillingerMenuBack;
    
    public int difficulty;

    //SPIL SCENE------------------------------------
    public GameObject ESCMenu;
    public GameObject GameUI;
    public bool ESCMenuToggled;

    public Button ESCMenuResumeButton;
    public Button ESCMenuQuitButton;
    public bool isGameActive;


    //
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
        if (SceneManager.GetActiveScene().name == "Spil Scenen" && Input.GetKeyDown(KeyCode.Escape))
        {
            ESCMenuVoid();
        }
    }

   public void StartButtonClicked()
    {

        Debug.Log("Spil startet");
        //Load Spil Scene
       SceneManager.LoadScene("Spil Scenen", LoadSceneMode.Single);
       //Unload UI Scene
        SceneManager.UnloadSceneAsync("UI Scene");
        GameUI.gameObject.SetActive(true);
    }
   
   public void IndstillingerButtonClicked()
    {
        Debug.Log("Indstillinger din nød");
        startKnap.gameObject.SetActive(false);
        indstillingerKnap.gameObject.SetActive(false);
        indstillingerMenu.gameObject.SetActive(true);
        indstillingerMenuBack.gameObject.SetActive(true);

    }

    public void indstillingerMenuBackClicked()
    {
        startKnap.gameObject.SetActive(true);
        indstillingerKnap.gameObject.SetActive(true);
        indstillingerMenu.gameObject.SetActive(false);
    }

    public void ESCMenuVoid()
    {

        if (ESCMenuToggled == false)
        {
        ESCMenuToggled = true;
            isGameActive = false;
         GameUI.gameObject.SetActive(false);
         ESCMenu.gameObject.SetActive(true);

        }

        else if (ESCMenuToggled == true)
        {
        ESCMenuToggled = false;
            isGameActive = true;
            GameUI.gameObject.SetActive(true);
        ESCMenu.gameObject.SetActive(false);
        }


    }
    public void ESCMenuQuitClicked()
    {

        //Load UI Scene
       SceneManager.LoadScene("UI Scene", LoadSceneMode.Single);
       //Unload Spil Scene
        SceneManager.UnloadSceneAsync("Spil Scenen"); 
    }
    public void ESCMenuResumeClicked()
    {
        GameUI.gameObject.SetActive(true);
      ESCMenuToggled = false;  
      ESCMenu.gameObject.SetActive(false);
    }
}
