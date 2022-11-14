using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerBehavior : MonoBehaviour
{
    public GameObject menuBackground;
    public GameObject quitButton;
    public GameObject continueButton;
    public GameObject levelSelect;
    public GameObject gameTitleText;
    

    static int  currentScene = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectRestart();

        if (Input.GetKey(KeyCode.L))
        {
            NextLevel();
        }
    }

    void NextLevel()
    {
        currentScene++;
        CameraPositioning.gameStarted = false;
        Debug.Log(currentScene);
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentScene);
    }
    private void DetectRestart()
    {
        if (Input.GetKey(KeyCode.Escape) && CameraPositioning.gameStarted == true)
        {

            menuBackground.SetActive(true);
            quitButton.SetActive(true);
            continueButton.SetActive(true);
            levelSelect.SetActive(true);
            gameTitleText.SetActive(true);
            CameraPositioning.gameStarted = false;
        } 

        else if (Input.GetKey(KeyCode.R)) 
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            PlayerBehavior player = playerObject.GetComponent<PlayerBehavior>();
            player.Invoke("Restart", 0f);
        }
    }

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentScene);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Tutorial()
    {
        CameraPositioning.gameStarted = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void CloseMenu()
    {
        menuBackground.SetActive(false);
        quitButton.SetActive(false);
        continueButton.SetActive(false);
        levelSelect.SetActive(false);
        gameTitleText.SetActive(false);
        CameraPositioning.gameStarted = true;

    }


    public void Quit()
    {
        Application.Quit();
    }

    public void BackToStartMenu()
    {
        CameraPositioning.gameStarted = false;
        if (currentScene >= 5)
        {
            currentScene = 2;

        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
