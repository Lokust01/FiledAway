using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerBehavior : MonoBehaviour
{
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
        Debug.Log(currentScene);
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentScene);
    }
    private void DetectRestart()
    {
        if (Input.GetKey(KeyCode.Escape))
        { Application.Quit(); } 

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
        Application.Quit();
    }

    public void Tutorial()
    {
        CameraPositioning.gameStarted = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
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
