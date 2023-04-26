using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public Button startKnap;
    public Button indstillingerKnap;
    
    public GameObject indstillingerMenu;
    
    public float difficulty;
    
    public GameObject ESCMenu;
    public GameObject GameUI;
    public bool ESCMenuToggled;

    public Button ESCMenuResumeButton;
    public Button ESCMenuQuitButton;
    public bool isGameActive;

    public Camera MenuCamera;
    public Camera SpilCamera;
    public GameObject StartMenu;

    public GameObject DeathMenu;
    public TextMeshProUGUI deadKillsText;

    public int killedZombies;
    public TextMeshProUGUI killedZombiesText;

    private bool alive;
    

    // Start is called before the first frame update
    void Start()
    {
        difficulty = 2;
        isGameActive = false;
        MenuCamera.gameObject.SetActive(true);
        SpilCamera.gameObject.SetActive(false);
        killedZombies = 0;
        ESCMenuResumeButton.onClick.AddListener(ESCMenuVoid);
    }

    // Update is called once per frame
    void Update()
    {  
        alive = GameObject.Find("MaleFree1").GetComponent<PlayerController>().alive;
        if (alive == false)
        {
           Death();

        }
        
        if (GameUI.activeSelf)
        {
            killedZombiesText.text = "Killed Zombies: " + killedZombies; 
        } 
        if (isGameActive && Input.GetKeyDown(KeyCode.Escape))
    {
        ESCMenuVoid();
    }
        
    }

   public void StartButtonClicked()
    {
        GameObject.Find("MaleFree1").GetComponent<PlayerController>().GameStart();
        GameObject.Find("Wave spawner").GetComponent<WaveSpawner>().GameStart();
        Debug.Log("Spil startet");
        isGameActive = true;
        MenuCamera.gameObject.SetActive(false);
        SpilCamera.gameObject.SetActive(true);
        StartMenu.gameObject.SetActive(false);
        GameUI.SetActive(true);
        
    }
   
   public void IndstillingerButtonClicked()
    {
        Debug.Log("Indstillinger din nød");
        StartMenu.gameObject.SetActive(false);
        indstillingerMenu.gameObject.SetActive(true);
    }

    public void indstillingerMenuBackClicked()
    {
        StartMenu.gameObject.SetActive(true);
        indstillingerMenu.gameObject.SetActive(false);
    }

    public void ESCMenuVoid()
{
    if (ESCMenuToggled == false)
    {
        Cursor.lockState = CursorLockMode.None;
        ESCMenuToggled = true;
        isGameActive = false;
        GameUI.gameObject.SetActive(false);
        ESCMenu.gameObject.SetActive(true);
        indstillingerMenu.gameObject.SetActive(false); 

    }
    else if (ESCMenuToggled == true)
    {
        Cursor.lockState = CursorLockMode.Locked;
        ESCMenuToggled = false;
        isGameActive = true;
        GameUI.gameObject.SetActive(true);
        ESCMenu.gameObject.SetActive(false);
    }
}

    public void ESCMenuQuitClicked()
    {
        Cursor.lockState = CursorLockMode.None;
        isGameActive = false;
        ESCMenuToggled = false;
        ESCMenu.gameObject.SetActive(false);
        StartMenu.gameObject.SetActive(true);

        // Starter ResetGame der nulstiller spillet
        ResetGame();
    }

    private void ResetGame()
    {
        // Reset player position to the starting position
        GameObject.Find("MaleFree1").GetComponent<PlayerController>().transform.position = new Vector3(0, 1, 0);

        // Reset zombie spawner
        GameObject.Find("Wave spawner").GetComponent<WaveSpawner>().ResetSpawner();

        // Reset zombie kill count
        killedZombies = 0;
        killedZombiesText.text = "Killed Zombies: " + killedZombies;
    }

    public void EasyButtonClicked()
    {
        difficulty = 1;
    }

    public void MediumButtonClicked()
    {
        difficulty = 2;

    }

    public void HardButtonClicked()
    {
        difficulty = 3;
    }

    void Death()
    {
        DeathMenu.gameObject.SetActive(true);
        deadKillsText.text = "You killed " + killedZombies + " zombies!";
        Cursor.lockState = CursorLockMode.None;


    }
}
